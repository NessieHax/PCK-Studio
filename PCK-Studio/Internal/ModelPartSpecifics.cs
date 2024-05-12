﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using PckStudio.Extensions;

namespace PckStudio.Internal
{
    internal static class ModelPartSpecifics
    {
        private static Dictionary<string, PositioningInfo> posisioningInfos = new Dictionary<string, PositioningInfo>()
        {
            ["HEAD"] = new PositioningInfo(),
            ["BODY"] = new PositioningInfo(),
            ["ARM0"] = new PositioningInfo(new(-5f,  -2f, 0f), new( 4f,  2f, 0f)),
            ["ARM1"] = new PositioningInfo(new( 5f,  -2f, 0f), new(-4f,  2f, 0f)),
            ["LEG0"] = new PositioningInfo(new(-2f, -12f, 0f), new(-2f, 12f, 0f)),
            ["LEG1"] = new PositioningInfo(new( 2f, -12f, 0f), new( 2f, 12f, 0f)),
        };

        internal record struct PositioningInfo(Vector3 Translation, Vector3 Pivot);

        internal static PositioningInfo GetPositioningInfo(string partName)
        {
            if (SkinBOX.IsOverlayPart(partName))
                partName = SkinBOXExtensions.GetBaseType(partName);
            return posisioningInfos.ContainsKey(partName) ? posisioningInfos[partName] : default;
        }
    }
}
