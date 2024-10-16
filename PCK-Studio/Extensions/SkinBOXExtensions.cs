﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using PckStudio.Internal;
using PckStudio.Internal.Skin;
using PckStudio.Rendering;

namespace PckStudio.Extensions
{
    internal static class SkinBOXExtensions
    {
        public static GraphicsPath GetUVGraphicsPath(this SkinBOX skinBOX, Vector2 tillingFactor)
        {
            var types = new byte[9];
            var points = new PointF[9];

            var path = new GraphicsPath(FillMode.Winding);

            Vector2 uv = skinBOX.UV;
            Vector3 size = skinBOX.Size;

            path.AddRectangle(new RectangleF(new PointF((uv.X                      ) * tillingFactor.X, (uv.Y + size.Z) * tillingFactor.Y), new SizeF(size.Z * tillingFactor.X, size.Y * tillingFactor.Y)));
            path.AddRectangle(new RectangleF(new PointF((uv.X + size.Z             ) * tillingFactor.X, (uv.Y + size.Z) * tillingFactor.Y), new SizeF(size.X * tillingFactor.X, size.Y * tillingFactor.Y)));
            path.AddRectangle(new RectangleF(new PointF((uv.X + size.Z + size.X    ) * tillingFactor.X, (uv.Y + size.Z) * tillingFactor.Y), new SizeF(size.Z * tillingFactor.X, size.Y * tillingFactor.Y)));
            path.AddRectangle(new RectangleF(new PointF((uv.X + size.Z * 2 + size.X) * tillingFactor.X, (uv.Y + size.Z) * tillingFactor.Y), new SizeF(size.X * tillingFactor.X, size.Y * tillingFactor.Y)));
            
            path.AddRectangle(new RectangleF(new PointF((uv.X + size.Z             ) * tillingFactor.X, (uv.Y         ) * tillingFactor.Y), new SizeF(size.X * tillingFactor.X, size.Z * tillingFactor.Y)));
            path.AddRectangle(new RectangleF(new PointF((uv.X + size.Z + size.X    ) * tillingFactor.X, (uv.Y         ) * tillingFactor.Y), new SizeF(size.X * tillingFactor.X, size.Z * tillingFactor.Y)));

            return path;
        }

        public static GraphicsPath GetUVGraphicsPath(this SkinBOX skinBox)
        {
            return skinBox.GetUVGraphicsPath(Vector2.One);
        }

        public static string GetOverlayType(this SkinBOX skinBox)
        {
            if (!skinBox.IsValidType())
                return "";
            if (skinBox.IsOverlayPart())
                return skinBox.Type;
            int index = Array.IndexOf(SkinBOX.BaseTypes, skinBox.Type);
            return SkinBOX.OverlayTypes.IndexInRange(index) ? SkinBOX.OverlayTypes[index] : "";
        }

        public static string GetOverlayType(string type)
        {
            if (!SkinBOX.IsValidType(type))
                return "";
            if (SkinBOX.IsOverlayPart(type))
                return type;
            int index = Array.IndexOf(SkinBOX.BaseTypes, type);
            return SkinBOX.OverlayTypes.IndexInRange(index) ? SkinBOX.OverlayTypes[index] : "";
        }

        public static string GetBaseType(this SkinBOX skinBox)
        {
            if (!skinBox.IsValidType())
                return "";
            if (skinBox.IsBasePart())
                return skinBox.Type;
            int index = Array.IndexOf(SkinBOX.OverlayTypes, skinBox.Type);
            return SkinBOX.BaseTypes.IndexInRange(index) ? SkinBOX.BaseTypes[index] : "";
        }

        public static string GetBaseType(string type)
        {
            if (!SkinBOX.IsValidType(type))
                return "";
            if (SkinBOX.IsBasePart(type))
                return type;
            int index = Array.IndexOf(SkinBOX.OverlayTypes, type);
            return SkinBOX.BaseTypes.IndexInRange(index) ? SkinBOX.BaseTypes[index] : "";
        }

        internal static Cube ToCube(this SkinBOX skinBOX) => skinBOX.ToCube(0f);

        internal static Cube ToCube(this SkinBOX skinBOX, float inflate, bool flipZMapping = false)
            => new Cube(skinBOX.Pos.ToOpenTKVector(), skinBOX.Size.ToOpenTKVector(), skinBOX.UV.ToOpenTKVector(), skinBOX.Scale + inflate, skinBOX.Mirror, flipZMapping);
    }
}
