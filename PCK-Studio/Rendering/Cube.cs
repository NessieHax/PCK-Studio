﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICSharpCode.SharpZipLib.Zip.Compression;
using OpenTK;
using PckStudio.Extensions;
using PckStudio.Internal;

namespace PckStudio.Rendering
{
    internal class Cube
    {
        internal Vector3 Position
        {
            get => _position;
            set => _position = value;
        }

        internal Vector3 Size
        {
            get => _size;
            set => _size = value;
        }

        internal Vector2 Uv
        {
            get => _uv;
            set => _uv = value;
        }

        internal float Inflate
        {
            get => _inflate;
            set => _inflate = value;
        }

        internal bool MirrorTexture
        {
            get => _mirrorTexture;
            set => _mirrorTexture = value;
        }

        internal bool FlipZMapping
        {
            get => _flipZMapping;
            set => _flipZMapping = value;
        }
        
        public Vector3 Center => Position + Size / 2f;
        
        internal enum Face
        {
            Back,
            Front,
            Top,
            Bottom,
            Left,
            Right
        }

        internal static Cube FromSkinBox(SkinBOX skinBOX)
        {
            return new Cube(skinBOX.Pos.ToOpenTKVector(), skinBOX.Size.ToOpenTKVector(), skinBOX.UV.ToOpenTKVector(), skinBOX.Scale, skinBOX.Mirror, false);
        }

        public Cube() { }

        public Cube(Vector3 position, Vector3 size, Vector2 uv, float inflate, bool mirrorTexture, bool flipZMapping)
        {
            _position = position;
            _size = size;
            _uv = uv;
            _inflate = inflate;
            _mirrorTexture = mirrorTexture;
            _flipZMapping = flipZMapping;
        }

        public Vector3 GetFaceCenter(Face face)
        {
            var result = Center;
            switch (face)
            {
                case Face.Top:
                    result.Y -= Size.Y / 2f;
                    return result;
                case Face.Bottom:
                    result.Y += Size.Y / 2f;
                    return result;
                case Face.Back:
                    result.Z -= Size.Z / 2f;
                    return result;
                case Face.Front:
                    result.Z += Size.Z / 2f;
                    return result;
                case Face.Left:
                    result.X -= Size.X / 2f;
                    return result;
                case Face.Right:
                    result.X += Size.X / 2f;
                    return result;
                default:
                    return result;
            }
        }

        public BoundingBox GetBoundingBox()
        {
            Vector3 halfSize = Size / 2f;
            Vector3 halfSizeInflated = halfSize + new Vector3(Inflate);
            Vector3 start = Center - halfSizeInflated;
            Vector3 end = Center + halfSizeInflated;
            return new BoundingBox(start, end);
        }


        protected Vector3 _position = Vector3.Zero;
        protected Vector3 _size = Vector3.One;
        protected Vector2 _uv = Vector2.Zero;
        protected float _inflate = 0f;
        protected bool _mirrorTexture = false;
        protected bool _flipZMapping = false;
    }
}