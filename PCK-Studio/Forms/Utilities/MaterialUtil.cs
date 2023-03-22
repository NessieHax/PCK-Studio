﻿using Newtonsoft.Json.Linq;
using System.Drawing;
using System.Linq;
using System.IO;

using PckStudio.Properties;
using PckStudio.Classes.Extentions;
using OMI.Formats.Pck;
using OMI.Formats.Material;
using OMI.Workers.Material;

namespace PckStudio.Forms.Utilities
{
    public static class MaterialUtil
    {
        public static readonly JObject entityData = JObject.Parse(Resources.entityMaterialData);
        private static Image[] _entityImages;
        public static Image[] entityImages => _entityImages ??= Resources.entities_sheet.CreateImageList(32).ToArray();

        public static PckFile.FileData CreateNewMaterialsFile()
        {
            PckFile.FileData file = new PckFile.FileData($"entityMaterials.bin", PckFile.FileData.FileType.MaterialFile);

            using (var stream = new MemoryStream())
            {
                var matFile = new MaterialContainer
                {
                    new MaterialContainer.Material("bat", "entity_alphatest")
                };
                var writer = new MaterialFileWriter(matFile);
                writer.WriteToStream(stream);
                file.SetData(stream.ToArray());
            }
            
            return file;
        }
    }
}
