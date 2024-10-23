﻿/* Copyright (c) 2024-present miku-666
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
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using PckStudio.Extensions;
using PckStudio.External.Format;
using PckStudio.Internal;
using PckStudio.Internal.Skin;

namespace PckStudio.Rendering
{
    static class CubeMeshCollectionExtensions
    {
        internal static void AddSkinBox(this CubeMeshCollection cubeMeshes, SkinBOX skinBox, float inflate = 0f)
        {
            var cube = skinBox.ToCube(inflate, cubeMeshes.FlipZMapping);
            cubeMeshes.Add(new CubeMesh(skinBox.Type, cube));
        }
    }

    internal class CubeMeshCollection : GenericMesh<TextureVertex>, ICollection<GenericMesh<TextureVertex>>
    {
        private List<GenericMesh<TextureVertex>> cubes;
        private Dictionary<string, CubeMeshCollection> subCollection;

        public bool FlipZMapping
        {
            get => _flipZMapping;
            set => _flipZMapping = value;
        }

        public Vector3 Translation { get; set; }
        public Vector3 Rotation { get; }
        public Vector3 Pivot { get; }
        private Vector3 _offset { get; set; } = Vector3.Zero;
        public Vector3 Offset
        {
            get => _offset;
            set => _offset = value;
        }

        public override Matrix4 GetTransform()
        {
            Matrix4 rotations = (
                Matrix4.CreateRotationX(MathHelper.DegreesToRadians(Rotation.X)) *
                Matrix4.CreateRotationY(MathHelper.DegreesToRadians(Rotation.Y)) *
                Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(Rotation.Z))
                );
            Matrix4 translation = Matrix4.CreateTranslation(Translation + Offset);
            return translation * (rotations).Pivoted(Pivot - Offset);
        }

        public int Count => cubes.Count;

        public bool IsReadOnly => false;

        private bool _flipZMapping = false;

        internal CubeMeshCollection(string name, bool visible = true) : base(name, visible, PrimitiveType.Triangles, CubeMesh.VertexBufferLayout)
        {
            cubes = new List<GenericMesh<TextureVertex>>(5);
            subCollection = new Dictionary<string, CubeMeshCollection>();
        }

        internal CubeMeshCollection(string name, Vector3 translation, Vector3 pivot, Vector3 rotation = default)
            : this(name)
        {
            Translation = translation;
            Pivot = pivot;
            Rotation = rotation;
        }

        public override GenericMesh<TextureVertex> SetVisible(bool visible)
        {
            if (Visible == visible)
                return this;

            var mesh = new CubeMeshCollection(Name, visible);
            mesh.cubes = this.cubes;
            return mesh;
        }

        internal override IEnumerable<TextureVertex> GetVertices()
            => cubes.Where(c => c.Visible).SelectMany(c =>
                c.GetVertices().Select(vertex => new TextureVertex(Vector3.TransformPosition(vertex.Position, c.GetTransform()), vertex.TexPosition))
            );

        internal override IEnumerable<int> GetIndices()
        {
            int offset = 0;
            IEnumerable<int> selector(GenericMesh<TextureVertex> c)
            {
                IEnumerable<int> result = c.GetIndices().Select(i => i + offset).ToArray();
                int vertexCount = c.GetVertices().Count();
                offset += vertexCount;
                return result;
            }
            return cubes.Where(c => c.Visible).SelectMany(selector);
        }

        internal void Add(Vector3 position, Vector3 size, Vector2 uv, float inflate = 0f, bool mirrorTexture = false)
        {
            var cube = new Cube(position, size, uv, inflate, mirrorTexture, FlipZMapping);
            Add(new CubeMesh(cube));
        }

        internal void AddNamed(string name, Vector3 position, Vector3 size, Vector2 uv, float inflate = 0f, bool mirrorTexture = false)
        {
            var cube = new Cube(position, size, uv, inflate, mirrorTexture, FlipZMapping);
            Add(new CubeMesh(name, cube));
        }

        internal void AddSubCollection(string name, Vector3 translation, Vector3 pivot, Vector3 rotation = default)
        {
            var item = new CubeMeshCollection(name, translation, pivot, rotation);
            Add(item);
            subCollection.Add(name, item);
        }

        internal CubeMeshCollection GetCollection(string collectionName)
        {
            _ = collectionName ?? throw new ArgumentNullException(nameof(collectionName));
            return ContainsCollection(collectionName) ? subCollection[collectionName] : null; 
        }

        internal void Remove(int index)
        {
            if (!cubes.IndexInRange(index))
                throw new IndexOutOfRangeException();
            
            cubes.RemoveAt(index);
        }

        internal void ReplaceCube(int index, Vector3 position, Vector3 size, Vector2 uv, float inflate = 0f, bool mirrorTexture = false)
        {
            if (!cubes.IndexInRange(index))
                throw new IndexOutOfRangeException();


            if (cubes[index] is CubeMesh cubeMesh)
            cubes[index] = cubeMesh.SetCube(new Cube(position, size, uv, inflate, mirrorTexture, FlipZMapping));
        }

        internal Vector3 GetCenter(int index)
        {
            if (!cubes.IndexInRange(index))
                throw new IndexOutOfRangeException();

            return cubes[index].GetBounds(GetTransform()).Center;
        }
         
        internal BoundingBox GetCubeBoundingBox(int index)
        {
            if (!cubes.IndexInRange(index))
                throw new IndexOutOfRangeException();

            return cubes[index].GetBounds(GetTransform());
        }

        public override BoundingBox GetBounds(Matrix4 transform)
        {
            IEnumerable<BoundingBox> boundingBoxes = cubes
                .Where(c => c.Visible)
                .Select(c => c.GetBounds(GetTransform() * transform))
            return BoundingBox.GetEnclosingBoundingBox(boundingBoxes);
        }

        internal Vector3 GetFaceCenter(int index, Cube.Face face)
        {
            if (!cubes.IndexInRange(index))
                throw new IndexOutOfRangeException();

            Vector3 faceCenter = cubes[index] is CubeMesh c ? c.GetCube().GetFaceCenter(face) : Vector3.Zero;
            return Vector3.TransformPosition(faceCenter, GetTransform());
        }

        internal void SetVisible(int index, bool visible)
        {
            if (!cubes.IndexInRange(index))
                throw new IndexOutOfRangeException();
            if (cubes[index].Visible == visible)
                return;
            cubes[index] = cubes[index].SetVisible(visible) as CubeMesh;
        }

        public void Add(GenericMesh<TextureVertex> item) => cubes.Add(item);

        public void Clear()
        {
            subCollection.Clear();
            cubes.Clear();
        }

        public bool Contains(GenericMesh<TextureVertex> item)
        {
            return cubes.Any(c => c.Name == item.Name);
        }

        public bool ContainsCollection(string collectionName) => subCollection.ContainsKey(key: collectionName);

        public bool Contains(GenericMesh<TextureVertex> item, bool searchSubCollections)
        {
            return cubes.Any(c => c.Name == item.Name) || (searchSubCollections && subCollection.Values.Any(collection => collection.Contains(item, searchSubCollections)));
        }

        public void CopyTo(GenericMesh<TextureVertex>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(GenericMesh<TextureVertex> item) => cubes.Remove(item);

        public IEnumerator<GenericMesh<TextureVertex>> GetEnumerator() => cubes.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
