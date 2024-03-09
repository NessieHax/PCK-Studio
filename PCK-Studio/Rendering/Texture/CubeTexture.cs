﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL;
using PckStudio.Extensions;

namespace PckStudio.Rendering.Texture
{
    internal class CubeTexture : Texture
    {
        public CubeTexture(int slot) : base(TextureTarget.TextureCubeMap)
        {
            Slot = slot;
        }

        public void SetTexture(Image image)
        {
            Bind();

            int heightPerFace = image.Height / 3;
            int widthPerFace = image.Width / 4;

            Size faceSize = new Size(widthPerFace, heightPerFace);

            Image[] faces = new Image[6];

            Point rightFace = new Point(widthPerFace * 2, heightPerFace * 1);
            faces[0] = image.GetArea(new Rectangle(rightFace, faceSize));

            Point lefttFace = new Point(widthPerFace * 0, heightPerFace * 1);
            faces[1] = image.GetArea(new Rectangle(lefttFace, faceSize));

            Point topFace = new Point(widthPerFace * 1, heightPerFace * 0);
            faces[2] = image.GetArea(new Rectangle(topFace, faceSize));

            Point bottomFace = new Point(widthPerFace * 1, heightPerFace * 2);
            faces[3] = image.GetArea(new Rectangle(bottomFace, faceSize));

            Point frontFace = new Point(widthPerFace * 1, heightPerFace * 1);
            faces[4] = image.GetArea(new Rectangle(frontFace, faceSize));

            Point backFace = new Point(widthPerFace * 3, heightPerFace * 1);
            faces[5] = image.GetArea(new Rectangle(backFace, faceSize));

            for (int i = 0; i < 6; i++)
            {
                var texture = new Bitmap(faces[i]);
                BitmapData data = texture.LockBits(new Rectangle(Point.Empty, texture.Size), ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                GL.TexImage2D(TextureTarget.TextureCubeMapPositiveX + i, 0, InternalPixelFormat, widthPerFace, heightPerFace, 0, PixelFormat, PixelType.UnsignedByte, data.Scan0);
            }
            Unbind();
        }

    }
}
