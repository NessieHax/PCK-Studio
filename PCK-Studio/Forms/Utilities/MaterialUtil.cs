﻿using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;

using PckStudio.Properties;
using PckStudio.Classes.FileTypes;
using PckStudio.Classes.IO.Materials;
using PckStudio.Classes.Utils;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.IO;

namespace PckStudio.Forms.Utilities
{
    public static class MaterialUtil
    {
        public static readonly JObject entityData = JObject.Parse(Resources.entityMaterialData);
        private static Image[] _entityImages;
        public static Image[] entityImages
        {
            get { 
                if (_entityImages == null)
                    _entityImages = ImageUtils.CreateImageList(Resources.entities_sheet, 32).ToArray();
                return _entityImages;
            }
        }
        public static PCKFile.FileData CreateNewMaterialsFile()
        {
            PCKFile.FileData file = new PCKFile.FileData($"entityMaterials.bin", PCKFile.FileData.FileType.MaterialFile);

            using (var stream = new MemoryStream())
            {
                var matFile = new MaterialsFile();
				matFile.entries.Add(new MaterialsFile.MaterialEntry("bat", "entity_alphatest"));
				MaterialsWriter.Write(stream, matFile);
                file.SetData(stream.ToArray());
            }
            
            return file;
        }
    }
}
