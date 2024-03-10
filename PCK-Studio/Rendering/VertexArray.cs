﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL;
using PckStudio.Extensions;

namespace PckStudio.Rendering
{
    internal class VertexArray : IDisposable
    {
        private int _id;
        private List<VertexBuffer> _vertexBuffers;

        public VertexArray()
        {
            _id = GL.GenVertexArray();
            _vertexBuffers = new List<VertexBuffer>();
        }

        public int AddNewBuffer(VertexBufferLayout layout) => AddBuffer(new VertexBuffer(), layout);

        public int AddBuffer(VertexBuffer buffer, VertexBufferLayout layout)
        {
            Bind();
            buffer.Bind();
            var elements = layout.GetElements();
            int offset = 0;
            int _vertexBufferIndex = 0;
            foreach (var element in elements)
            {
                Debug.Assert(element.Size > 0);
                switch (element.Type)
                {
                    case ShaderDataType.Float:
                    case ShaderDataType.Float2:
                    case ShaderDataType.Float3:
                    case ShaderDataType.Float4:
                        GL.EnableVertexAttribArray(_vertexBufferIndex);
                        GL.VertexAttribPointer(_vertexBufferIndex, element.ComponentCount, VertexAttribPointerType.Float, element.Normalize, layout.GetStride(), offset);
                        _vertexBufferIndex += 1;
                        break;
                    case ShaderDataType.Int:
                    case ShaderDataType.Int2:
                    case ShaderDataType.Int3:
                    case ShaderDataType.Int4:
                        GL.EnableVertexAttribArray(_vertexBufferIndex);
                        GL.VertexAttribIPointer(_vertexBufferIndex, element.ComponentCount, VertexAttribIntegerType.Int, layout.GetStride(), new IntPtr(offset));
                        _vertexBufferIndex += 1;
                        break;
                    case ShaderDataType.Mat2:
                    case ShaderDataType.Mat3:
                    case ShaderDataType.Mat4:
                        {
                            int count = element.ComponentCount;
                            for (int i = 0; i < count; i++)
                            {
                                GL.EnableVertexAttribArray(_vertexBufferIndex);

                                GL.VertexAttribPointer(_vertexBufferIndex, count, VertexAttribPointerType.Float, element.Normalize, layout.GetStride(), offset + count * i);

                                GL.VertexAttribDivisor(_vertexBufferIndex, 1);
                                _vertexBufferIndex += 1;
                            }
                        }
                        break;
                    default:
                        break;
                }
                offset += element.Size;
            }
            int index = _vertexBuffers.Count;
            _vertexBuffers.Add(buffer);
            return index;
        }

        public void Bind()
        {
            GL.BindVertexArray(_id);
        }

        public void Unbind()
        {
            GL.BindVertexArray(0);
        }

        public void Dispose()
        {
            Unbind();
            Clear();
            GL.DeleteVertexArray(_id);
        }

        internal void Clear()
        {
            foreach (var vao in _vertexBuffers)
            {
                vao.Dispose();
            }
            _vertexBuffers.Clear();
        }

        internal void SelectBuffer(int index)
        {
            if (!_vertexBuffers.IndexInRange(index))
                throw new IndexOutOfRangeException(index.ToString());
            Bind();
            GetBuffer(index).Bind();
        }

        internal VertexBuffer GetBuffer(int index)
        {
            if (_vertexBuffers.IndexInRange(index))
                return _vertexBuffers[index];
            throw new IndexOutOfRangeException(index.ToString());
        }
    }
}
