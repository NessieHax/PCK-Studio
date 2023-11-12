﻿/* Copyright (c) 2023-present miku-666
 * This software is provided 'as-is', without any express or implied
 * warranty. In no event will the authors be held liable for any damages
 * arising from the use of this software.
 * 
 * Permission is granted to anyone to use this software for any purpose,
 * including commercial applications, and to alter it and redistribute it
 * freely, subject to the following restrictions:
 * 
 * 1.The origin of this software must not be misrepresented; you must not
 *    claim that you wrote the original software. If you use this software
 *    in a product, an acknowledgment in the product documentation would be
 *    appreciated but is not required.
 * 2. Altered source versions must be plainly marked as such, and must not be
 *    misrepresented as being the original software.
 * 3. This notice may not be removed or altered from any source distribution.
**/
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using PckStudio.Extensions;
using PckStudio.Internal;

namespace PckStudio.Rendering
{
    internal class CubeRenderGroup : RenderGroup<TextureVertex>
    {
        private const int vertexCountPerCube = 16;

        internal CubeRenderGroup(string name)
            : base(name, new VertexBufferLayout().Add<float>(3).Add<float>(2), PrimitiveType.Quads)
        {
        }

        internal void AddSkinBox(SkinBOX skinBox)
        {
            AddCube(skinBox.Pos.ToOpenTKVector(), skinBox.Size.ToOpenTKVector(), skinBox.UV.ToOpenTKVector(), skinBox.Scale, skinBox.Mirror);
        }

        internal void AddCube(Vector3 position, Vector3 size, Vector2 uv, float scale = 0f, bool mirror = false)
        {
            var vertexData = GetCubeVertexData(position, size, uv, scale, mirror);

            vertices.AddRange(vertexData);

            var indexStorage = new uint[] {
                 // Face 1 (Front)
                  0,  1,  2,  3,
                 // Face 2 (Back)
                  4,  5,  6,  7,
                 // Face 3 (Right)
                  4,  8,  9,  7,
                 // Face 4 (Left)
                  1,  5,  6,  2,
                 // Face 5 (Top)
                  10, 11, 4,  5,
                 // Face 6 (Bottom)
                 12, 13, 14, 15
                };
            indices.AddRange(indexStorage.Select(n => n + indicesOffset));
            indicesOffset += vertexCountPerCube;
        }

        internal void ReplaceCube(int index, Vector3 position, Vector3 size, Vector2 uv, float scale = 0f, bool mirror = false)
        {
            if (index * vertexCountPerCube > vertices.Count || index < 0)
                throw new IndexOutOfRangeException();

            vertices.InsertRange(index * vertexCountPerCube, GetCubeVertexData(position, size, uv, scale, mirror));
        }

        // TODO: add mirroring support
        private TextureVertex[] GetCubeVertexData(Vector3 position, Vector3 size, Vector2 uv, float scale, bool mirror)
        {
            return new TextureVertex[]
            {
                new TextureVertex(new Vector3(position.X         , size.Y + position.Y, -(size.Z + position.Z)) * (scale + 1f), new Vector2(uv.X + size.Z * 2 + size.X * 2, uv.Y + size.Z)),
                new TextureVertex(new Vector3(size.X + position.X, size.Y + position.Y, -(size.Z + position.Z)) * (scale + 1f), new Vector2(uv.X + size.Z * 2 + size.X, uv.Y + size.Z)),
                new TextureVertex(new Vector3(size.X + position.X, position.Y         , -(size.Z + position.Z)) * (scale + 1f), new Vector2(uv.X + size.Z * 2 + size.X, uv.Y + size.Z + size.Y)),
                new TextureVertex(new Vector3(position.X         , position.Y         , -(size.Z + position.Z)) * (scale + 1f), new Vector2(uv.X + size.Z * 2 + size.X * 2, uv.Y + size.Z + size.Y)),

                new TextureVertex(new Vector3(position.X         , size.Y + position.Y, -position.Z           ) * (scale + 1f), new Vector2(uv.X + size.Z, uv.Y + size.Z)),
                new TextureVertex(new Vector3(size.X + position.X, size.Y + position.Y, -position.Z           ) * (scale + 1f), new Vector2(uv.X + size.Z + size.X, uv.Y + size.Z)),
                new TextureVertex(new Vector3(size.X + position.X, position.Y         , -position.Z           ) * (scale + 1f), new Vector2(uv.X + size.Z + size.X, uv.Y + size.Z + size.Y)),
                new TextureVertex(new Vector3(position.X         , position.Y         , -position.Z           ) * (scale + 1f), new Vector2(uv.X + size.Z, uv.Y + size.Z + size.Y)),

                new TextureVertex(new Vector3(position.X         , size.Y + position.Y, -(size.Z + position.Z)) * (scale + 1f), new Vector2(uv.X, uv.Y + size.Z)),
                new TextureVertex(new Vector3(position.X         , position.Y         , -(size.Z + position.Z)) * (scale + 1f), new Vector2(uv.X, uv.Y + size.Z + size.Y)),
                new TextureVertex(new Vector3(size.X + position.X, size.Y + position.Y, -(size.Z + position.Z)) * (scale + 1f), new Vector2(uv.X + size.Z + size.X, uv.Y)),
                new TextureVertex(new Vector3(position.X         , size.Y + position.Y, -(size.Z + position.Z)) * (scale + 1f), new Vector2(uv.X + size.Z, uv.Y)),

                new TextureVertex(new Vector3(size.X + position.X, position.Y         , -position.Z           ) * (scale + 1f), new Vector2(uv.X + size.Z + size.X * 2, uv.Y)),
                new TextureVertex(new Vector3(position.X         , position.Y         , -position.Z           ) * (scale + 1f), new Vector2(uv.X + size.Z + size.X, uv.Y)),
                new TextureVertex(new Vector3(position.X         , position.Y         , -(size.Z + position.Z)) * (scale + 1f), new Vector2(uv.X + size.Z + size.X, uv.Y + size.Z)),
                new TextureVertex(new Vector3(size.X + position.X, position.Y         , -(size.Z + position.Z)) * (scale + 1f), new Vector2(uv.X + size.Z + size.X * 2, uv.Y + size.Z)),
            };
        }
    }
}
