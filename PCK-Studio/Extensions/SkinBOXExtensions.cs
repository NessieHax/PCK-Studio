﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using PckStudio.Internal;

namespace PckStudio.Extensions
{
    internal static class SkinBOXExtensions
    {
        public static GraphicsPath GetUVGraphicsPath(this SkinBOX skinBOX, Vector2 scalingFactor)
        {
            var types = new byte[9];
            var points = new PointF[9];

            types[0] = (byte)PathPointType.Start;
            types[1] = (byte)PathPointType.Line;
            types[2] = (byte)PathPointType.Line;
            types[3] = (byte)PathPointType.Line;
            types[4] = (byte)PathPointType.Line;
            types[5] = (byte)PathPointType.Line;
            types[6] = (byte)PathPointType.Line;
            types[7] = (byte)PathPointType.Line;
            types[8] = (byte)PathPointType.Line;

            points[0] = new PointF(skinBOX.UV.X, skinBOX.UV.Y + skinBOX.Size.Z);
            points[1] = new PointF(skinBOX.UV.X + skinBOX.Size.Z, skinBOX.UV.Y + skinBOX.Size.Z);
            points[2] = new PointF(skinBOX.UV.X + skinBOX.Size.Z, skinBOX.UV.Y);
            points[3] = new PointF(skinBOX.UV.X + skinBOX.Size.Z + skinBOX.Size.X * 2, skinBOX.UV.Y);
            points[4] = new PointF(skinBOX.UV.X + skinBOX.Size.Z + skinBOX.Size.X * 2, skinBOX.UV.Y + skinBOX.Size.Z);
            points[5] = new PointF(skinBOX.UV.X + skinBOX.Size.Z * 2 + skinBOX.Size.X * 2, skinBOX.UV.Y + skinBOX.Size.Z);
            points[6] = new PointF(skinBOX.UV.X + skinBOX.Size.Z * 2 + skinBOX.Size.X * 2, skinBOX.UV.Y + skinBOX.Size.Z + skinBOX.Size.Y);
            points[7] = new PointF(skinBOX.UV.X, skinBOX.UV.Y + skinBOX.Size.Z + skinBOX.Size.Y);
            points[8] = points[0];

            for (int i = 0; i < points.Length; i++)
            {
                points[i] = new PointF(points[i].X * scalingFactor.X, points[i].Y * scalingFactor.Y);
            }

            return new GraphicsPath(points, types);

        }

        public static GraphicsPath GetUVGraphicsPath(this SkinBOX skinBOX)
        {
            return skinBOX.GetUVGraphicsPath(Vector2.One);
        }
    }
}
