﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL;

namespace PckStudio.Rendering
{
    internal class IndexBuffer : IDisposable
    {
        private int _id;
        private List<int> _indicies;

        public IndexBuffer(params int[] indecies)
        {
            _indicies = new List<int>(indecies);
        }

        /// <summary>
        /// Creates and attaches created index buffer
        /// </summary>
        /// <param name="indicies"></param>
        /// <returns></returns>
        public static IndexBuffer Create(params int[] indicies)
        {
            var ib = new IndexBuffer(indicies);
            ib.Attach();
            return ib;
        }

        public void Attach()
        {
            _id = GL.GenBuffer();
            Bind();
            GL.BufferData(BufferTarget.ElementArrayBuffer, _indicies.Count * sizeof(int), _indicies.ToArray(), BufferUsageHint.StaticDraw);
            Unbind();
        }

        public int GetCount() => _indicies.Count;

        public void Bind()
        {
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, _id);
        }

        [Conditional("DEBUG")]
        public void Unbind()
        {
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, 0);
        }

        public void Dispose()
        {
            Unbind();
            GL.DeleteBuffer(_id);
        }
    }
}
