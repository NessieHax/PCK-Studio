﻿using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OMI.Formats.Languages;
using OMI.Formats.Pck;
using PckStudio.Internal;

namespace PckStudio.Extensions
{
    internal static class SkinExtensions
    {
        public static PckAsset CreateFile(this Skin skin, LOCFile localizationFile)
        {
            string skinId = skin.Id.ToString("d08");
            PckAsset skinFile = new PckAsset($"dlcskin{skinId}.png", PckAssetType.SkinFile);

            skinFile.AddProperty("DISPLAYNAME", skin.Name);
            if (localizationFile is not null)
            {
                string skinLocKey = $"IDS_dlcskin{skinId}_DISPLAYNAME";
                skinFile.AddProperty("DISPLAYNAMEID", skinLocKey);
                localizationFile.AddLocKey(skinLocKey, skin.Name);
            }

            if (!string.IsNullOrEmpty(skin.Theme))
            {
                skinFile.AddProperty("THEMENAME", skin.Theme);
                if (localizationFile is not null)
                {
                    skinFile.AddProperty("THEMENAMEID", $"IDS_dlcskin{skinId}_THEMENAME");
                    localizationFile.AddLocKey($"IDS_dlcskin{skinId}_THEMENAME", skin.Theme);
                }
            }

            if (skin.HasCape)
            {
                skinFile.AddProperty("CAPEPATH", $"dlccape{skinId}.png");
            }

            skinFile.AddProperty("ANIM", skin.ANIM);
            skinFile.AddProperty("GAME_FLAGS", "0x18");
            skinFile.AddProperty("FREE", "1");

            foreach (SkinBOX box in skin.AdditionalBoxes)
            {
                skinFile.AddProperty(box.ToProperty());
            }
            foreach (SkinPartOffset offset in skin.PartOffsets)
            {
                skinFile.AddProperty(offset.ToProperty());
            }

            skinFile.SetTexture(skin.Texture);

            return skinFile;
        }

        public static PckAsset CreateCapeFile(this Skin skin)
        {
            if (!skin.HasCape)
                throw new InvalidOperationException("Skin does not contain a cape.");
            string skinId = skin.Id.ToString("d08");
            PckAsset capeFile = new PckAsset($"dlccape{skinId}.png", PckAssetType.CapeFile);
            capeFile.SetTexture(skin.CapeTexture);
            return capeFile;
        }
    }
}
