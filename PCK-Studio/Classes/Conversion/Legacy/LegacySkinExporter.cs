﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OMI.Formats.Pck;
using PckStudio.Classes.Conversion.Legacy.JsonDefinitions;
using PckStudio.Extensions;
using PckStudio.Conversion.Common.JsonDefinitions;
using PckStudio.Classes.Utils;

namespace PckStudio.Conversion.Legacy
{
    /// <summary>
    /// Allows Converting Bedrock model file (*.geo.json) to a legacy type version
    /// as well as whole bedrock skin pack https://learn.microsoft.com/en-us/minecraft/creator/documents/packagingaskinpack
    /// </summary>
    internal class LegacySkinExporter
    {
        public PckFile ConvertPack(DirectoryInfo directory)
        {
            var jsonFiles = directory.GetFiles("*.json", SearchOption.TopDirectoryOnly);
            var textureFiles = directory.GetFiles("*.png", SearchOption.TopDirectoryOnly);
            var textsDir = directory.GetDirectories("texts", SearchOption.TopDirectoryOnly);
            var localsDir = textsDir.Length > 0 ? textsDir[0] : null;

            return default!;
        }

        /// <summary>
        /// Converts a skin(Bedrock Model) made in Blockbench to a valid legacy skin
        /// </summary>
        /// <param name="texture">Texture for the model</param>
        /// <param name="blockbenchBedrockJsonData">Exported Bedrock Model from Blockbench</param>
        /// <returns>Legacy skin format</returns>
        public PckFile.FileData ConvertBlockbenchModel(string blockbenchBedrockJsonData, Image texture)
        {
            var container = JsonConvert.DeserializeObject<BlockbenchBedrockModel>(blockbenchBedrockJsonData);
            if (container.Models.Length > 0)
            {
                var model = container.Models[0];
                if (texture.Size != model.Description.TextureSize)
                    throw new ArgumentException("Model texture size does not match supplied Image size.");

                var file = new PckFile.FileData("", PckFile.FileData.FileType.SkinFile);

                var anim = new SkinANIM();
                var boxes = new Stack<SkinBOX>(10);

                return default!;
            }
            return default!;
        }

        private static Dictionary<string, GeometryCube> defaultSkinParts = new Dictionary<string, GeometryCube>()
        {
            ["head"] = new GeometryCube(new Vector3(-4, 24, -4), new Vector3(8), new Vector2(0)),
            ["body"] = new GeometryCube(new Vector3(-4, 12, -2), new Vector3(8, 12, 4), new Vector2(16)),
            ["leg0"] = new GeometryCube(new Vector3(-4, 0, -2), new Vector3(4, 12, 4), new Vector2(0, 16)),
            ["leg1"] = new GeometryCube(new Vector3(0, 0, -2), new Vector3(4, 12, 4), new Vector2(16, 48)),
            ["arm0"] = new GeometryCube(new Vector3(-8, 12, -2), new Vector3(4, 12, 4), new Vector2(40, 16)),
            ["arm1"] = new GeometryCube(new Vector3(4, 24, -2), new Vector3(4, 12, 4), new Vector2(32, 48)),
            ["arm0_slim"] = new GeometryCube(new Vector3(-7, 12, -2), new Vector3(3, 12, 4), new Vector2(40, 16)),
            ["arm1_slim"] = new GeometryCube(new Vector3(4, 24, -2), new Vector3(3, 12, 4), new Vector2(32, 48))
        };

        private bool HasHuminodOrSlimModel(BlockbenchBedrockModel.BedrockModel bedrockModel)
        {
            Dictionary<string, bool> keyValues = new Dictionary<string, bool>(6);
            foreach (var bone in bedrockModel.Bones)
            {
                if (defaultSkinParts.ContainsKey(bone.Name))
                {
                    var defaultCube = defaultSkinParts[bone.Name];
                    keyValues[bone.Name] = bone.Cubes.Any(cube =>
                    {
                        return cube.Origin.SequenceEqual(defaultCube.Origin) &&
                            cube.Size.SequenceEqual(defaultCube.Size) &&
                            cube.UV.SequenceEqual(defaultCube.UV);
                    });
                }
            }
            return false;
        }

    }
}
