﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OMI.Formats.Languages;
using OMI.Formats.Pck;
using OMI.Workers;
using PckStudio.Internal;

namespace PckStudio.Extensions
{
    internal static class PckFileDataExtensions
    {
        private const string MipMap = "MipMapLevel";

        private static Image EmptyImage = new Bitmap(1, 1, PixelFormat.Format32bppArgb);

        internal static Image GetTexture(this PckFileData file)
        {
            if (file.Filetype != PckFileType.SkinFile &&
                file.Filetype != PckFileType.CapeFile &&
                file.Filetype != PckFileType.TextureFile)
            {
                throw new Exception("File is not suitable to contain image data.");
            }
            using var stream = new MemoryStream(file.Data);

            try
            {
                return Image.FromStream(stream);
            }
            catch (Exception ex)
            {
                Trace.TraceError($"Failed to read image from pck file data({file.Filename}).");
                Debug.WriteLine(ex.Message);
                return EmptyImage;
            }
        }

        /// <summary>
        /// Tries to get the skin id of the skin <paramref name="file"/>
        /// </summary>
        /// <param name="file"></param>
        /// <returns>Non-zero base number on success, otherwise 0</returns>
        /// <exception cref="InvalidOperationException"></exception>
        internal static int GetSkinId(this PckFileData file)
        {
            if (file.Filetype != PckFileType.SkinFile)
                throw new InvalidOperationException("File is not a skin file");
            
            string filename = Path.GetFileNameWithoutExtension(file.Filename);
            if (!filename.StartsWith("dlcskin"))
            {
                Trace.TraceWarning($"[{nameof(GetSkin)}] File does not start with 'dlcskin'");
                return 0;
            }

            int skinId = 0;
            if (!int.TryParse(filename.Substring("dlcskin".Length), out skinId))
            {
                Trace.TraceWarning($"[{nameof(GetSkin)}] Failed to parse Skin Id");
            }
            return skinId;
        }

        internal static Skin GetSkin(this PckFileData file)
        {
            if (file.Filetype != PckFileType.SkinFile)
                throw new InvalidOperationException("File is not a skin file");

            //if (file.Properties.Contains("CAPEPATH"))
            //    Debug.WriteLine($"[{nameof(GetSkin)}] TODO: add cape texture/path.");

            int skinId = file.GetSkinId();

            string name = file.Properties.GetPropertyValue("DISPLAYNAME");
            Image texture = file.GetTexture();
            SkinANIM anim = file.Properties.GetPropertyValue("ANIM", SkinANIM.FromString);
            IEnumerable<SkinBOX> boxes = file.Properties.GetProperties("BOX").Select(kv => SkinBOX.FromString(kv.Value));
            IEnumerable<SkinPartOffset> offsets = file.Properties.GetProperties("OFFSET").Select(kv => SkinPartOffset.FromString(kv.Value));
            return new Skin(name, skinId, texture, anim, boxes, offsets);
        }

        internal static void SetSkin(this PckFileData file, Skin skin, LOCFile localizationFile)
        {
            if (file.Filetype != PckFileType.SkinFile)
                throw new InvalidOperationException("File is not a skin file");

            file.SetData(skin.Texture, ImageFormat.Png);

            string skinId = skin.Id.ToString("d08");

            // TODO: keep filepath 
            file.Filename = $"dlcskin{skinId}.png";

            string skinLocKey = $"IDS_dlcskin{skinId}_DISPLAYNAME";
            file.Properties.SetProperty("DISPLAYNAME", skin.Name);
            file.Properties.SetProperty("DISPLAYNAMEID", skinLocKey);
            localizationFile.AddLocKey(skinLocKey, skin.Name);

            if (!string.IsNullOrEmpty(skin.Theme))
            {
                file.Properties.SetProperty("THEMENAME", skin.Theme);
                file.Properties.SetProperty("THEMENAMEID", $"IDS_dlcskin{skinId}_THEMENAME");
                localizationFile.AddLocKey($"IDS_dlcskin{skinId}_THEMENAME", skin.Theme);
            }

            if (skin.HasCape)
            {
                file.Properties.SetProperty("CAPEPATH", $"dlccape{skinId}.png");
            }

            file.Properties.SetProperty("ANIM", skin.ANIM.ToString());
            file.Properties.SetProperty("GAME_FLAGS", "0x18");
            file.Properties.SetProperty("FREE", "1");

            file.Properties.RemoveAll(kv => kv.Key == "BOX");
            file.Properties.RemoveAll(kv => kv.Key == "OFFSET");

            foreach (SkinBOX box in skin.AdditionalBoxes)
            {
                file.Properties.Add(box.ToProperty());
            }
            foreach (SkinPartOffset offset in skin.PartOffsets)
            {
                file.Properties.Add(offset.ToProperty());
            }
        }

        internal static void SetData(this PckFileData file, IDataFormatWriter writer)
        {
            using (var stream = new MemoryStream())
            {
                writer.WriteToStream(stream);
                file.SetData(stream.ToArray());
            }
        }

        internal static void SetData(this PckFileData file, Image image, ImageFormat imageFormat)
        {
            if (file.Filetype != PckFileType.SkinFile &&
                file.Filetype != PckFileType.CapeFile &&
                file.Filetype != PckFileType.TextureFile)
            {
                throw new Exception("File is not suitable to contain image data.");
            }

            using (var stream = new MemoryStream())
            {
                image.Save(stream, imageFormat);
                file.SetData(stream.ToArray());
            }
        }

        internal static bool IsMipmappedFile(this PckFileData file)
        {
            // We only want to test the file name itself. ex: "terrainMipMapLevel2"
            string name = Path.GetFileNameWithoutExtension(file.Filename);

            // check if last character is a digit (0-9). If not return false
            if (!char.IsDigit(name[name.Length - 1]))
                return false;

            // If string does not end with MipMapLevel, then it's not MipMapped
            if (!name.Remove(name.Length - 1, 1).EndsWith(MipMap))
                return false;
            return true;
        }

        internal static string GetNormalPath(this PckFileData file)
        {
            if (!file.IsMipmappedFile())
                return file.Filename;
            string ext = Path.GetExtension(file.Filename);
            return file.Filename.Remove(file.Filename.Length - (MipMap.Length + 1) - ext.Length) + ext;
        }
    }
}
