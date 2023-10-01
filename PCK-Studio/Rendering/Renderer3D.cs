﻿/*
 * 
 *The MIT License (MIT)

Copyright (c) 2016 Kareem Morsy

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
https://github.com/KareemMAX/Minecraft-Skiner
https://github.com/KareemMAX/Minecraft-Skiner/blob/master/src/Minecraft%20skiner/UserControls/Renderer3D.vb
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Windows.Forms;
using PckStudio.Classes.Utils;
using Microsoft.VisualBasic;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.Diagnostics;
using PckStudio.Properties;

namespace PckStudio.Rendering
{

    public partial class Renderer3D : GLControl
    {
        //private Bitmap _Skin;
        /// <summary>
        /// The visible skin on the renderer
        /// </summary>
        /// <returns>The visible skin</returns>
        [Description("The current skin")]
        [Category("Appearance")]
        public Bitmap Texture { get; set; }

        private bool _showhead = true;
        /// <summary>
        /// Show the head or not
        /// </summary>
        /// <returns>Show the head or not</returns>
        [Description("Shows the head layer or not")]
        [Category("Appearance")]
        public bool ShowHead
        {
            set
            {
                Refresh();
                _showhead = value;
            }
            get
            {
                return _showhead;
            }
        }
        private bool _showHeadOverlay = true;
        /// <summary>
        /// Show the second head layer or not
        /// </summary>
        /// <returns>Show the second head layer or not</returns>
        [Description("Shows the second head layer or not")]
        [Category("Appearance")]
        public bool ShowHeadOverlay
        {
            set
            {
                Refresh();
                _showHeadOverlay = value;
            }
            get
            {
                return _showHeadOverlay;
            }
        }
        private bool _showbody = true;
        /// <summary>
        /// Show the body or not
        /// </summary>
        /// <returns>Show the body or not</returns>
        [Description("Shows the body layer or not")]
        [Category("Appearance")]
        public bool ShowBody
        {
            set
            {
                Refresh();
                _showbody = value;
            }
            get
            {
                return _showbody;
            }
        }
        private bool _showBodyOverlay = true;
        /// <summary>
        /// Show the second body layer or not
        /// </summary>
        /// <returns>Show the second body layer or not</returns>
        [Description("Shows the second body layer or not")]
        [Category("Appearance")]
        public bool ShowBodyOverlay
        {
            set
            {
                Refresh();
                _showBodyOverlay = value;
            }
            get
            {
                return _showBodyOverlay;
            }
        }
        private bool _showRightArm = true;
        /// <summary>
        /// Show the right arm or not
        /// </summary>
        /// <returns>Show the right arm or not</returns>
        [Description("Shows the right arm layer or not")]
        [Category("Appearance")]
        public bool ShowRightArm
        {
            set
            {
                Refresh();
                _showRightArm = value;
            }
            get
            {
                return _showRightArm;
            }
        }
        private bool _showRightArmOverlay = true;
        /// <summary>
        /// Show the second right arm layer or not
        /// </summary>
        /// <returns>Show the second right arm layer or not</returns>
        [Description("Shows the second right arm layer or not")]
        [Category("Appearance")]
        public bool ShowRightArmOverlay
        {
            set
            {
                Refresh();
                _showRightArmOverlay = value;
            }
            get
            {
                return _showRightArmOverlay;
            }
        }
        private bool _showLeftArm = true;
        /// <summary>
        /// Show the left arm or not
        /// </summary>
        /// <returns>Show the leftht arm or not</returns>
        [Description("Shows the left arm layer or not")]
        [Category("Appearance")]
        public bool ShowLeftArm
        {
            set
            {
                Refresh();
                _showLeftArm = value;
            }
            get
            {
                return _showLeftArm;
            }
        }
        private bool _showLeftArmOverlay = true;
        /// <summary>
        /// Show the second left arm layer or not
        /// </summary>
        /// <returns>Show the second left arm layer or not</returns>
        [Description("Shows the second left arm layer or not")]
        [Category("Appearance")]
        public bool ShowLeftArmOverlay
        {
            set
            {
                Refresh();
                _showLeftArmOverlay = value;
            }
            get
            {
                return _showLeftArmOverlay;
            }
        }
        private bool _showRightLeg = true;
        /// <summary>
        /// Show the right leg or not
        /// </summary>
        /// <returns>Show the right leg or not</returns>
        [Description("Shows the right leg layer or not")]
        [Category("Appearance")]
        public bool ShowRightLeg
        {
            set
            {
                Refresh();
                _showRightLeg = value;
            }
            get
            {
                return _showRightLeg;
            }
        }
        private bool _showRightLegOverlay = true;
        /// <summary>
        /// Show the second right leg layer or not
        /// </summary>
        /// <returns>Show the second right leg layer or not</returns>
        [Description("Shows the second right leg layer or not")]
        [Category("Appearance")]
        public bool ShowRightLegOverlay
        {
            set
            {
                Refresh();
                _showRightLegOverlay = value;
            }
            get
            {
                return _showRightLegOverlay;
            }
        }
        private bool _showLeftLeg = true;
        /// <summary>
        /// Show the left leg or not
        /// </summary>
        /// <returns>Show the leftht leg or not</returns>
        [Description("Shows the left leg layer or not")]
        [Category("Appearance")]
        public bool ShowLeftLeg
        {
            set
            {
                Refresh();
                _showLeftLeg = value;
            }
            get
            {
                return _showLeftLeg;
            }
        }
        private bool _showLeftLegOverlay = true;
        /// <summary>
        /// Show the second left leg layer or not
        /// </summary>
        /// <returns>Show the second left leg layer or not</returns>
        [Description("Shows the second left leg layer or not")]
        [Category("Appearance")]
        public bool ShowLeftLegOverlay
        {
            set
            {
                Refresh();
                _showLeftLegOverlay = value;
            }
            get
            {
                return _showLeftLegOverlay;
            }
        }


        public enum Models
        {
            Steve,
            Alex
        }
        /// <summary>
        /// The rendered model
        /// </summary>
        /// <returns>The rendered model</returns>
        [Description("The current player model")]
        [Category("Appearance")]
        public Models Model { get; set; }

        /// <summary>
        /// X rotation
        /// </summary>
        /// <returns>X rotattion</returns>
        [Description("The X rotation of the model")]
        [Category("Appearance")]
        public int RotationX { get; set; }

        /// <summary>
        /// Y rotation
        /// </summary>
        /// <returns>Y rotation</returns>
        [Description("The Y rotation of the model")]
        [Category("Appearance")]
        public int RotationY { get; set; }

        private double _Zoom = MinZoomLevel;
        private const double MinZoomLevel = 1d;
        private const double MaxZoomLevel = 10d;

        [Description("The zoom value")]
        [Category("Appearance")]
        public double Zoom
        {
            get => _Zoom;
            set => _Zoom = MathHelper.Clamp(value, MinZoomLevel, MaxZoomLevel);
        }

        private PointF _lookAngle = PointF.Empty;

        [Description("The offset from the orignal point (for zoom)")]
        [Category("Appearance")]
        public PointF LookAngle
        {
            get => _lookAngle;
            set
            {
                if (value.X < -8f)
                {
                    value.X = -8f;
                }
                else if (value.X > 8f)
                {
                    value.X = 8f;
                }

                if (value.Y < -16f)
                {
                    value.Y = -16f;
                }
                else if (value.Y > 16f)
                {
                    value.Y = 16f;
                }

                _lookAngle = value;
            }
        }

        private Matrix4 perspective; // Perspective
        private Matrix4 camera; // Camera

        private const double TexVal = 1d / 64d;

        public Renderer3D()
        {
            InitializeComponent();
            UpdateCamera();
            UpdatePerspective();
            //MakeCurrent();
            //int program = CreateShader(Resources.vertexShader, Resources.fragment);
        }

        private void UpdateCamera()
        {
            camera = Matrix4.LookAt(LookAngle.X, LookAngle.Y, 72f, LookAngle.X, LookAngle.Y, 0f, 0f, 1f, 1f);
        }

        private void UpdatePerspective()
        {
            perspective = Matrix4.CreatePerspectiveFieldOfView((float)Math.Pow(Zoom, -1), (float)(Width / (double)Height), 0.1f, 1000f);
        }

        // Only call when a context is present
        private static void DrawBox(Image texture, Vector3 size, float X, float Y, float Z, float uvX, float uvY)
        {
            float[] Corner1 = { X, Y, Z };
            float[] Corner2 = { X + size.X, Y, Z };
            float[] Corner3 = { X, Y + size.Y, Z };
            float[] Corner4 = { X, Y, Z + size.Z };
            float[] Corner5 = { X + size.X, Y + size.Y, Z };
            float[] Corner6 = { X, Y + size.Y, Z + size.Z };
            float[] Corner7 = { X + size.X, Y, Z + size.Z };
            float[] Corner8 = { X + size.X, Y + size.Y, Z + size.Z };

            GL.Color3(Color.Red);
            // Face 1
            GL.Vertex3(Corner1);
            GL.Vertex3(Corner3);
            GL.Vertex3(Corner5);
            GL.Vertex3(Corner2);
            // Face 2
            GL.Vertex3(Corner1);
            GL.Vertex3(Corner4);
            GL.Vertex3(Corner7);
            GL.Vertex3(Corner2);
            // Face 3
            GL.Vertex3(Corner1);
            GL.Vertex3(Corner4);
            GL.Vertex3(Corner6);
            GL.Vertex3(Corner3);
            // Face 4
            GL.TexCoord2(uvX, TexVal * 8d);
            GL.Vertex3(Corner4);
            GL.TexCoord2(TexVal * 16d, TexVal * 8d);
            GL.Vertex3(Corner7);
            GL.TexCoord2(TexVal * 16d, TexVal * 16d);
            GL.Vertex3(Corner8);
            GL.TexCoord2(TexVal * 8d, TexVal * 16d);
            GL.Vertex3(Corner6);
            // Face 5
            GL.Vertex3(Corner8);
            GL.Vertex3(Corner6);
            GL.Vertex3(Corner3);
            GL.Vertex3(Corner5);
            // Face 6
            GL.Vertex3(Corner2);
            GL.Vertex3(Corner7);
            GL.Vertex3(Corner8);
            GL.Vertex3(Corner5);
        }


        private static int CompileShader(ShaderType type, string shaderSource)
        {
            int shaderId = GL.CreateShader(type);
            GL.ShaderSource(shaderId, shaderSource);
            GL.CompileShader(shaderId);

            GL.GetShader(shaderId, ShaderParameter.CompileStatus, out int status);

            if (status == 0)
            { 
                GL.GetShader(shaderId, ShaderParameter.InfoLogLength, out int length);
                GL.GetShaderInfoLog(shaderId, length, out length, out string infoLog);
                Trace.TraceError(infoLog);
                GL.DeleteShader(shaderId);
                return 0;
            }
            return shaderId;
        }

        private static int CreateShader(string vertexSource, string fragmentSource)
        {
            int programId = GL.CreateProgram();
            
            int vertexShader = CompileShader(ShaderType.VertexShader, vertexSource);
            int fragmentShader = CompileShader(ShaderType.FragmentShader, fragmentSource);

            GL.AttachShader(programId, vertexShader);
            GL.AttachShader(programId, fragmentShader);
            
            GL.LinkProgram(programId);
            GL.ValidateProgram(programId);

            GL.DeleteShader(vertexShader);
            GL.DeleteShader(fragmentShader);
            return programId;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (DesignMode)
                return;
            //base.OnPaint(e);

            MakeCurrent();
#if DEBUG
            debugLabel.Text = $"Rotation: {RotationX}, {RotationY}\nZoom: {_Zoom}\nLookAt:\n{camera}\nPerspective:\n{perspective}";
#endif

            GL.PushMatrix();

            GL.ClearColor(BackColor);
            // First Clear Buffers
            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.Clear(ClearBufferMask.DepthBufferBit);

            // Basic Setup for viewing
            UpdatePerspective();
            UpdateCamera();
            GL.MatrixMode(MatrixMode.Projection); // Load Perspective
            GL.LoadIdentity();
            GL.LoadMatrix(ref perspective);
            GL.MatrixMode(MatrixMode.Modelview); // Load Camera
            GL.LoadIdentity();
            GL.LoadMatrix(ref camera);
            GL.Viewport(0, 0, Width, Height); // Size of window
            GL.Enable(EnableCap.DepthTest); // Enable correct Z Drawings
            GL.Enable(EnableCap.Texture2D); // Enable textures
            GL.DepthFunc(DepthFunction.Less); // Enable correct Z Drawings
                                              // GL.Disable(EnableCap.Blend) 'Disable transparent
            GL.Disable(EnableCap.AlphaTest); // Disable transparent

            // Load the textures
            int texID = GL.GenTexture();
            GL.BindTexture(TextureTarget.Texture2D, texID);
            var data = Texture.LockBits(new Rectangle(0, 0, 64, 64), ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);

            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, 64, 64, 0, OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, data.Scan0);
            Texture.UnlockBits(data);
            GL.GenerateMipmap(GenerateMipmapTarget.Texture2D);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Nearest);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Nearest);

            // Rotating
            GL.Rotate(RotationX, -1, 0f, 0f);
            GL.Rotate(RotationY, 0f, 1f, 0f);

            GL.BindTexture(TextureTarget.ProxyTexture2D, texID);
            // Vertex goes (X,Y,Z)
            GL.Begin(PrimitiveType.Quads);
            // Body

            
            if (ShowBody)
            {
                // Face 1
                GL.TexCoord2(TexVal * 20d, TexVal * 20d);
                GL.Vertex3(-4, 8, 2);
                GL.TexCoord2(TexVal * 28d, TexVal * 20d);
                GL.Vertex3(4, 8, 2);
                GL.TexCoord2(TexVal * 28d, TexVal * 32d);
                GL.Vertex3(4, -4, 2);
                GL.TexCoord2(TexVal * 20d, TexVal * 32d);
                GL.Vertex3(-4, -4, 2);
                // Face 2
                GL.TexCoord2(TexVal * 40d, TexVal * 20d);
                GL.Vertex3(-4, 8, -2);
                GL.TexCoord2(TexVal * 32d, TexVal * 20d);
                GL.Vertex3(4, 8, -2);
                GL.TexCoord2(TexVal * 32d, TexVal * 32d);
                GL.Vertex3(4, -4, -2);
                GL.TexCoord2(TexVal * 40d, TexVal * 32d);
                GL.Vertex3(-4, -4, -2);
                // Face 3
                GL.TexCoord2(TexVal * 20d, TexVal * 20d);
                GL.Vertex3(-4, 8, 2);
                GL.TexCoord2(TexVal * 16d, TexVal * 20d);
                GL.Vertex3(-4, 8, -2);
                GL.TexCoord2(TexVal * 16d, TexVal * 32d);
                GL.Vertex3(-4, -4, -2);
                GL.TexCoord2(TexVal * 20d, TexVal * 32d);
                GL.Vertex3(-4, -4, 2);
                // Face 4
                GL.TexCoord2(TexVal * 28d, TexVal * 20d);
                GL.Vertex3(4, 8, 2);
                GL.TexCoord2(TexVal * 32d, TexVal * 20d);
                GL.Vertex3(4, 8, -2);
                GL.TexCoord2(TexVal * 32d, TexVal * 32d);
                GL.Vertex3(4, -4, -2);
                GL.TexCoord2(TexVal * 28d, TexVal * 32d);
                GL.Vertex3(4, -4, 2);
                // Face 5
                GL.TexCoord2(TexVal * 20d, TexVal * 20d);
                GL.Vertex3(-4, 8, 2);
                GL.TexCoord2(TexVal * 28d, TexVal * 20d);
                GL.Vertex3(4, 8, 2);
                GL.TexCoord2(TexVal * 28d, TexVal * 16d);
                GL.Vertex3(4, 8, -2);
                GL.TexCoord2(TexVal * 20d, TexVal * 16d);
                GL.Vertex3(-4, 8, -2);
                // Face 6
                GL.TexCoord2(TexVal * 28d, TexVal * 16d);
                GL.Vertex3(-4, -4, -2);
                GL.TexCoord2(TexVal * 36d, TexVal * 16d);
                GL.Vertex3(4, -4, -2);
                GL.TexCoord2(TexVal * 36d, TexVal * 20d);
                GL.Vertex3(4, -4, 2);
                GL.TexCoord2(TexVal * 28d, TexVal * 20d);
                GL.Vertex3(-4, -4, 2);
            }

            if (ShowHead)
            {
                // Head
                // Face 1
                GL.TexCoord2(TexVal * 8d, TexVal * 8d);
                GL.Vertex3(-4, 16, 4);
                GL.TexCoord2(TexVal * 16d, TexVal * 8d);
                GL.Vertex3(4, 16, 4);
                GL.TexCoord2(TexVal * 16d, TexVal * 16d);
                GL.Vertex3(4, 8, 4);
                GL.TexCoord2(TexVal * 8d, TexVal * 16d);
                GL.Vertex3(-4, 8, 4);
                // Face 2
                GL.TexCoord2(TexVal * 32d, TexVal * 8d);
                GL.Vertex3(-4, 16, -4);
                GL.TexCoord2(TexVal * 24d, TexVal * 8d);
                GL.Vertex3(4, 16, -4);
                GL.TexCoord2(TexVal * 24d, TexVal * 16d);
                GL.Vertex3(4, 8, -4);
                GL.TexCoord2(TexVal * 32d, TexVal * 16d);
                GL.Vertex3(-4, 8, -4);
                // Face 3
                GL.TexCoord2(TexVal * 8d, TexVal * 8d);
                GL.Vertex3(-4, 16, 4);
                GL.TexCoord2(TexVal * 0d, TexVal * 8d);
                GL.Vertex3(-4, 16, -4);
                GL.TexCoord2(TexVal * 0d, TexVal * 16d);
                GL.Vertex3(-4, 8, -4);
                GL.TexCoord2(TexVal * 8d, TexVal * 16d);
                GL.Vertex3(-4, 8, 4);
                // Face 4
                GL.TexCoord2(TexVal * 16d, TexVal * 8d);
                GL.Vertex3(4, 16, 4);
                GL.TexCoord2(TexVal * 24d, TexVal * 8d);
                GL.Vertex3(4, 16, -4);
                GL.TexCoord2(TexVal * 24d, TexVal * 16d);
                GL.Vertex3(4, 8, -4);
                GL.TexCoord2(TexVal * 16d, TexVal * 16d);
                GL.Vertex3(4, 8, 4);
                // Face 5
                GL.TexCoord2(TexVal * 8d, TexVal * 8d);
                GL.Vertex3(-4, 16, 4);
                GL.TexCoord2(TexVal * 16d, TexVal * 8d);
                GL.Vertex3(4, 16, 4);
                GL.TexCoord2(TexVal * 16d, TexVal * 0d);
                GL.Vertex3(4, 16, -4);
                GL.TexCoord2(TexVal * 8d, TexVal * 0d);
                GL.Vertex3(-4, 16, -4);
                // Face 6
                GL.TexCoord2(TexVal * 16d, TexVal * 8d);
                GL.Vertex3(-4, 8, 4);
                GL.TexCoord2(TexVal * 24d, TexVal * 8d);
                GL.Vertex3(4, 8, 4);
                GL.TexCoord2(TexVal * 24d, TexVal * 0d);
                GL.Vertex3(4, 8, -4);
                GL.TexCoord2(TexVal * 16d, TexVal * 0d);
                GL.Vertex3(-4, 8, -4);
            }

            if (Model == Models.Steve)
            {

                if (ShowLeftArm)
                {
                    // LefttArm
                    // Face 1
                    GL.TexCoord2(TexVal * 36d, TexVal * 52d);
                    GL.Vertex3(4, 8, 2);
                    GL.TexCoord2(TexVal * 40d, TexVal * 52d);
                    GL.Vertex3(8, 8, 2);
                    GL.TexCoord2(TexVal * 40d, TexVal * 64d);
                    GL.Vertex3(8, -4, 2);
                    GL.TexCoord2(TexVal * 36d, TexVal * 64d);
                    GL.Vertex3(4, -4, 2);
                    // Face 2
                    GL.TexCoord2(TexVal * 48d, TexVal * 52d);
                    GL.Vertex3(4, 8, -2);
                    GL.TexCoord2(TexVal * 44d, TexVal * 52d);
                    GL.Vertex3(8, 8, -2);
                    GL.TexCoord2(TexVal * 44d, TexVal * 64d);
                    GL.Vertex3(8, -4, -2);
                    GL.TexCoord2(TexVal * 48d, TexVal * 64d);
                    GL.Vertex3(4, -4, -2);
                    // Face 3
                    GL.TexCoord2(TexVal * 32d, TexVal * 52d);
                    GL.Vertex3(4, 8, -2);
                    GL.TexCoord2(TexVal * 36d, TexVal * 52d);
                    GL.Vertex3(4, 8, 2);
                    GL.TexCoord2(TexVal * 36d, TexVal * 64d);
                    GL.Vertex3(4, -4, 2);
                    GL.TexCoord2(TexVal * 32d, TexVal * 64d);
                    GL.Vertex3(4, -4, -2);
                    // Face 4
                    GL.TexCoord2(TexVal * 44d, TexVal * 52d);
                    GL.Vertex3(8, 8, -2);
                    GL.TexCoord2(TexVal * 40d, TexVal * 52d);
                    GL.Vertex3(8, 8, 2);
                    GL.TexCoord2(TexVal * 40d, TexVal * 64d);
                    GL.Vertex3(8, -4, 2);
                    GL.TexCoord2(TexVal * 44d, TexVal * 64d);
                    GL.Vertex3(8, -4, -2);
                    // Face 5
                    GL.TexCoord2(TexVal * 36d, TexVal * 52d);
                    GL.Vertex3(4, 8, 2);
                    GL.TexCoord2(TexVal * 40d, TexVal * 52d);
                    GL.Vertex3(8, 8, 2);
                    GL.TexCoord2(TexVal * 40d, TexVal * 48d);
                    GL.Vertex3(8, 8, -2);
                    GL.TexCoord2(TexVal * 36d, TexVal * 48d);
                    GL.Vertex3(4, 8, -2);
                    // Face 6
                    GL.TexCoord2(TexVal * 40d, TexVal * 52d);
                    GL.Vertex3(4, -4, 2);
                    GL.TexCoord2(TexVal * 44d, TexVal * 52d);
                    GL.Vertex3(8, -4, 2);
                    GL.TexCoord2(TexVal * 44d, TexVal * 48d);
                    GL.Vertex3(8, -4, -2);
                    GL.TexCoord2(TexVal * 40d, TexVal * 48d);
                    GL.Vertex3(4, -4, -2);
                }

                if (ShowRightArm)
                {
                    // RightArm
                    // Face 1
                    GL.TexCoord2(TexVal * 44d, TexVal * 20d);
                    GL.Vertex3(-8, 8, 2);
                    GL.TexCoord2(TexVal * 48d, TexVal * 20d);
                    GL.Vertex3(-4, 8, 2);
                    GL.TexCoord2(TexVal * 48d, TexVal * 32d);
                    GL.Vertex3(-4, -4, 2);
                    GL.TexCoord2(TexVal * 44d, TexVal * 32d);
                    GL.Vertex3(-8, -4, 2);
                    // Face 2
                    GL.TexCoord2(TexVal * 56d, TexVal * 20d);
                    GL.Vertex3(-8, 8, -2);
                    GL.TexCoord2(TexVal * 52d, TexVal * 20d);
                    GL.Vertex3(-4, 8, -2);
                    GL.TexCoord2(TexVal * 52d, TexVal * 32d);
                    GL.Vertex3(-4, -4, -2);
                    GL.TexCoord2(TexVal * 56d, TexVal * 32d);
                    GL.Vertex3(-8, -4, -2);
                    // Face 3
                    GL.TexCoord2(TexVal * 40d, TexVal * 20d);
                    GL.Vertex3(-8, 8, -2);
                    GL.TexCoord2(TexVal * 44d, TexVal * 20d);
                    GL.Vertex3(-8, 8, 2);
                    GL.TexCoord2(TexVal * 44d, TexVal * 32d);
                    GL.Vertex3(-8, -4, 2);
                    GL.TexCoord2(TexVal * 40d, TexVal * 32d);
                    GL.Vertex3(-8, -4, -2);
                    // Face 4
                    GL.TexCoord2(TexVal * 52d, TexVal * 20d);
                    GL.Vertex3(-4, 8, -2);
                    GL.TexCoord2(TexVal * 48d, TexVal * 20d);
                    GL.Vertex3(-4, 8, 2);
                    GL.TexCoord2(TexVal * 48d, TexVal * 32d);
                    GL.Vertex3(-4, -4, 2);
                    GL.TexCoord2(TexVal * 52d, TexVal * 32d);
                    GL.Vertex3(-4, -4, -2);
                    // Face 5
                    GL.TexCoord2(TexVal * 44d, TexVal * 20d);
                    GL.Vertex3(-8, 8, 2);
                    GL.TexCoord2(TexVal * 48d, TexVal * 20d);
                    GL.Vertex3(-4, 8, 2);
                    GL.TexCoord2(TexVal * 48d, TexVal * 16d);
                    GL.Vertex3(-4, 8, -2);
                    GL.TexCoord2(TexVal * 44d, TexVal * 16d);
                    GL.Vertex3(-8, 8, -2);
                    // Face 6
                    GL.TexCoord2(TexVal * 48d, TexVal * 20d);
                    GL.Vertex3(-8, -4, 2);
                    GL.TexCoord2(TexVal * 52d, TexVal * 20d);
                    GL.Vertex3(-4, -4, 2);
                    GL.TexCoord2(TexVal * 52d, TexVal * 16d);
                    GL.Vertex3(-4, -4, -2);
                    GL.TexCoord2(TexVal * 48d, TexVal * 16d);
                    GL.Vertex3(-8, -4, -2);
                }
            }

            else
            {

                if (ShowLeftArm)
                {
                    // LefttArm
                    // Face 1
                    GL.TexCoord2(TexVal * 36d, TexVal * 52d);
                    GL.Vertex3(4, 8, 2);
                    GL.TexCoord2(TexVal * 39d, TexVal * 52d);
                    GL.Vertex3(7, 8, 2);
                    GL.TexCoord2(TexVal * 39d, TexVal * 64d);
                    GL.Vertex3(7, -4, 2);
                    GL.TexCoord2(TexVal * 36d, TexVal * 64d);
                    GL.Vertex3(4, -4, 2);
                    // Face 2
                    GL.TexCoord2(TexVal * 46d, TexVal * 52d);
                    GL.Vertex3(4, 8, -2);
                    GL.TexCoord2(TexVal * 43d, TexVal * 52d);
                    GL.Vertex3(7, 8, -2);
                    GL.TexCoord2(TexVal * 43d, TexVal * 64d);
                    GL.Vertex3(7, -4, -2);
                    GL.TexCoord2(TexVal * 46d, TexVal * 64d);
                    GL.Vertex3(4, -4, -2);
                    // Face 3
                    GL.TexCoord2(TexVal * 32d, TexVal * 52d);
                    GL.Vertex3(4, 8, -2);
                    GL.TexCoord2(TexVal * 36d, TexVal * 52d);
                    GL.Vertex3(4, 8, 2);
                    GL.TexCoord2(TexVal * 36d, TexVal * 64d);
                    GL.Vertex3(4, -4, 2);
                    GL.TexCoord2(TexVal * 32d, TexVal * 64d);
                    GL.Vertex3(4, -4, -2);
                    // Face 4
                    GL.TexCoord2(TexVal * 43d, TexVal * 52d);
                    GL.Vertex3(7, 8, -2);
                    GL.TexCoord2(TexVal * 39d, TexVal * 52d);
                    GL.Vertex3(7, 8, 2);
                    GL.TexCoord2(TexVal * 39d, TexVal * 64d);
                    GL.Vertex3(7, -4, 2);
                    GL.TexCoord2(TexVal * 43d, TexVal * 64d);
                    GL.Vertex3(7, -4, -2);
                    // Face 5
                    GL.TexCoord2(TexVal * 36d, TexVal * 52d);
                    GL.Vertex3(4, 8, 2);
                    GL.TexCoord2(TexVal * 39d, TexVal * 52d);
                    GL.Vertex3(7, 8, 2);
                    GL.TexCoord2(TexVal * 39d, TexVal * 48d);
                    GL.Vertex3(7, 8, -2);
                    GL.TexCoord2(TexVal * 36d, TexVal * 48d);
                    GL.Vertex3(4, 8, -2);
                    // Face 6
                    GL.TexCoord2(TexVal * 39d, TexVal * 52d);
                    GL.Vertex3(4, -4, 2);
                    GL.TexCoord2(TexVal * 42d, TexVal * 52d);
                    GL.Vertex3(7, -4, 2);
                    GL.TexCoord2(TexVal * 42d, TexVal * 48d);
                    GL.Vertex3(7, -4, -2);
                    GL.TexCoord2(TexVal * 39d, TexVal * 48d);
                    GL.Vertex3(4, -4, -2);
                }

                if (ShowRightArm)
                {
                    // RightArm
                    // Face 1
                    GL.TexCoord2(TexVal * 44d, TexVal * 20d);
                    GL.Vertex3(-7, 8, 2);
                    GL.TexCoord2(TexVal * 47d, TexVal * 20d);
                    GL.Vertex3(-4, 8, 2);
                    GL.TexCoord2(TexVal * 47d, TexVal * 32d);
                    GL.Vertex3(-4, -4, 2);
                    GL.TexCoord2(TexVal * 44d, TexVal * 32d);
                    GL.Vertex3(-7, -4, 2);
                    // Face 2
                    GL.TexCoord2(TexVal * 54d, TexVal * 20d);
                    GL.Vertex3(-7, 8, -2);
                    GL.TexCoord2(TexVal * 51d, TexVal * 20d);
                    GL.Vertex3(-4, 8, -2);
                    GL.TexCoord2(TexVal * 51d, TexVal * 32d);
                    GL.Vertex3(-4, -4, -2);
                    GL.TexCoord2(TexVal * 54d, TexVal * 32d);
                    GL.Vertex3(-7, -4, -2);
                    // Face 3
                    GL.TexCoord2(TexVal * 40d, TexVal * 20d);
                    GL.Vertex3(-7, 8, -2);
                    GL.TexCoord2(TexVal * 44d, TexVal * 20d);
                    GL.Vertex3(-7, 8, 2);
                    GL.TexCoord2(TexVal * 44d, TexVal * 32d);
                    GL.Vertex3(-7, -4, 2);
                    GL.TexCoord2(TexVal * 40d, TexVal * 32d);
                    GL.Vertex3(-7, -4, -2);
                    // Face 4
                    GL.TexCoord2(TexVal * 51d, TexVal * 20d);
                    GL.Vertex3(-4, 8, -2);
                    GL.TexCoord2(TexVal * 47d, TexVal * 20d);
                    GL.Vertex3(-4, 8, 2);
                    GL.TexCoord2(TexVal * 47d, TexVal * 32d);
                    GL.Vertex3(-4, -4, 2);
                    GL.TexCoord2(TexVal * 51d, TexVal * 32d);
                    GL.Vertex3(-4, -4, -2);
                    // Face 5
                    GL.TexCoord2(TexVal * 44d, TexVal * 20d);
                    GL.Vertex3(-7, 8, 2);
                    GL.TexCoord2(TexVal * 47d, TexVal * 20d);
                    GL.Vertex3(-4, 8, 2);
                    GL.TexCoord2(TexVal * 47d, TexVal * 16d);
                    GL.Vertex3(-4, 8, -2);
                    GL.TexCoord2(TexVal * 44d, TexVal * 16d);
                    GL.Vertex3(-7, 8, -2);
                    // Face 6
                    GL.TexCoord2(TexVal * 47d, TexVal * 20d);
                    GL.Vertex3(-7, -4, 2);
                    GL.TexCoord2(TexVal * 50d, TexVal * 20d);
                    GL.Vertex3(-4, -4, 2);
                    GL.TexCoord2(TexVal * 50d, TexVal * 16d);
                    GL.Vertex3(-4, -4, -2);
                    GL.TexCoord2(TexVal * 47d, TexVal * 16d);
                    GL.Vertex3(-7, -4, -2);
                }

            }

            if (ShowRightLeg)
            {
                // RightLeg
                // Face 1
                GL.TexCoord2(TexVal * 4d, TexVal * 20d);
                GL.Vertex3(-4, -4, 2);
                GL.TexCoord2(TexVal * 8d, TexVal * 20d);
                GL.Vertex3(0, -4, 2);
                GL.TexCoord2(TexVal * 8d, TexVal * 32d);
                GL.Vertex3(0, -16, 2);
                GL.TexCoord2(TexVal * 4d, TexVal * 32d);
                GL.Vertex3(-4, -16, 2);
                // Face 2
                GL.TexCoord2(TexVal * 16d, TexVal * 20d);
                GL.Vertex3(-4, -4, -2);
                GL.TexCoord2(TexVal * 12d, TexVal * 20d);
                GL.Vertex3(0, -4, -2);
                GL.TexCoord2(TexVal * 12d, TexVal * 32d);
                GL.Vertex3(0, -16, -2);
                GL.TexCoord2(TexVal * 16d, TexVal * 32d);
                GL.Vertex3(-4, -16, -2);
                // Face 3
                GL.TexCoord2(TexVal * 4d, TexVal * 20d);
                GL.Vertex3(-4, -4, 2);
                GL.TexCoord2(TexVal * 0d, TexVal * 20d);
                GL.Vertex3(-4, -4, -2);
                GL.TexCoord2(TexVal * 0d, TexVal * 32d);
                GL.Vertex3(-4, -16, -2);
                GL.TexCoord2(TexVal * 4d, TexVal * 32d);
                GL.Vertex3(-4, -16, 2);
                // Face 4
                GL.TexCoord2(TexVal * 8d, TexVal * 20d);
                GL.Vertex3(0, -4, 2);
                GL.TexCoord2(TexVal * 12d, TexVal * 20d);
                GL.Vertex3(0, -4, -2);
                GL.TexCoord2(TexVal * 12d, TexVal * 32d);
                GL.Vertex3(0, -16, -2);
                GL.TexCoord2(TexVal * 8d, TexVal * 32d);
                GL.Vertex3(0, -16, 2);
                // Face 5
                GL.TexCoord2(TexVal * 4d, TexVal * 20d);
                GL.Vertex3(-4, -4, 2);
                GL.TexCoord2(TexVal * 8d, TexVal * 20d);
                GL.Vertex3(0, -4, 2);
                GL.TexCoord2(TexVal * 8d, TexVal * 16d);
                GL.Vertex3(0, -4, -2);
                GL.TexCoord2(TexVal * 4d, TexVal * 16d);
                GL.Vertex3(-4, -4, -2);
                // Face 6
                GL.TexCoord2(TexVal * 8d, TexVal * 20d);
                GL.Vertex3(-4, -16, 2);
                GL.TexCoord2(TexVal * 12d, TexVal * 20d);
                GL.Vertex3(0, -16, 2);
                GL.TexCoord2(TexVal * 12d, TexVal * 16d);
                GL.Vertex3(0, -16, -2);
                GL.TexCoord2(TexVal * 8d, TexVal * 16d);
                GL.Vertex3(-4, -16, -2);
            }

            if (ShowLeftLeg)
            {
                // LeftLeg
                // Face 1
                GL.TexCoord2(TexVal * 20d, TexVal * 52d);
                GL.Vertex3(0, -4, 2);
                GL.TexCoord2(TexVal * 24d, TexVal * 52d);
                GL.Vertex3(4, -4, 2);
                GL.TexCoord2(TexVal * 24d, TexVal * 64d);
                GL.Vertex3(4, -16, 2);
                GL.TexCoord2(TexVal * 20d, TexVal * 64d);
                GL.Vertex3(0, -16, 2);
                // Face 2
                GL.TexCoord2(TexVal * 32d, TexVal * 52d);
                GL.Vertex3(0, -4, -2);
                GL.TexCoord2(TexVal * 28d, TexVal * 52d);
                GL.Vertex3(4, -4, -2);
                GL.TexCoord2(TexVal * 28d, TexVal * 64d);
                GL.Vertex3(4, -16, -2);
                GL.TexCoord2(TexVal * 32d, TexVal * 64d);
                GL.Vertex3(0, -16, -2);
                // Face 3
                GL.TexCoord2(TexVal * 20d, TexVal * 52d);
                GL.Vertex3(0, -4, 2);
                GL.TexCoord2(TexVal * 16d, TexVal * 52d);
                GL.Vertex3(0, -4, -2);
                GL.TexCoord2(TexVal * 16d, TexVal * 64d);
                GL.Vertex3(0, -16, -2);
                GL.TexCoord2(TexVal * 20d, TexVal * 64d);
                GL.Vertex3(0, -16, 2);
                // Face 4
                GL.TexCoord2(TexVal * 24d, TexVal * 52d);
                GL.Vertex3(4, -4, 2);
                GL.TexCoord2(TexVal * 28d, TexVal * 52d);
                GL.Vertex3(4, -4, -2);
                GL.TexCoord2(TexVal * 28d, TexVal * 64d);
                GL.Vertex3(4, -16, -2);
                GL.TexCoord2(TexVal * 24d, TexVal * 64d);
                GL.Vertex3(4, -16, 2);
                // Face 5
                GL.TexCoord2(TexVal * 20d, TexVal * 52d);
                GL.Vertex3(0, -4, 2);
                GL.TexCoord2(TexVal * 24d, TexVal * 52d);
                GL.Vertex3(4, -4, 2);
                GL.TexCoord2(TexVal * 24d, TexVal * 48d);
                GL.Vertex3(4, -4, -2);
                GL.TexCoord2(TexVal * 20d, TexVal * 48d);
                GL.Vertex3(0, -4, -2);
                // Face 6
                GL.TexCoord2(TexVal * 24d, TexVal * 52d);
                GL.Vertex3(0, -16, 2);
                GL.TexCoord2(TexVal * 28d, TexVal * 52d);
                GL.Vertex3(4, -16, 2);
                GL.TexCoord2(TexVal * 28d, TexVal * 48d);
                GL.Vertex3(4, -16, -2);
                GL.TexCoord2(TexVal * 24d, TexVal * 48d);
                GL.Vertex3(0, -16, -2);
            }
            GL.End();

            GL.Enable(EnableCap.AlphaTest); // Enable transparent
            GL.AlphaFunc(AlphaFunction.Greater, 0.7f);
            //GL.Enable(EnableCap.Blend); // Enable transparent
            //GL.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.DstAlpha);

            GL.Begin(PrimitiveType.Quads);
            
            if (ShowBodyOverlay)
            {
                // Face 1
                GL.TexCoord2(TexVal * 20d, TexVal * 36d);
                GL.Vertex3(-4.24d, 8.36d, 2.12d);
                GL.TexCoord2(TexVal * 28d, TexVal * 36d);
                GL.Vertex3(4.24d, 8.36d, 2.12d);
                GL.TexCoord2(TexVal * 28d, TexVal * 48d);
                GL.Vertex3(4.24d, -4.36d, 2.12d);
                GL.TexCoord2(TexVal * 20d, TexVal * 48d);
                GL.Vertex3(-4.24d, -4.36d, 2.12d);
                // Face 2
                GL.TexCoord2(TexVal * 40d, TexVal * 36d);
                GL.Vertex3(-4.24d, 8.36d, -2.12d);
                GL.TexCoord2(TexVal * 32d, TexVal * 36d);
                GL.Vertex3(4.24d, 8.36d, -2.12d);
                GL.TexCoord2(TexVal * 32d, TexVal * 48d);
                GL.Vertex3(4.24d, -4.36d, -2.12d);
                GL.TexCoord2(TexVal * 40d, TexVal * 48d);
                GL.Vertex3(-4.24d, -4.36d, -2.12d);
                // Face 3
                GL.TexCoord2(TexVal * 16d, TexVal * 36d);
                GL.Vertex3(-4.24d, 8.36d, -2.12d);
                GL.TexCoord2(TexVal * 20d, TexVal * 36d);
                GL.Vertex3(-4.24d, 8.36d, 2.12d);
                GL.TexCoord2(TexVal * 20d, TexVal * 48d);
                GL.Vertex3(-4.24d, -4.36d, 2.12d);
                GL.TexCoord2(TexVal * 16d, TexVal * 48d);
                GL.Vertex3(-4.24d, -4.36d, -2.12d);
                // Face 4
                GL.TexCoord2(TexVal * 32d, TexVal * 36d);
                GL.Vertex3(4.24d, 8.36d, -2.12d);
                GL.TexCoord2(TexVal * 28d, TexVal * 36d);
                GL.Vertex3(4.24d, 8.36d, 2.12d);
                GL.TexCoord2(TexVal * 28d, TexVal * 48d);
                GL.Vertex3(4.24d, -4.36d, 2.12d);
                GL.TexCoord2(TexVal * 32d, TexVal * 48d);
                GL.Vertex3(4.24d, -4.36d, -2.12d);
                // Face 5
                GL.TexCoord2(TexVal * 20d, TexVal * 36d);
                GL.Vertex3(-4.24d, 8.36d, 2.12d);
                GL.TexCoord2(TexVal * 28d, TexVal * 36d);
                GL.Vertex3(4.24d, 8.36d, 2.12d);
                GL.TexCoord2(TexVal * 28d, TexVal * 32d);
                GL.Vertex3(4.24d, 8.36d, -2.12d);
                GL.TexCoord2(TexVal * 20d, TexVal * 32d);
                GL.Vertex3(-4.24d, 8.36d, -2.12d);
                // Face 6
                GL.TexCoord2(TexVal * 28d, TexVal * 36d);
                GL.Vertex3(-4.24d, -4.36d, 2.12d);
                GL.TexCoord2(TexVal * 36d, TexVal * 36d);
                GL.Vertex3(4.24d, -4.36d, 2.12d);
                GL.TexCoord2(TexVal * 36d, TexVal * 32d);
                GL.Vertex3(4.24d, -4.36d, -2.12d);
                GL.TexCoord2(TexVal * 28d, TexVal * 32d);
                GL.Vertex3(-4.24d, -4.36d, -2.12d);
            }

            if (ShowHeadOverlay)
            {
                // Head
                // Face 1
                GL.TexCoord2(TexVal * 40d, TexVal * 8d);
                GL.Vertex3(-4.24d, 16.24d, 4.24d);
                GL.TexCoord2(TexVal * 48d, TexVal * 8d);
                GL.Vertex3(4.24d, 16.24d, 4.24d);
                GL.TexCoord2(TexVal * 48d, TexVal * 16d);
                GL.Vertex3(4.24d, 7.76d, 4.24d);
                GL.TexCoord2(TexVal * 40d, TexVal * 16d);
                GL.Vertex3(-4.24d, 7.76d, 4.24d);
                // Face 2
                GL.TexCoord2(TexVal * 64d, TexVal * 8d);
                GL.Vertex3(-4.24d, 16.24d, -4.24d);
                GL.TexCoord2(TexVal * 56d, TexVal * 8d);
                GL.Vertex3(4.24d, 16.24d, -4.24d);
                GL.TexCoord2(TexVal * 56d, TexVal * 16d);
                GL.Vertex3(4.24d, 7.76d, -4.24d);
                GL.TexCoord2(TexVal * 64d, TexVal * 16d);
                GL.Vertex3(-4.24d, 7.76d, -4.24d);
                // Face 3
                GL.TexCoord2(TexVal * 40d, TexVal * 8d);
                GL.Vertex3(-4.24d, 16.24d, 4.24d);
                GL.TexCoord2(TexVal * 32d, TexVal * 8d);
                GL.Vertex3(-4.24d, 16.24d, -4.24d);
                GL.TexCoord2(TexVal * 32d, TexVal * 16d);
                GL.Vertex3(-4.24d, 7.76d, -4.24d);
                GL.TexCoord2(TexVal * 40d, TexVal * 16d);
                GL.Vertex3(-4.24d, 7.76d, 4.24d);
                // Face 4
                GL.TexCoord2(TexVal * 48d, TexVal * 8d);
                GL.Vertex3(4.24d, 16.24d, 4.24d);
                GL.TexCoord2(TexVal * 56d, TexVal * 8d);
                GL.Vertex3(4.24d, 16.24d, -4.24d);
                GL.TexCoord2(TexVal * 56d, TexVal * 16d);
                GL.Vertex3(4.24d, 7.76d, -4.24d);
                GL.TexCoord2(TexVal * 48d, TexVal * 16d);
                GL.Vertex3(4.24d, 7.76d, 4.24d);
                // Face 5
                GL.TexCoord2(TexVal * 40d, TexVal * 8d);
                GL.Vertex3(-4.24d, 16.24d, 4.24d);
                GL.TexCoord2(TexVal * 48d, TexVal * 8d);
                GL.Vertex3(4.24d, 16.24d, 4.24d);
                GL.TexCoord2(TexVal * 48d, 0d);
                GL.Vertex3(4.24d, 16.24d, -4.24d);
                GL.TexCoord2(TexVal * 40d, 0d);
                GL.Vertex3(-4.24d, 16.24d, -4.24d);
                // Face 6
                GL.TexCoord2(TexVal * 48d, TexVal * 8d);
                GL.Vertex3(-4.24d, 7.76d, 4.24d);
                GL.TexCoord2(TexVal * 56d, TexVal * 8d);
                GL.Vertex3(4.24d, 7.76d, 4.24d);
                GL.TexCoord2(TexVal * 56d, 0d);
                GL.Vertex3(4.24d, 7.76d, -4.24d);
                GL.TexCoord2(TexVal * 48d, 0d);
                GL.Vertex3(-4.24d, 7.76d, -4.24d);
            }

            if (Model == Models.Steve)
            {

                if (ShowLeftArmOverlay)
                {
                    // LeftArm
                    // Face 1
                    GL.TexCoord2(TexVal * 52d, TexVal * 52d);
                    GL.Vertex3(3.88d, 8.36d, 2.12d);
                    GL.TexCoord2(TexVal * 56d, TexVal * 52d);
                    GL.Vertex3(8.12d, 8.36d, 2.12d);
                    GL.TexCoord2(TexVal * 56d, TexVal * 64d);
                    GL.Vertex3(8.12d, -4.36d, 2.12d);
                    GL.TexCoord2(TexVal * 52d, TexVal * 64d);
                    GL.Vertex3(3.88d, -4.36d, 2.12d);
                    // Face 2
                    GL.TexCoord2(TexVal * 64d, TexVal * 52d);
                    GL.Vertex3(3.88d, 8.36d, -2.12d);
                    GL.TexCoord2(TexVal * 60d, TexVal * 52d);
                    GL.Vertex3(8.12d, 8.36d, -2.12d);
                    GL.TexCoord2(TexVal * 60d, TexVal * 64d);
                    GL.Vertex3(8.12d, -4.36d, -2.12d);
                    GL.TexCoord2(TexVal * 64d, TexVal * 64d);
                    GL.Vertex3(3.88d, -4.36d, -2.12d);
                    // Face 3
                    GL.TexCoord2(TexVal * 48d, TexVal * 52d);
                    GL.Vertex3(3.88d, 8.36d, -2.12d);
                    GL.TexCoord2(TexVal * 52d, TexVal * 52d);
                    GL.Vertex3(3.88d, 8.36d, 2.12d);
                    GL.TexCoord2(TexVal * 52d, TexVal * 64d);
                    GL.Vertex3(3.88d, -4.36d, 2.12d);
                    GL.TexCoord2(TexVal * 48d, TexVal * 64d);
                    GL.Vertex3(3.88d, -4.36d, -2.12d);
                    // Face 4
                    GL.TexCoord2(TexVal * 60d, TexVal * 52d);
                    GL.Vertex3(8.12d, 8.36d, -2.12d);
                    GL.TexCoord2(TexVal * 56d, TexVal * 52d);
                    GL.Vertex3(8.12d, 8.36d, 2.12d);
                    GL.TexCoord2(TexVal * 56d, TexVal * 64d);
                    GL.Vertex3(8.12d, -4.36d, 2.12d);
                    GL.TexCoord2(TexVal * 60d, TexVal * 64d);
                    GL.Vertex3(8.12d, -4.36d, -2.12d);
                    // Face 5
                    GL.TexCoord2(TexVal * 52d, TexVal * 52d);
                    GL.Vertex3(3.88d, 8.36d, 2.12d);
                    GL.TexCoord2(TexVal * 56d, TexVal * 52d);
                    GL.Vertex3(8.12d, 8.36d, 2.12d);
                    GL.TexCoord2(TexVal * 56d, TexVal * 48d);
                    GL.Vertex3(8.12d, 8.36d, -2.12d);
                    GL.TexCoord2(TexVal * 52d, TexVal * 48d);
                    GL.Vertex3(3.88d, 8.36d, -2.12d);
                    // Face 6
                    GL.TexCoord2(TexVal * 56d, TexVal * 52d);
                    GL.Vertex3(3.88d, -4.36d, 2.12d);
                    GL.TexCoord2(TexVal * 60d, TexVal * 52d);
                    GL.Vertex3(8.12d, -4.36d, 2.12d);
                    GL.TexCoord2(TexVal * 60d, TexVal * 48d);
                    GL.Vertex3(8.12d, -4.36d, -2.12d);
                    GL.TexCoord2(TexVal * 56d, TexVal * 48d);
                    GL.Vertex3(3.88d, -4.36d, -2.12d);
                }

                if (ShowRightArmOverlay)
                {
                    // RightArm
                    // Face 1
                    GL.TexCoord2(TexVal * 44d, TexVal * 36d);
                    GL.Vertex3(-8.12d, 8.36d, 2.12d);
                    GL.TexCoord2(TexVal * 48d, TexVal * 36d);
                    GL.Vertex3(-3.88d, 8.36d, 2.12d);
                    GL.TexCoord2(TexVal * 48d, TexVal * 48d);
                    GL.Vertex3(-3.88d, -4.36d, 2.12d);
                    GL.TexCoord2(TexVal * 44d, TexVal * 48d);
                    GL.Vertex3(-8.12d, -4.36d, 2.12d);
                    // Face 2
                    GL.TexCoord2(TexVal * 56d, TexVal * 36d);
                    GL.Vertex3(-8.12d, 8.36d, -2.12d);
                    GL.TexCoord2(TexVal * 52d, TexVal * 36d);
                    GL.Vertex3(-3.88d, 8.36d, -2.12d);
                    GL.TexCoord2(TexVal * 52d, TexVal * 48d);
                    GL.Vertex3(-3.88d, -4.36d, -2.12d);
                    GL.TexCoord2(TexVal * 56d, TexVal * 48d);
                    GL.Vertex3(-8.12d, -4.36d, -2.12d);
                    // Face 3
                    GL.TexCoord2(TexVal * 40d, TexVal * 36d);
                    GL.Vertex3(-8.12d, 8.36d, -2.12d);
                    GL.TexCoord2(TexVal * 44d, TexVal * 36d);
                    GL.Vertex3(-8.12d, 8.36d, 2.12d);
                    GL.TexCoord2(TexVal * 44d, TexVal * 48d);
                    GL.Vertex3(-8.12d, -4.36d, 2.12d);
                    GL.TexCoord2(TexVal * 40d, TexVal * 48d);
                    GL.Vertex3(-8.12d, -4.36d, -2.12d);
                    // Face 4
                    GL.TexCoord2(TexVal * 52d, TexVal * 36d);
                    GL.Vertex3(-3.88d, 8.36d, -2.12d);
                    GL.TexCoord2(TexVal * 48d, TexVal * 36d);
                    GL.Vertex3(-3.88d, 8.36d, 2.12d);
                    GL.TexCoord2(TexVal * 48d, TexVal * 48d);
                    GL.Vertex3(-3.88d, -4.36d, 2.12d);
                    GL.TexCoord2(TexVal * 52d, TexVal * 48d);
                    GL.Vertex3(-3.88d, -4.36d, -2.12d);
                    // Face 5
                    GL.TexCoord2(TexVal * 44d, TexVal * 36d);
                    GL.Vertex3(-8.12d, 8.36d, 2.12d);
                    GL.TexCoord2(TexVal * 48d, TexVal * 36d);
                    GL.Vertex3(-3.88d, 8.36d, 2.12d);
                    GL.TexCoord2(TexVal * 48d, TexVal * 32d);
                    GL.Vertex3(-3.88d, 8.36d, -2.12d);
                    GL.TexCoord2(TexVal * 44d, TexVal * 32d);
                    GL.Vertex3(-8.12d, 8.36d, -2.12d);
                    // Face 6
                    GL.TexCoord2(TexVal * 48d, TexVal * 36d);
                    GL.Vertex3(-8.12d, -4.36d, 2.12d);
                    GL.TexCoord2(TexVal * 52d, TexVal * 36d);
                    GL.Vertex3(-3.88d, -4.36d, 2.12d);
                    GL.TexCoord2(TexVal * 52d, TexVal * 32d);
                    GL.Vertex3(-3.88d, -4.36d, -2.12d);
                    GL.TexCoord2(TexVal * 48d, TexVal * 32d);
                    GL.Vertex3(-8.12d, -4.36d, -2.12d);
                }
            }

            else
            {

                if (ShowLeftArmOverlay)
                {
                    // LefttArm
                    // Face 1
                    GL.TexCoord2(TexVal * 52d, TexVal * 52d);
                    GL.Vertex3(3.91d, 8.36d, 2.12d);
                    GL.TexCoord2(TexVal * 55d, TexVal * 52d);
                    GL.Vertex3(7.09d, 8.36d, 2.12d);
                    GL.TexCoord2(TexVal * 55d, TexVal * 64d);
                    GL.Vertex3(7.09d, -4.36d, 2.12d);
                    GL.TexCoord2(TexVal * 52d, TexVal * 64d);
                    GL.Vertex3(3.91d, -4.36d, 2.12d);
                    // Face 2
                    GL.TexCoord2(TexVal * 62d, TexVal * 52d);
                    GL.Vertex3(3.91d, 8.36d, -2.12d);
                    GL.TexCoord2(TexVal * 59d, TexVal * 52d);
                    GL.Vertex3(7.09d, 8.36d, -2.12d);
                    GL.TexCoord2(TexVal * 59d, TexVal * 64d);
                    GL.Vertex3(7.09d, -4.36d, -2.12d);
                    GL.TexCoord2(TexVal * 62d, TexVal * 64d);
                    GL.Vertex3(3.91d, -4.36d, -2.12d);
                    // Face 3
                    GL.TexCoord2(TexVal * 48d, TexVal * 52d);
                    GL.Vertex3(3.91d, 8.36d, -2.12d);
                    GL.TexCoord2(TexVal * 52d, TexVal * 52d);
                    GL.Vertex3(3.91d, 8.36d, 2.12d);
                    GL.TexCoord2(TexVal * 52d, TexVal * 64d);
                    GL.Vertex3(3.91d, -4.36d, 2.12d);
                    GL.TexCoord2(TexVal * 48d, TexVal * 64d);
                    GL.Vertex3(3.91d, -4.36d, -2.12d);
                    // Face 4
                    GL.TexCoord2(TexVal * 59d, TexVal * 52d);
                    GL.Vertex3(7.09d, 8.36d, -2.12d);
                    GL.TexCoord2(TexVal * 55d, TexVal * 52d);
                    GL.Vertex3(7.09d, 8.36d, 2.12d);
                    GL.TexCoord2(TexVal * 55d, TexVal * 64d);
                    GL.Vertex3(7.09d, -4.36d, 2.12d);
                    GL.TexCoord2(TexVal * 59d, TexVal * 64d);
                    GL.Vertex3(7.09d, -4.36d, -2.12d);
                    // Face 5
                    GL.TexCoord2(TexVal * 52d, TexVal * 52d);
                    GL.Vertex3(3.91d, 8.36d, 2.12d);
                    GL.TexCoord2(TexVal * 55d, TexVal * 52d);
                    GL.Vertex3(7.09d, 8.36d, 2.12d);
                    GL.TexCoord2(TexVal * 55d, TexVal * 48d);
                    GL.Vertex3(7.09d, 8.36d, -2.12d);
                    GL.TexCoord2(TexVal * 52d, TexVal * 48d);
                    GL.Vertex3(3.91d, 8.36d, -2.12d);
                    // Face 6
                    GL.TexCoord2(TexVal * 55d, TexVal * 52d);
                    GL.Vertex3(3.91d, -4.36d, 2.12d);
                    GL.TexCoord2(TexVal * 58d, TexVal * 52d);
                    GL.Vertex3(7.09d, -4.36d, 2.12d);
                    GL.TexCoord2(TexVal * 58d, TexVal * 48d);
                    GL.Vertex3(7.09d, -4.36d, -2.12d);
                    GL.TexCoord2(TexVal * 55d, TexVal * 48d);
                    GL.Vertex3(3.91d, -4.36d, -2.12d);
                }

                if (ShowRightArmOverlay)
                {
                    // RightArm
                    // Face 1
                    GL.TexCoord2(TexVal * 44d, TexVal * 36d);
                    GL.Vertex3(-7.09d, 8.36d, 2.12d);
                    GL.TexCoord2(TexVal * 47d, TexVal * 36d);
                    GL.Vertex3(-3.91d, 8.36d, 2.12d);
                    GL.TexCoord2(TexVal * 47d, TexVal * 48d);
                    GL.Vertex3(-3.91d, -4.36d, 2.12d);
                    GL.TexCoord2(TexVal * 44d, TexVal * 48d);
                    GL.Vertex3(-7.09d, -4.36d, 2.12d);
                    // Face 2
                    GL.TexCoord2(TexVal * 54d, TexVal * 36d);
                    GL.Vertex3(-7.09d, 8.36d, -2.12d);
                    GL.TexCoord2(TexVal * 51d, TexVal * 36d);
                    GL.Vertex3(-3.91d, 8.36d, -2.12d);
                    GL.TexCoord2(TexVal * 51d, TexVal * 48d);
                    GL.Vertex3(-3.91d, -4.36d, -2.12d);
                    GL.TexCoord2(TexVal * 54d, TexVal * 48d);
                    GL.Vertex3(-7.09d, -4.36d, -2.12d);
                    // Face 3
                    GL.TexCoord2(TexVal * 40d, TexVal * 36d);
                    GL.Vertex3(-7.09d, 8.36d, -2.12d);
                    GL.TexCoord2(TexVal * 44d, TexVal * 36d);
                    GL.Vertex3(-7.09d, 8.36d, 2.12d);
                    GL.TexCoord2(TexVal * 44d, TexVal * 48d);
                    GL.Vertex3(-7.09d, -4.36d, 2.12d);
                    GL.TexCoord2(TexVal * 40d, TexVal * 48d);
                    GL.Vertex3(-7.09d, -4.36d, -2.12d);
                    // Face 4
                    GL.TexCoord2(TexVal * 51d, TexVal * 36d);
                    GL.Vertex3(-3.91d, 8.36d, -2.12d);
                    GL.TexCoord2(TexVal * 47d, TexVal * 36d);
                    GL.Vertex3(-3.91d, 8.36d, 2.12d);
                    GL.TexCoord2(TexVal * 47d, TexVal * 48d);
                    GL.Vertex3(-3.91d, -4.36d, 2.12d);
                    GL.TexCoord2(TexVal * 51d, TexVal * 48d);
                    GL.Vertex3(-3.91d, -4.36d, -2.12d);
                    // Face 5
                    GL.TexCoord2(TexVal * 44d, TexVal * 36d);
                    GL.Vertex3(-7.09d, 8.36d, 2.12d);
                    GL.TexCoord2(TexVal * 47d, TexVal * 36d);
                    GL.Vertex3(-3.91d, 8.36d, 2.12d);
                    GL.TexCoord2(TexVal * 47d, TexVal * 32d);
                    GL.Vertex3(-3.91d, 8.36d, -2.12d);
                    GL.TexCoord2(TexVal * 44d, TexVal * 32d);
                    GL.Vertex3(-7.09d, 8.36d, -2.12d);
                    // Face 6
                    GL.TexCoord2(TexVal * 47d, TexVal * 36d);
                    GL.Vertex3(-7.09d, -4.36d, 2.12d);
                    GL.TexCoord2(TexVal * 50d, TexVal * 36d);
                    GL.Vertex3(-3.91d, -4.36d, 2.12d);
                    GL.TexCoord2(TexVal * 50d, TexVal * 32d);
                    GL.Vertex3(-3.91d, -4.36d, -2.12d);
                    GL.TexCoord2(TexVal * 47d, TexVal * 32d);
                    GL.Vertex3(-7.09d, -4.36d, -2.12d);
                }

            }

            if (ShowRightLegOverlay)
            {
                // RightLeg
                // Face 1
                GL.TexCoord2(TexVal * 4d, TexVal * 36d);
                GL.Vertex3(-4.12d, -3.64d, 2.12d);
                GL.TexCoord2(TexVal * 8d, TexVal * 36d);
                GL.Vertex3(0.12d, -3.64d, 2.12d);
                GL.TexCoord2(TexVal * 8d, TexVal * 48d);
                GL.Vertex3(0.12d, -16.36d, 2.12d);
                GL.TexCoord2(TexVal * 4d, TexVal * 48d);
                GL.Vertex3(-4.12d, -16.36d, 2.12d);
                // Face 2
                GL.TexCoord2(TexVal * 16d, TexVal * 36d);
                GL.Vertex3(-4.12d, -3.64d, -2.12d);
                GL.TexCoord2(TexVal * 12d, TexVal * 36d);
                GL.Vertex3(0.12d, -3.64d, -2.12d);
                GL.TexCoord2(TexVal * 12d, TexVal * 48d);
                GL.Vertex3(0.12d, -16.36d, -2.12d);
                GL.TexCoord2(TexVal * 16d, TexVal * 48d);
                GL.Vertex3(-4.12d, -16.36d, -2.12d);
                // Face 3
                GL.TexCoord2(TexVal * 0d, TexVal * 36d);
                GL.Vertex3(-4.12d, -3.64d, -2.12d);
                GL.TexCoord2(TexVal * 4d, TexVal * 36d);
                GL.Vertex3(-4.12d, -3.64d, 2.12d);
                GL.TexCoord2(TexVal * 4d, TexVal * 48d);
                GL.Vertex3(-4.12d, -16.36d, 2.12d);
                GL.TexCoord2(TexVal * 0d, TexVal * 48d);
                GL.Vertex3(-4.12d, -16.36d, -2.12d);
                // Face 4
                GL.TexCoord2(TexVal * 12d, TexVal * 36d);
                GL.Vertex3(0.12d, -3.64d, -2.12d);
                GL.TexCoord2(TexVal * 8d, TexVal * 36d);
                GL.Vertex3(0.12d, -3.64d, 2.12d);
                GL.TexCoord2(TexVal * 8d, TexVal * 48d);
                GL.Vertex3(0.12d, -16.36d, 2.12d);
                GL.TexCoord2(TexVal * 12d, TexVal * 48d);
                GL.Vertex3(0.12d, -16.36d, -2.12d);
                // Face 5
                GL.TexCoord2(TexVal * 4d, TexVal * 36d);
                GL.Vertex3(-4.12d, -3.64d, 2.12d);
                GL.TexCoord2(TexVal * 8d, TexVal * 36d);
                GL.Vertex3(0.12d, -3.64d, 2.12d);
                GL.TexCoord2(TexVal * 8d, TexVal * 32d);
                GL.Vertex3(0.12d, -3.64d, -2.12d);
                GL.TexCoord2(TexVal * 4d, TexVal * 32d);
                GL.Vertex3(-4.12d, -3.64d, -2.12d);
                // Face 6
                GL.TexCoord2(TexVal * 8d, TexVal * 36d);
                GL.Vertex3(-4.12d, -16.36d, 2.12d);
                GL.TexCoord2(TexVal * 12d, TexVal * 36d);
                GL.Vertex3(0.12d, -16.36d, 2.12d);
                GL.TexCoord2(TexVal * 12d, TexVal * 32d);
                GL.Vertex3(0.12d, -16.36d, -2.12d);
                GL.TexCoord2(TexVal * 8d, TexVal * 32d);
                GL.Vertex3(-4.12d, -16.36d, -2.12d);
            }

            if (ShowLeftLegOverlay)
            {
                // LeftLeg
                // Face 1
                GL.TexCoord2(TexVal * 4d, TexVal * 52d);
                GL.Vertex3(-0.12d, -3.64d, 2.12d);
                GL.TexCoord2(TexVal * 8d, TexVal * 52d);
                GL.Vertex3(4.12d, -3.64d, 2.12d);
                GL.TexCoord2(TexVal * 8d, TexVal * 64d);
                GL.Vertex3(4.12d, -16.36d, 2.12d);
                GL.TexCoord2(TexVal * 4d, TexVal * 64d);
                GL.Vertex3(-0.12d, -16.36d, 2.12d);
                // Face 2
                GL.TexCoord2(TexVal * 16d, TexVal * 52d);
                GL.Vertex3(-0.12d, -3.64d, -2.12d);
                GL.TexCoord2(TexVal * 12d, TexVal * 52d);
                GL.Vertex3(4.12d, -3.64d, -2.12d);
                GL.TexCoord2(TexVal * 12d, TexVal * 64d);
                GL.Vertex3(4.12d, -16.36d, -2.12d);
                GL.TexCoord2(TexVal * 16d, TexVal * 64d);
                GL.Vertex3(-0.12d, -16.36d, -2.12d);
                // Face 3
                GL.TexCoord2(TexVal * 0d, TexVal * 52d);
                GL.Vertex3(-0.12d, -3.64d, -2.12d);
                GL.TexCoord2(TexVal * 4d, TexVal * 52d);
                GL.Vertex3(-0.12d, -3.64d, 2.12d);
                GL.TexCoord2(TexVal * 4d, TexVal * 64d);
                GL.Vertex3(-0.12d, -16.36d, 2.12d);
                GL.TexCoord2(TexVal * 0d, TexVal * 64d);
                GL.Vertex3(-0.12d, -16.36d, -2.12d);
                // Face 4
                GL.TexCoord2(TexVal * 12d, TexVal * 52d);
                GL.Vertex3(4.12d, -3.64d, -2.12d);
                GL.TexCoord2(TexVal * 8d, TexVal * 52d);
                GL.Vertex3(4.12d, -3.64d, 2.12d);
                GL.TexCoord2(TexVal * 8d, TexVal * 64d);
                GL.Vertex3(4.12d, -16.36d, 2.12d);
                GL.TexCoord2(TexVal * 12d, TexVal * 64d);
                GL.Vertex3(4.12d, -16.36d, -2.12d);
                // Face 5
                GL.TexCoord2(TexVal * 4d, TexVal * 52d);
                GL.Vertex3(-0.12d, -3.64d, 2.12d);
                GL.TexCoord2(TexVal * 8d, TexVal * 52d);
                GL.Vertex3(4.12d, -3.64d, 2.12d);
                GL.TexCoord2(TexVal * 8d, TexVal * 48d);
                GL.Vertex3(4.12d, -3.64d, -2.12d);
                GL.TexCoord2(TexVal * 4d, TexVal * 48d);
                GL.Vertex3(-0.12d, -3.64d, -2.12d);
                // Face 6
                GL.TexCoord2(TexVal * 8d, TexVal * 52d);
                GL.Vertex3(-0.12d, -16.36d, 2.12d);
                GL.TexCoord2(TexVal * 12d, TexVal * 52d);
                GL.Vertex3(4.12d, -16.36d, 2.12d);
                GL.TexCoord2(TexVal * 12d, TexVal * 48d);
                GL.Vertex3(4.12d, -16.36d, -2.12d);
                GL.TexCoord2(TexVal * 8d, TexVal * 48d);
                GL.Vertex3(-0.12d, -16.36d, -2.12d);
            }

            GL.DeleteTexture(texID);

            // Finish the begin mode with "end"
            GL.End();
            GL.PopMatrix();
            // Finally...
            SwapBuffers(); // Takes from the 'GL' and puts into control
        }

        private bool IsMouseDown;
        private bool IsRightMouseDown;
        private bool IsMouseHidden;
        private bool IsMouseHit;
        private Point OldLoc;
        private Point MouseLoc;

        public event BeginChangedEventHandler BeginChanged;

        public delegate void BeginChangedEventHandler(object sender, Bitmap LastSkin);

        private Ray GlobalMouseRay; // To use the var golbaly in the code
        private Vector3 GlobalCameraPos;

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (!IsMouseDown && e.Button == MouseButtons.Left) // Left mouse button
            {
                // If the ray didn't hit the model then rotate the model
                OldLoc = Cursor.Position; // Store the old mouse position to reset it when the action is over
                if (!IsMouseHidden) // Hide the mouse
                {
                    Cursor.Hide();
                    IsMouseHidden = true;
                }
                MouseLoc = Cursor.Position; // Store the current mouse position to use it for the rotate action
                IsMouseDown = true;
            }
            else if (!IsRightMouseDown && e.Button == MouseButtons.Right) // Right mouse button
            {
                OldLoc = Cursor.Position; // Store the old mouse position to reset it when the action is over 
                if (!IsMouseHidden) // Hide the mouse
                {
                    Cursor.Hide();
                    IsMouseHidden = true;
                }
                MouseLoc = Cursor.Position; // Store the current mouse position to use it for the move action
                IsRightMouseDown = true;
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (IsMouseHidden)
            {
                Cursor.Show(); // Show the mouse
                IsMouseHidden = false;
                Cursor.Position = OldLoc; // Rest the mouse position
                IsMouseDown = false; // Clear the booleans
                IsRightMouseDown = false;
            }
            IsMouseHit = false;
        }

        private void Move_Tick(object sender, EventArgs e)
        {
            if (IsMouseDown) // Rotate the model
            {
                RotationY = (int)Math.Round(RotationY + (Cursor.Position.X - MouseLoc.X) * 0.5d);
                RotationX = (int)Math.Round(RotationX - (Cursor.Position.Y - MouseLoc.Y) * 0.5d);
                Refresh();
                Cursor.Position = new Point((int)Math.Round(Screen.PrimaryScreen.Bounds.Width / 2d), (int)Math.Round(Screen.PrimaryScreen.Bounds.Height / 2d));
                MouseLoc = Cursor.Position;
            }
            else if (IsRightMouseDown) // Move the model
            {
                float deltaX = -(Cursor.Position.X - MouseLoc.X) * 0.5f / (float)Zoom;
                float deltaY = (Cursor.Position.Y - MouseLoc.Y) * 0.5f / (float)Zoom;
                LookAngle = new PointF(LookAngle.X + deltaX, LookAngle.Y + deltaY);
                Refresh();
                Cursor.Position = new Point((int)Math.Round(Screen.PrimaryScreen.Bounds.Height / 2d), (int)Math.Round(Screen.PrimaryScreen.Bounds.Height / 2d));
                MouseLoc = Cursor.Position;
            }
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            Zoom += e.Delta * 0.005d;
            Refresh();
            base.OnMouseWheel(e);
        }

        private Vector3 GetCameraPosition(Matrix4 modelview)
        {
            return Matrix4.Invert(modelview).ExtractTranslation();
        }

        private List<Point> MousePoints = new List<Point>();
        private List<Point> tmpMousePoints = new List<Point>();

        public event SkinChangedEventHandler SkinChanged;

        public delegate void SkinChangedEventHandler(object sender, bool IsLeft);
        private Random _PaintPixel_rNumber = new Random();

        public void PaintPixel(Vector3 Vector, bool Second = false)
        {
            Bitmap tmpSkin = (Bitmap)Texture.Clone();
            Point Point;
            var XUp = default(Vector3);
            var YUp = default(Vector3);
            var Left = default(bool);
            if (Second)
            {
                Point = Get2nd2DFrom3D(Vector, ref XUp, ref YUp);
            }
            else
            {
                Point = Get2DFrom3D(Vector, ref XUp, ref YUp);
                if (Point.Y > 31)
                    Left = true;
            }
            var Points = new List<Point>();
            tmpSkin.Dispose();
            SkinChanged?.Invoke(this, Left);
        }

        public Point Get2DFrom3D(Vector3 Vector, ref Vector3 XUp, ref Vector3 YUp)
        {
            var Result = default(Point);
            if (Vector.X < 4f && Vector.X > -4 && Vector.Y < 16f && Vector.Y > 8f && Vector.Z == 4f)
            {
                // ZHead
                Result = new Point((int)Math.Round(Conversion.Int(Vector.X + 4f + 8f)), (int)Math.Round(Conversion.Int(-Vector.Y + 16f + 8f)));
                XUp.X = 1f;
                YUp.Y = 1f;
            }
            else if (Vector.X < 4f && Vector.X > -4 && Vector.Y < 16f && Vector.Y > 8f && Vector.Z == -4)
            {
                // ZHead
                Result = new Point((int)Math.Round(Conversion.Int(-Vector.X + 4f + 24f)), (int)Math.Round(Conversion.Int(-Vector.Y + 16f + 8f)));
                XUp.X = 1f;
                YUp.Y = 1f;
            }
            else if (Vector.X < 4f && Vector.X > -4 && Vector.Y < 8f && Vector.Y > -4 && Vector.Z == 2f)
            {
                // ZBody
                Result = new Point((int)Math.Round(Conversion.Int(Vector.X + 4f + 20f)), (int)Math.Round(Conversion.Int(-Vector.Y + 8f + 20f)));
                XUp.X = 1f;
                YUp.Y = 1f;
            }
            else if (Vector.X < 4f && Vector.X > -4 && Vector.Y < 8f && Vector.Y > -4 && Vector.Z == -2)
            {
                // ZBody
                Result = new Point((int)Math.Round(Conversion.Int(-Vector.X + 4f + 32f)), (int)Math.Round(Conversion.Int(-Vector.Y + 8f + 20f)));
                XUp.X = 1f;
                YUp.Y = 1f;
            }
            else if (Vector.X < -4 && Vector.X > -8 && Vector.Y < 8f && Vector.Y > -4 && Vector.Z == 2f)
            {
                // ZArms
                if (Model == Models.Steve)
                {
                    Result = new Point((int)Math.Round(Conversion.Int(Vector.X + 4f + 48f)), (int)Math.Round(Conversion.Int(-Vector.Y + 8f + 20f)));
                }
                else
                {
                    Result = new Point((int)Math.Round(Conversion.Int(Vector.X + 4f + 47f)), (int)Math.Round(Conversion.Int(-Vector.Y + 8f + 20f)));
                }
                XUp.X = 1f;
                YUp.Y = 1f;
            }
            else if (Vector.X < -4 && Vector.X > -8 && Vector.Y < 8f && Vector.Y > -4 && Vector.Z == -2)
            {
                // ZArms
                if (Model == Models.Steve)
                {
                    Result = new Point((int)Math.Round(Conversion.Int(-Vector.X + 4f + 44f)), (int)Math.Round(Conversion.Int(-Vector.Y + 8f + 20f)));
                }
                else
                {
                    Result = new Point((int)Math.Round(Conversion.Int(-Vector.X + 4f + 43f)), (int)Math.Round(Conversion.Int(-Vector.Y + 8f + 20f)));
                }
                XUp.X = 1f;
                YUp.Y = 1f;
            }
            else if (Vector.X < 8f && Vector.X > 4f && Vector.Y < 8f && Vector.Y > -4 && Vector.Z == 2f)
            {
                // ZArms
                Result = new Point((int)Math.Round(Conversion.Int(Vector.X + 4f + 28f)), (int)Math.Round(Conversion.Int(-Vector.Y + 8f + 52f)));
                XUp.X = 1f;
                YUp.Y = 1f;
            }
            else if (Vector.X < 8f && Vector.X > 4f && Vector.Y < 8f && Vector.Y > -4 && Vector.Z == -2)
            {
                // ZArms
                if (Model == Models.Steve)
                {
                    Result = new Point((int)Math.Round(Conversion.Int(-Vector.X + 4f + 48f)), (int)Math.Round(Conversion.Int(-Vector.Y + 8f + 52f)));
                }
                else
                {
                    Result = new Point((int)Math.Round(Conversion.Int(-Vector.X + 4f + 46f)), (int)Math.Round(Conversion.Int(-Vector.Y + 8f + 52f)));
                }
                XUp.X = 1f;
                YUp.Y = 1f;
            }
            else if (Vector.X < 0f && Vector.X > -4 && Vector.Y < -4 && Vector.Y > -16 && Vector.Z == 2f)
            {
                // ZLegs
                Result = new Point((int)Math.Round(Conversion.Int(Vector.X + 4f + 4f)), (int)Math.Round(Conversion.Int(-Vector.Y + 16f)));
                XUp.X = 1f;
                YUp.Y = 1f;
            }
            else if (Vector.X < 0f && Vector.X > -4 && Vector.Y < -4 && Vector.Y > -16 && Vector.Z == -2)
            {
                // ZLegs
                Result = new Point((int)Math.Round(Conversion.Int(-Vector.X + 4f + 8f)), (int)Math.Round(Conversion.Int(-Vector.Y + 16f)));
                XUp.X = 1f;
                YUp.Y = 1f;
            }
            else if (Vector.X < 4f && Vector.X > 0f && Vector.Y < -4 && Vector.Y > -16 && Vector.Z == 2f)
            {
                // ZLegs
                Result = new Point((int)Math.Round(Conversion.Int(Vector.X + 4f + 16f)), (int)Math.Round(Conversion.Int(-Vector.Y + 48f)));
                XUp.X = 1f;
                YUp.Y = 1f;
            }
            else if (Vector.X < 4f && Vector.X > 0f && Vector.Y < -4 && Vector.Y > -16 && Vector.Z == -2)
            {
                // ZLegs
                Result = new Point((int)Math.Round(Conversion.Int(-Vector.X + 4f + 28f)), (int)Math.Round(Conversion.Int(-Vector.Y + 48f)));
                XUp.X = 1f;
                YUp.Y = 1f;
            }
            else if (Vector.Z < 4f && Vector.Z > -4 && Vector.Y < 16f && Vector.Y > 8f && Vector.X == 4f)
            {
                // XHead
                Result = new Point((int)Math.Round(Conversion.Int(-Vector.Z + 20f)), (int)Math.Round(Conversion.Int(-Vector.Y + 24f)));
                XUp.Z = 1f;
                YUp.Y = 1f;
            }
            else if (Vector.Z < 4f && Vector.Z > -4 && Vector.Y < 16f && Vector.Y > 8f && Vector.X == -4)
            {
                // XHead
                Result = new Point((int)Math.Round(Conversion.Int(Vector.Z + 4f)), (int)Math.Round(Conversion.Int(-Vector.Y + 24f)));
                XUp.Z = 1f;
                YUp.Y = 1f;
            }
            else if (Vector.Z < 2f && Vector.Z > -2 && Vector.Y < 8f && Vector.Y > -4 && Vector.X == 4f)
            {
                // XBody
                if (ShowBody && !ShowLeftArm)
                {
                    Result = new Point((int)Math.Round(Conversion.Int(-Vector.Z + 30f)), (int)Math.Round(Conversion.Int(-Vector.Y + 28f)));
                }
                else
                {
                    Result = new Point((int)Math.Round(Conversion.Int(Vector.Z + 34f)), (int)Math.Round(Conversion.Int(-Vector.Y + 60f)));
                }
                XUp.Z = 1f;
                YUp.Y = 1f;
            }
            else if (Vector.Z < 2f && Vector.Z > -2 && Vector.Y < 8f && Vector.Y > -4 && Vector.X == -4)
            {
                // XBody
                if (ShowBody && !ShowRightArm)
                {
                    Result = new Point((int)Math.Round(Conversion.Int(Vector.Z + 18f)), (int)Math.Round(Conversion.Int(-Vector.Y + 28f)));
                }
                else
                {
                    Result = new Point((int)Math.Round(Conversion.Int(-Vector.Z + 50f)), (int)Math.Round(Conversion.Int(-Vector.Y + 28f)));
                }
                XUp.Z = 1f;
                YUp.Y = 1f;
            }
            else if (Vector.Z < 2f && Vector.Z > -2 && Vector.Y < 8f && Vector.Y > -4 && Vector.X == 8f)
            {
                // XArms
                Result = new Point((int)Math.Round(Conversion.Int(-Vector.Z + 42f)), (int)Math.Round(Conversion.Int(-Vector.Y + 60f)));
                XUp.Z = 1f;
                YUp.Y = 1f;
            }
            else if (Vector.Z < 2f && Vector.Z > -2 && Vector.Y < 8f && Vector.Y > -4 && Vector.X == -8)
            {
                // XArms
                Result = new Point((int)Math.Round(Conversion.Int(Vector.Z + 42f)), (int)Math.Round(Conversion.Int(-Vector.Y + 28f)));
                XUp.Z = 1f;
                YUp.Y = 1f;
            }
            else if (Vector.Z < 2f && Vector.Z > -2 && Vector.Y < 8f && Vector.Y > -4 && Vector.X == 7f)
            {
                // XArms
                Result = new Point((int)Math.Round(Conversion.Int(-Vector.Z + 41f)), (int)Math.Round(Conversion.Int(-Vector.Y + 60f)));
                XUp.Z = 1f;
                YUp.Y = 1f;
            }
            else if (Vector.Z < 2f && Vector.Z > -2 && Vector.Y < 8f && Vector.Y > -4 && Vector.X == -7)
            {
                // XArms
                Result = new Point((int)Math.Round(Conversion.Int(Vector.Z + 42f)), (int)Math.Round(Conversion.Int(-Vector.Y + 28f)));
                XUp.Z = 1f;
                YUp.Y = 1f;
            }
            else if (Vector.Z < 2f && Vector.Z > -2 && Vector.Y < -4 && Vector.Y > -16 && Vector.X == 4f)
            {
                // XLeg
                Result = new Point((int)Math.Round(Conversion.Int(-Vector.Z + 26f)), (int)Math.Round(Conversion.Int(-Vector.Y + 48f)));
                XUp.Z = 1f;
                YUp.Y = 1f;
            }
            else if (Vector.Z < 2f && Vector.Z > -2 && Vector.Y < -4 && Vector.Y > -16 && Vector.X == -4)
            {
                // XLeg
                Result = new Point((int)Math.Round(Conversion.Int(Vector.Z + 2f)), (int)Math.Round(Conversion.Int(-Vector.Y + 16f)));
                XUp.Z = 1f;
                YUp.Y = 1f;
            }
            else if (Vector.Z < 2f && Vector.Z > -2 && Vector.Y < -4 && Vector.Y > -16 && Vector.X == 0f)
            {
                // XLeg
                if (ShowLeftLeg)
                {
                    Result = new Point((int)Math.Round(Conversion.Int(Vector.Z + 18f)), (int)Math.Round(Conversion.Int(-Vector.Y + 48f)));
                }
                else
                {
                    Result = new Point((int)Math.Round(Conversion.Int(-Vector.Z + 10f)), (int)Math.Round(Conversion.Int(-Vector.Y + 16f)));
                }
                XUp.Z = 1f;
                YUp.Y = 1f;
            }
            else if (Vector.Z < 4f && Vector.Z > -4 && Vector.X < 4f && Vector.X > -4 && Vector.Y == 16f)
            {
                // YHead
                Result = new Point((int)Math.Round(Conversion.Int(Vector.X + 12f)), (int)Math.Round(Conversion.Int(Vector.Z + 4f)));
                XUp.X = 1f;
                YUp.Z = 1f;
            }
            else if (ShowHead && Vector.Z < 4f && Vector.Z > -4 && Vector.X < 4f && Vector.X > -4 && Vector.Y == 8f)
            {
                // YHead
                Result = new Point((int)Math.Round(Conversion.Int(Vector.X + 20f)), (int)Math.Round(Conversion.Int(Vector.Z + 4f)));
                XUp.X = 1f;
                YUp.Z = 1f;
            }
            else if (Vector.Z < 2f && Vector.Z > -2 && Vector.X < 4f && Vector.X > -4 && Vector.Y == 8f)
            {
                // YBody
                Result = new Point((int)Math.Round(Conversion.Int(Vector.X + 24f)), (int)Math.Round(Conversion.Int(Vector.Z + 18f)));
                XUp.X = 1f;
                YUp.Z = 1f;
            }
            else if (ShowBody && (!ShowLeftLeg || !ShowRightLeg) && Vector.Z < 2f && Vector.Z > -2 && Vector.X < 4f && Vector.X > -4 && Vector.Y == -4)
            {
                // YBody
                Result = new Point((int)Math.Round(Conversion.Int(Vector.X + 32f)), (int)Math.Round(Conversion.Int(Vector.Z + 18f)));
                XUp.X = 1f;
                YUp.Z = 1f;
            }
            else if (Vector.Z < 2f && Vector.Z > -2 && Vector.X < 8f && Vector.X > 4f && Vector.Y == 8f)
            {
                // YArms
                Result = new Point((int)Math.Round(Conversion.Int(Vector.X + 32f)), (int)Math.Round(Conversion.Int(Vector.Z + 50f)));
                XUp.X = 1f;
                YUp.Z = 1f;
            }
            else if (Vector.Z < 2f && Vector.Z > -2 && Vector.X < 8f && Vector.X > 4f && Vector.Y == -4)
            {
                // YArms
                if (Model == Models.Steve)
                {
                    Result = new Point((int)Math.Round(Conversion.Int(Vector.X + 36f)), (int)Math.Round(Conversion.Int(Vector.Z + 50f)));
                }
                else
                {
                    Result = new Point((int)Math.Round(Conversion.Int(Vector.X + 35f)), (int)Math.Round(Conversion.Int(Vector.Z + 50f)));
                }
                XUp.X = 1f;
                YUp.Z = 1f;
            }
            else if (Vector.Z < 2f && Vector.Z > -2 && Vector.X < -4 && Vector.X > -8 && Vector.Y == 8f)
            {
                // YArms
                if (Model == Models.Steve)
                {
                    Result = new Point((int)Math.Round(Conversion.Int(Vector.X + 52f)), (int)Math.Round(Conversion.Int(Vector.Z + 18f)));
                }
                else
                {
                    Result = new Point((int)Math.Round(Conversion.Int(Vector.X + 51f)), (int)Math.Round(Conversion.Int(Vector.Z + 18f)));
                }
                XUp.X = 1f;
                YUp.Z = 1f;
            }
            else if (Vector.Z < 2f && Vector.Z > -2 && Vector.X < -4 && Vector.X > -8 && Vector.Y == -4)
            {
                // YArms
                if (Model == Models.Steve)
                {
                    Result = new Point((int)Math.Round(Conversion.Int(Vector.X + 56f)), (int)Math.Round(Conversion.Int(Vector.Z + 18f)));
                }
                else
                {
                    Result = new Point((int)Math.Round(Conversion.Int(Vector.X + 54f)), (int)Math.Round(Conversion.Int(Vector.Z + 18f)));
                }
                XUp.X = 1f;
                YUp.Z = 1f;
            }
            else if (ShowLeftLeg && !ShowBody && Vector.Z < 2f && Vector.Z > -2 && Vector.X < 4f && Vector.X > 0f && Vector.Y == -4)
            {
                // YLeg
                Result = new Point((int)Math.Round(Conversion.Int(Vector.X + 20f)), (int)Math.Round(Conversion.Int(Vector.Z + 50f)));
                XUp.X = 1f;
                YUp.Z = 1f;
            }
            else if (ShowRightLeg && !ShowBody && Vector.Z < 2f && Vector.Z > -2 && Vector.X < 0f && Vector.X > -4 && Vector.Y == -4)
            {
                // YLeg
                Result = new Point((int)Math.Round(Conversion.Int(Vector.X + 8f)), (int)Math.Round(Conversion.Int(Vector.Z + 18f)));
                XUp.X = 1f;
                YUp.Z = 1f;
            }
            else if (Vector.Z < 2f && Vector.Z > -2 && Vector.X < 4f && Vector.X > 0f && Vector.Y == -16)
            {
                // YLeg
                Result = new Point((int)Math.Round(Conversion.Int(Vector.X + 24f)), (int)Math.Round(Conversion.Int(Vector.Z + 50f)));
                XUp.X = 1f;
                YUp.Z = 1f;
            }
            else if (Vector.Z < 2f && Vector.Z > -2 && Vector.X < 0f && Vector.X > -4 && Vector.Y == -16)
            {
                // YLeg
                Result = new Point((int)Math.Round(Conversion.Int(Vector.X + 12f)), (int)Math.Round(Conversion.Int(Vector.Z + 18f)));
                XUp.X = 1f;
                YUp.Z = 1f;
            }

            return Result;
        }

        public Point Get2nd2DFrom3D(Vector3 Vector, ref Vector3 XUp, ref Vector3 YUp)
        {
            var Result = default(Point);
            if (ShowHeadOverlay && Vector.X < 4.24d && Vector.X > -4.24d && Vector.Y < 16.24d && Vector.Y > 7.76d && Vector.Z == 4.24f)
            {
                // ZHead
                Result = new Point((int)Math.Round(Conversion.Int((Vector.X + 4.24d) / 1.06d + 40d)), (int)Math.Round(Conversion.Int(((double)-Vector.Y + 16.24d) / 1.06d + 8d)));
                XUp.X = 1f;
                YUp.Y = 1f;
            }
            else if (ShowHeadOverlay && Vector.X < 4.24d && Vector.X > -4.24d && Vector.Y < 16.24d && Vector.Y > 7.76d && Vector.Z == -4.24f)
            {
                // ZHead
                Result = new Point((int)Math.Round(Conversion.Int(((double)-Vector.X + 4.24d) / 1.06d + 56d)), (int)Math.Round(Conversion.Int(((double)-Vector.Y + 16.24d) / 1.06d + 8d)));
                XUp.X = 1f;
                YUp.Y = 1f;
            }
            else if (ShowBodyOverlay && Vector.X < 4.24d && Vector.X > -4.24d && Vector.Y < 8.36d && Vector.Y > -4.36d && Vector.Z == 2.12f)
            {
                // ZBody
                Result = new Point((int)Math.Round(Conversion.Int((Vector.X + 4.24d) / 1.06d + 20d)), (int)Math.Round(Conversion.Int(((double)-Vector.Y + 8.36d) / 1.06d + 36d)));
                XUp.X = 1f;
                YUp.Y = 1f;
            }
            else if (ShowBodyOverlay && Vector.X < 4.24d && Vector.X > -4.24d && Vector.Y < 8.36d && Vector.Y > -4.36d && Vector.Z == -2.12f)
            {
                // ZBody
                Result = new Point((int)Math.Round(Conversion.Int(((double)-Vector.X + 4.24d) / 1.06d + 32d)), (int)Math.Round(Conversion.Int(((double)-Vector.Y + 8.36d) / 1.06d + 36d)));
                XUp.X = 1f;
                YUp.Y = 1f;
            }
            else if (ShowRightArmOverlay && Vector.X < -3.88d && Vector.X > -8.12d && Vector.Y < 8.36d && Vector.Y > -4.36d && Vector.Z == 2.12f)
            {
                // ZArms
                if (Model == Models.Steve)
                {
                    Result = new Point((int)Math.Round(Conversion.Int((Vector.X + 3.88d) / 1.06d + 48d)), (int)Math.Round(Conversion.Int(((double)-Vector.Y + 8.36d) / 1.06d + 36d)));
                }
                else
                {
                    Result = new Point((int)Math.Round(Conversion.Int((Vector.X + 3.88d) / 1.06d + 47d)), (int)Math.Round(Conversion.Int(((double)-Vector.Y + 8.36d) / 1.06d + 36d)));
                }
                XUp.X = 1f;
                YUp.Y = 1f;
            }
            else if (ShowRightArmOverlay && Vector.X < -3.88d && Vector.X > -8.12d && Vector.Y < 8.36d && Vector.Y > -4.36d && Vector.Z == -2.12f)
            {
                // ZArms
                if (Model == Models.Steve)
                {
                    Result = new Point((int)Math.Round(Conversion.Int(((double)-Vector.X + 3.88d) / 1.06d + 45d)), (int)Math.Round(Conversion.Int(((double)-Vector.Y + 8.36d) / 1.06d + 36d)));
                }
                else
                {
                    Result = new Point((int)Math.Round(Conversion.Int(((double)-Vector.X + 3.88d) / 1.06d + 44d)), (int)Math.Round(Conversion.Int(((double)-Vector.Y + 8.36d) / 1.06d + 36d)));
                }
                XUp.X = 1f;
                YUp.Y = 1f;
            }
            else if (ShowLeftArmOverlay && Vector.X < 8.12d && Vector.X > 3.88d && Vector.Y < 8.36d && Vector.Y > -4.36d && Vector.Z == 2.12f)
            {
                // ZArms
                Result = new Point((int)Math.Round(Conversion.Int((Vector.X + 3.88d) / 1.06d + 45d)), (int)Math.Round(Conversion.Int(((double)-Vector.Y + 8.36d) / 1.06d + 52d)));
                XUp.X = 1f;
                YUp.Y = 1f;
            }
            else if (ShowLeftArmOverlay && Vector.X < 8.12d && Vector.X > 3.88d && Vector.Y < 8.36d && Vector.Y > -4.36d && Vector.Z == -2.12f)
            {
                // ZArms
                if (Model == Models.Steve)
                {
                    Result = new Point((int)Math.Round(Conversion.Int(((double)-Vector.X + 3.88d) / 1.06d + 64d)), (int)Math.Round(Conversion.Int(((double)-Vector.Y + 8.36d) / 1.06d + 52d)));
                }
                else
                {
                    Result = new Point((int)Math.Round(Conversion.Int(((double)-Vector.X + 3.88d) / 1.06d + 62d)), (int)Math.Round(Conversion.Int(((double)-Vector.Y + 8.36d) / 1.06d + 52d)));
                }
                XUp.X = 1f;
                YUp.Y = 1f;
            }
            else if (ShowRightLegOverlay && Vector.X < 0.12d && Vector.X > -4.12d && Vector.Y < -3.64d && Vector.Y > -16.36d && Vector.Z == 2.12f)
            {
                // ZLegs
                Result = new Point((int)Math.Round(Conversion.Int((Vector.X + 4.12d) / 1.06d + 4d)), (int)Math.Round(Conversion.Int(((double)-Vector.Y - 16.36d) / 1.06d + 48d)));
                XUp.X = 1f;
                YUp.Y = 1f;
            }
            else if (ShowRightLegOverlay && Vector.X < 0.12d && Vector.X > -4.12d && Vector.Y < -3.64d && Vector.Y > -16.36d && Vector.Z == -2.12f)
            {
                // ZLegs
                Result = new Point((int)Math.Round(Conversion.Int(((double)-Vector.X + 4.12d) / 1.06d + 8d)), (int)Math.Round(Conversion.Int(((double)-Vector.Y - 16.36d) / 1.06d + 48d)));
                XUp.X = 1f;
                YUp.Y = 1f;
            }
            else if (ShowLeftLegOverlay && Vector.X < 4.12d && Vector.X > -0.12d && Vector.Y < -3.64d && Vector.Y > -16.36d && Vector.Z == 2.12f)
            {
                // ZLegs
                Result = new Point((int)Math.Round(Conversion.Int((Vector.X + 0.12d) / 1.06d + 4d)), (int)Math.Round(Conversion.Int(((double)-Vector.Y - 3.64d) / 1.06d + 52d)));
                XUp.X = 1f;
                YUp.Y = 1f;
            }
            else if (ShowLeftLegOverlay && Vector.X < 4.12d && Vector.X > -0.12d && Vector.Y < -3.64d && Vector.Y > -16.36d && Vector.Z == -2.12f)
            {
                // ZLegs
                Result = new Point((int)Math.Round(Conversion.Int(((double)-Vector.X + 0.12d) / 1.06d + 16d)), (int)Math.Round(Conversion.Int(((double)-Vector.Y - 3.64d) / 1.06d + 52d)));
                XUp.X = 1f;
                YUp.Y = 1f;
            }
            else if (ShowHeadOverlay && Vector.Z < 4.24d && Vector.Z > -4.24d && Vector.Y < 16.24d && Vector.Y > 7.76d && Vector.X == 4.24f)
            {
                // XHead
                Result = new Point((int)Math.Round(Conversion.Int(((double)-Vector.Z + 4.24d) / 1.06d + 48d)), (int)Math.Round(Conversion.Int(((double)-Vector.Y + 16.24d) / 1.06d + 8d)));
                XUp.Z = 1f;
                YUp.Y = 1f;
            }
            else if (ShowHeadOverlay && Vector.Z < 4.24d && Vector.Z > -4.24d && Vector.Y < 16.24d && Vector.Y > 7.76d && Vector.X == -4.24f)
            {
                // XHead
                Result = new Point((int)Math.Round(Conversion.Int((Vector.Z + 4.24d) / 1.06d + 32d)), (int)Math.Round(Conversion.Int(((double)-Vector.Y + 16.24d) / 1.06d + 8d)));
                XUp.Z = 1f;
                YUp.Y = 1f;
            }
            else if (ShowBodyOverlay && Vector.Z < 2.12d && Vector.Z > -2.12d && Vector.Y < 8.36d && Vector.Y > -4.36d && Vector.X == 4.24f)
            {
                // XBody
                Result = new Point((int)Math.Round(Conversion.Int(((double)-Vector.Z + 2.12d) / 1.06d + 28d)), (int)Math.Round(Conversion.Int(((double)-Vector.Y + 8.36d) / 1.06d + 36d)));
                XUp.Z = 1f;
                YUp.Y = 1f;
            }
            else if (ShowBodyOverlay && Vector.Z < 2.12d && Vector.Z > -2.12d && Vector.Y < 8.36d && Vector.Y > -4.36d && Vector.X == -4.24f)
            {
                // XBody
                Result = new Point((int)Math.Round(Conversion.Int((Vector.Z + 2.12d) / 1.06d + 16d)), (int)Math.Round(Conversion.Int(((double)-Vector.Y + 8.36d) / 1.06d + 36d)));
                XUp.Z = 1f;
                YUp.Y = 1f;
            }
            else if (ShowLeftArmOverlay && Vector.Z < 2.12d && Vector.Z > -2.12d && Vector.Y < 8.36d && Vector.Y > -4.36d && (Vector.X == 8.12f || Vector.X == 7.09f))
            {
                // XArms
                if (Model == Models.Steve)
                {
                    Result = new Point((int)Math.Round(Conversion.Int(((double)-Vector.Z + 2.12d) / 1.06d + 56d)), (int)Math.Round(Conversion.Int(((double)-Vector.Y + 8.36d) / 1.06d + 52d)));
                }
                else
                {
                    Result = new Point((int)Math.Round(Conversion.Int(((double)-Vector.Z + 2.12d) / 1.06d + 55d)), (int)Math.Round(Conversion.Int(((double)-Vector.Y + 8.36d) / 1.06d + 52d)));
                }
                XUp.Z = 1f;
                YUp.Y = 1f;
            }
            else if (ShowRightArmOverlay && Vector.Z < 2.12d && Vector.Z > -2.12d && Vector.Y < 8.36d && Vector.Y > -4.36d && (Vector.X == -8.12f || Vector.X == -7.09f))
            {
                // XArms
                Result = new Point((int)Math.Round(Conversion.Int((Vector.Z + 2.12d) / 1.06d + 40d)), (int)Math.Round(Conversion.Int(((double)-Vector.Y + 8.36d) / 1.06d + 36d)));
                XUp.Z = 1f;
                YUp.Y = 1f;
            }
            else if (ShowLeftArmOverlay && Vector.Z < 2.12d && Vector.Z > -2.12d && Vector.Y < 8.36d && Vector.Y > -4.36d && (Vector.X == 3.88f || Vector.X == 3.91f))
            {
                // XArms
                Result = new Point((int)Math.Round(Conversion.Int((Vector.Z + 2.12d) / 1.06d + 48d)), (int)Math.Round(Conversion.Int(((double)-Vector.Y + 8.36d) / 1.06d + 52d)));
                XUp.Z = 1f;
                YUp.Y = 1f;
            }
            else if (ShowRightArmOverlay && Vector.Z < 2.12d && Vector.Z > -2.12d && Vector.Y < 8.36d && Vector.Y > -4.36d && (Vector.X == -3.88f || Vector.X == -3.91f))
            {
                // XArms
                if (Model == Models.Steve)
                {
                    Result = new Point((int)Math.Round(Conversion.Int(((double)-Vector.Z + 2.12d) / 1.06d + 48d)), (int)Math.Round(Conversion.Int(((double)-Vector.Y + 8.36d) / 1.06d + 36d)));
                }
                else
                {
                    Result = new Point((int)Math.Round(Conversion.Int(((double)-Vector.Z + 2.12d) / 1.06d + 47d)), (int)Math.Round(Conversion.Int(((double)-Vector.Y + 8.36d) / 1.06d + 36d)));
                }
                XUp.Z = 1f;
                YUp.Y = 1f;
            }
            else if (ShowLeftLegOverlay && Vector.Z < 2.12d && Vector.Z > -2.12d && Vector.Y < -3.64d && Vector.Y > -16.36d && Vector.X == 4.24f)
            {
                // XLeg
                Result = new Point((int)Math.Round(Conversion.Int(((double)-Vector.Z + 2.12d) / 1.06d + 8d)), (int)Math.Round(Conversion.Int(((double)-Vector.Y - 3.64d) / 1.06d + 52d)));
                XUp.Z = 1f;
                YUp.Y = 1f;
            }
            else if (ShowRightLegOverlay && Vector.Z < 2.12d && Vector.Z > -2.12d && Vector.Y < -3.64d && Vector.Y > -16.36d && Vector.X == -4.24f)
            {
                // XLeg
                Result = new Point((int)Math.Round(Conversion.Int((Vector.Z + 2.12d) / 1.06d)), (int)Math.Round(Conversion.Int(((double)-Vector.Y - 3.64d) / 1.06d + 36d)));
                XUp.Z = 1f;
                YUp.Y = 1f;
            }
            else if (ShowRightLegOverlay && Vector.Z < 2.12d && Vector.Z > -2.12d && Vector.Y < -3.64d && Vector.Y > -16.36d && Vector.X == 0.12f)
            {
                // XLeg
                Result = new Point((int)Math.Round(Conversion.Int(((double)-Vector.Z + 2.12d) / 1.06d + 8d)), (int)Math.Round(Conversion.Int(((double)-Vector.Y - 3.64d) / 1.06d + 36d)));
                XUp.Z = 1f;
                YUp.Y = 1f;
            }
            else if (ShowLeftLegOverlay && Vector.Z < 2.12d && Vector.Z > -2.12d && Vector.Y < -3.64d && Vector.Y > -16.36d && Vector.X == -0.12f)
            {
                // XLeg
                Result = new Point((int)Math.Round(Conversion.Int((Vector.Z + 2.12d) / 1.06d)), (int)Math.Round(Conversion.Int(((double)-Vector.Y - 3.64d) / 1.06d + 52d)));
                XUp.Z = 1f;
                YUp.Y = 1f;
            }
            else if (ShowHeadOverlay && Vector.Z < 4.24d && Vector.Z > -4.24d && Vector.X < 4.24d && Vector.X > -4.24d && Vector.Y == 16.24f)
            {
                // YHead
                Result = new Point((int)Math.Round(Conversion.Int((Vector.X + 4.24d) / 1.06d + 40d)), (int)Math.Round(Conversion.Int((Vector.Z + 4.24d) / 1.06d)));
                XUp.X = 1f;
                YUp.Z = 1f;
            }
            else if (ShowHeadOverlay && Vector.Z < 4.24d && Vector.Z > -4.24d && Vector.X < 4.24d && Vector.X > -4.24d && Vector.Y == 7.76f)
            {
                // YHead
                Result = new Point((int)Math.Round(Conversion.Int((Vector.X + 4.24d) / 1.06d + 48d)), (int)Math.Round(Conversion.Int((Vector.Z + 4.24d) / 1.06d)));
                XUp.X = 1f;
                YUp.Z = 1f;
            }
            else if (ShowBodyOverlay && Vector.Z < 2.12d && Vector.Z > -2.12d && Vector.X < 4.24d && Vector.X > -4.24d && Vector.Y == 8.36f)
            {
                // YBody
                Result = new Point((int)Math.Round(Conversion.Int((Vector.X + 4.24d) / 1.06d + 20d)), (int)Math.Round(Conversion.Int((Vector.Z + 2.12d) / 1.06d + 32d)));
                XUp.X = 1f;
                YUp.Z = 1f;
            }
            else if (ShowBodyOverlay && Vector.Z < 2.12d && Vector.Z > -2.12d && Vector.X < 4.24d && Vector.X > -4.24d && Vector.Y == -4.36f)
            {
                // YBody
                Result = new Point((int)Math.Round(Conversion.Int((Vector.X + 4.24d) / 1.06d + 28d)), (int)Math.Round(Conversion.Int((Vector.Z + 2.12d) / 1.06d + 32d)));
                XUp.X = 1f;
                YUp.Z = 1f;
            }
            else if (ShowLeftArmOverlay && Vector.Z < 2.12d && Vector.Z > -2.12d && Vector.X < 8.12d && Vector.X > 3.88d && Vector.Y == 8.36f)
            {
                // YArms
                Result = new Point((int)Math.Round(Conversion.Int((Vector.X - 3.88d) / 1.06d + 52d)), (int)Math.Round(Conversion.Int((Vector.Z + 2.12d) / 1.06d + 48d)));
                XUp.X = 1f;
                YUp.Z = 1f;
            }
            else if (ShowLeftArmOverlay && Vector.Z < 2.12d && Vector.Z > -2.12d && Vector.X < 8.12d && Vector.X > 3.88d && Vector.Y == -4.36f)
            {
                // YArms
                if (Model == Models.Steve)
                {
                    Result = new Point((int)Math.Round(Conversion.Int((Vector.X - 3.88d) / 1.06d + 56d)), (int)Math.Round(Conversion.Int((Vector.Z + 2.12d) / 1.06d + 48d)));
                }
                else
                {
                    Result = new Point((int)Math.Round(Conversion.Int((Vector.X - 3.88d) / 1.06d + 55d)), (int)Math.Round(Conversion.Int((Vector.Z + 2.12d) / 1.06d + 48d)));
                }
                XUp.X = 1f;
                YUp.Z = 1f;
            }
            else if (ShowRightArmOverlay && Vector.Z < 2.12d && Vector.Z > -2.12d && Vector.X < -3.88d && Vector.X > -8.12d && Vector.Y == 8.36f)
            {
                // YArms
                if (Model == Models.Steve)
                {
                    Result = new Point((int)Math.Round(Conversion.Int((Vector.X + 8.12d) / 1.06d + 44d)), (int)Math.Round(Conversion.Int((Vector.Z + 2.12d) / 1.06d + 32d)));
                }
                else
                {
                    Result = new Point((int)Math.Round(Conversion.Int((Vector.X + 8.12d) / 1.06d + 43d)), (int)Math.Round(Conversion.Int((Vector.Z + 2.12d) / 1.06d + 32d)));
                }
                XUp.X = 1f;
                YUp.Z = 1f;
            }
            else if (ShowRightArmOverlay && Vector.Z < 2.12d && Vector.Z > -2.12d && Vector.X < -3.88d && Vector.X > -8.12d && Vector.Y == -4.36f)
            {
                // YArms
                if (Model == Models.Steve)
                {
                    Result = new Point((int)Math.Round(Conversion.Int((Vector.X + 8.12d) / 1.06d + 48d)), (int)Math.Round(Conversion.Int((Vector.Z + 2.12d) / 1.06d + 32d)));
                }
                else
                {
                    Result = new Point((int)Math.Round(Conversion.Int((Vector.X + 8.12d) / 1.06d + 46d)), (int)Math.Round(Conversion.Int((Vector.Z + 2.12d) / 1.06d + 32d)));
                }
                XUp.X = 1f;
                YUp.Z = 1f;
            }
            else if (ShowLeftLegOverlay && Vector.Z < 2.12d && Vector.Z > -2.12d && Vector.X < 4.24d && Vector.X > -0.12d && Vector.Y == -3.64f)
            {
                // YLeg
                Result = new Point((int)Math.Round(Conversion.Int((Vector.X + 0.12d) / 1.06d + 4d)), (int)Math.Round(Conversion.Int((Vector.Z + 2.12d) / 1.06d + 48d)));
                XUp.X = 1f;
                YUp.Z = 1f;
            }
            else if (ShowRightLegOverlay && Vector.Z < 2.12d && Vector.Z > -2.12d && Vector.X < 0.12d && Vector.X > -4.24d && Vector.Y == -3.64f)
            {
                // YLeg
                Result = new Point((int)Math.Round(Conversion.Int((Vector.X + 4.24d) / 1.06d + 4d)), (int)Math.Round(Conversion.Int((Vector.Z + 2.12d) / 1.06d + 32d)));
                XUp.X = 1f;
                YUp.Z = 1f;
            }
            else if (ShowLeftLegOverlay && Vector.Z < 2.12d && Vector.Z > -2.12d && Vector.X < 4.24d && Vector.X > -0.12d && Vector.Y == -16.36f)
            {
                // YLeg
                Result = new Point((int)Math.Round(Conversion.Int((Vector.X + 0.12d) / 1.06d + 8d)), (int)Math.Round(Conversion.Int((Vector.Z + 2.12d) / 1.06d + 48d)));
                XUp.X = 1f;
                YUp.Z = 1f;
            }
            else if (ShowRightLegOverlay && Vector.Z < 2.12d && Vector.Z > -2.12d && Vector.X < 0.12d && Vector.X > -4.24d && Vector.Y == -16.36f)
            {
                // YLeg
                Result = new Point((int)Math.Round(Conversion.Int((Vector.X + 4.24d) / 1.06d + 8d)), (int)Math.Round(Conversion.Int((Vector.Z + 2.12d) / 1.06d + 32d)));
                XUp.X = 1f;
                YUp.Z = 1f;
            }

            return Result;
        }

        public object Get2DFrom3D(Vector3 Vector)
        {
            var argXUp = new Vector3();
            var argYUp = new Vector3();
            return Get2DFrom3D(Vector, ref argXUp, ref argYUp);
        }
        public object Get2nd2DFrom3D(Vector3 Vector)
        {
            var argXUp = new Vector3();
            var argYUp = new Vector3();
            return Get2nd2DFrom3D(Vector, ref argXUp, ref argYUp);
        }

        public enum SkinPlace
        {
            Head,
            Body,
            RArm,
            LArm,
            RLeg,
            LLeg,
            Head2,
            Body2,
            RArm2,
            LArm2,
            RLeg2,
            LLeg2
        }

        public void FloodFill(int x, int y, Color new_color)
        {
            // Get the old and new colors.
            var old_color = Texture.GetPixel(x, y);

            if (old_color.ToArgb() != new_color.ToArgb())
            {
                var CurrentPlace = default(SkinPlace);

                // Get the current section of the skin
                if (x < 32 && y < 16)
                {
                    CurrentPlace = SkinPlace.Head;
                }
                else if (x > 31 && y < 16)
                {
                    CurrentPlace = SkinPlace.Head2;
                }
                else if (x < 40 && x > 15 && y < 32 && y > 15)
                {
                    CurrentPlace = SkinPlace.Body;
                }
                else if (x < 40 && x > 15 && y < 48 && y > 31)
                {
                    CurrentPlace = SkinPlace.Body2;
                }
                else if (x < 56 && x > 39 && y < 32 && y > 15)
                {
                    CurrentPlace = SkinPlace.RArm;
                }
                else if (x < 56 && x > 39 && y < 48 && y > 31)
                {
                    CurrentPlace = SkinPlace.RArm2;
                }
                else if (x < 48 && x > 31 && y > 47)
                {
                    CurrentPlace = SkinPlace.LArm;
                }
                else if (x > 47 && y > 47)
                {
                    CurrentPlace = SkinPlace.LArm2;
                }
                else if (x < 16 && y < 32 && y > 15)
                {
                    CurrentPlace = SkinPlace.RLeg;
                }
                else if (x < 16 && y < 48 && y > 31)
                {
                    CurrentPlace = SkinPlace.RLeg2;
                }
                else if (x < 32 && x > 15 && y > 47)
                {
                    CurrentPlace = SkinPlace.LLeg;
                }
                else if (x < 16 && y > 47)
                {
                    CurrentPlace = SkinPlace.LLeg2;
                }

                var SkinSection = new Bitmap(16, 16);
                switch (CurrentPlace)
                {
                    case SkinPlace.Head:
                        {
                            SkinSection = Texture.Clone(new Rectangle(0, 0, 32, 16), Texture.PixelFormat);
                            break;
                        }
                    case SkinPlace.Head2:
                        {
                            SkinSection = Texture.Clone(new Rectangle(32, 0, 32, 16), Texture.PixelFormat);
                            x -= 32;
                            break;
                        }
                    case SkinPlace.Body:
                        {
                            SkinSection = Texture.Clone(new Rectangle(16, 16, 24, 16), Texture.PixelFormat);
                            x -= 16;
                            y -= 16;
                            break;
                        }
                    case SkinPlace.Body2:
                        {
                            SkinSection = Texture.Clone(new Rectangle(16, 32, 24, 16), Texture.PixelFormat);
                            x -= 16;
                            y -= 32;
                            break;
                        }
                    case SkinPlace.RArm:
                        {
                            if (Model == Models.Steve)
                            {
                                SkinSection = Texture.Clone(new Rectangle(40, 16, 16, 16), Texture.PixelFormat);
                            }
                            else
                            {
                                SkinSection = Texture.Clone(new Rectangle(40, 16, 14, 16), Texture.PixelFormat);
                            }
                            x -= 40;
                            y -= 16;
                            break;
                        }
                    case SkinPlace.RArm2:
                        {
                            if (Model == Models.Steve)
                            {
                                SkinSection = Texture.Clone(new Rectangle(40, 32, 16, 16), Texture.PixelFormat);
                            }
                            else
                            {
                                SkinSection = Texture.Clone(new Rectangle(40, 32, 14, 16), Texture.PixelFormat);
                            }
                            x -= 40;
                            y -= 32;
                            break;
                        }
                    case SkinPlace.LArm:
                        {
                            if (Model == Models.Steve)
                            {
                                SkinSection = Texture.Clone(new Rectangle(32, 48, 16, 16), Texture.PixelFormat);
                            }
                            else
                            {
                                SkinSection = Texture.Clone(new Rectangle(32, 48, 14, 16), Texture.PixelFormat);
                            }
                            x -= 32;
                            y -= 48;
                            break;
                        }
                    case SkinPlace.LArm2:
                        {
                            if (Model == Models.Steve)
                            {
                                SkinSection = Texture.Clone(new Rectangle(48, 48, 16, 16), Texture.PixelFormat);
                            }
                            else
                            {
                                SkinSection = Texture.Clone(new Rectangle(48, 48, 14, 16), Texture.PixelFormat);
                            }
                            x -= 48;
                            y -= 48;
                            break;
                        }
                    case SkinPlace.RLeg:
                        {
                            SkinSection = Texture.Clone(new Rectangle(0, 16, 16, 16), Texture.PixelFormat);
                            y -= 16;
                            break;
                        }
                    case SkinPlace.RLeg2:
                        {
                            SkinSection = Texture.Clone(new Rectangle(0, 32, 16, 16), Texture.PixelFormat);
                            y -= 32;
                            break;
                        }
                    case SkinPlace.LLeg:
                        {
                            SkinSection = Texture.Clone(new Rectangle(16, 48, 16, 16), Texture.PixelFormat);
                            x -= 16;
                            y -= 48;
                            break;
                        }
                    case SkinPlace.LLeg2:
                        {
                            SkinSection = Texture.Clone(new Rectangle(0, 48, 16, 16), Texture.PixelFormat);
                            y -= 48;
                            break;
                        }
                }

                var tmpSS = SkinSection;
                Graphics tmpG;
                switch (CurrentPlace)
                {
                    case SkinPlace.Head:
                    case SkinPlace.Head2:
                        {

                            tmpSS = new Bitmap(32, 24);
                            tmpG = Graphics.FromImage(tmpSS);
                            tmpG.DrawImage(SkinSection, 0, 0);
                            tmpG.FillRectangle(new SolidBrush(Color.Transparent), 16, 0, 8, 8);
                            tmpG.DrawImage(SkinSection, new Rectangle(8, 16, 8, 8), new Rectangle(16, 8, 8, -8), GraphicsUnit.Pixel);
                            if (x < 24 && x >= 16 && y < 8)
                            {
                                x -= 8;
                                y = Math.Abs(y - 7) + 16;
                            }

                            break;
                        }

                    case SkinPlace.Body:
                    case SkinPlace.Body2:
                        {

                            tmpSS = new Bitmap(24, 20);
                            tmpG = Graphics.FromImage(tmpSS);
                            tmpG.DrawImage(SkinSection, 0, 0);
                            tmpG.FillRectangle(new SolidBrush(Color.Transparent), 12, 0, 8, 4);
                            tmpG.DrawImage(SkinSection, new Rectangle(4, 16, 8, 4), new Rectangle(12, 4, 8, -4), GraphicsUnit.Pixel);
                            if (x < 20 && x >= 12 && y < 4)
                            {
                                x -= 8;
                                y = Math.Abs(y - 3) + 16;
                            }

                            break;
                        }

                    case SkinPlace.LArm:
                    case SkinPlace.LArm2:
                    case SkinPlace.RArm:
                    case SkinPlace.RArm2:
                    case SkinPlace.LLeg:
                    case SkinPlace.LLeg2:
                    case SkinPlace.RLeg:
                    case SkinPlace.RLeg2:
                        {

                            if (Model == Models.Alex && (CurrentPlace == SkinPlace.LArm || CurrentPlace == SkinPlace.LArm2 || CurrentPlace == SkinPlace.RArm || CurrentPlace == SkinPlace.RArm2))
                            {
                                tmpSS = new Bitmap(14, 20);
                                tmpG = Graphics.FromImage(tmpSS);
                                tmpG.DrawImage(SkinSection, 0, 0);
                                tmpG.FillRectangle(new SolidBrush(Color.Transparent), 7, 0, 3, 4);
                                tmpG.DrawImage(SkinSection, new Rectangle(4, 16, 3, 4), new Rectangle(7, 4, 3, -4), GraphicsUnit.Pixel);
                                if (x < 10 && x >= 7 && y < 4)
                                {
                                    x -= 3;
                                    y = Math.Abs(y - 3) + 16;
                                }
                            }
                            else
                            {
                                tmpSS = new Bitmap(16, 20);
                                tmpG = Graphics.FromImage(tmpSS);
                                tmpG.DrawImage(SkinSection, 0, 0);
                                tmpG.FillRectangle(new SolidBrush(Color.Transparent), 8, 0, 4, 4);
                                tmpG.DrawImage(SkinSection, new Rectangle(4, 16, 4, 4), new Rectangle(8, 4, 4, -4), GraphicsUnit.Pixel);
                                if (x < 12 && x >= 8 && y < 4)
                                {
                                    x -= 4;
                                    y = Math.Abs(y - 3) + 16;
                                }
                            }

                            break;
                        }

                }

                SkinSection = tmpSS;

                // Start with the original point in the stack.
                var pts = new Stack();
                pts.Push(new Point(x, y));
                SkinSection.SetPixel(x, y, new_color);

                // While the stack is not empty, process a point.
                while (pts.Count > 0)
                {
                    Point pt = (Point)pts.Pop();
                    CheckPoint(ref SkinSection, CurrentPlace, pts, pt.X - 1, pt.Y, old_color, new_color);
                    CheckPoint(ref SkinSection, CurrentPlace, pts, pt.X, pt.Y - 1, old_color, new_color);
                    CheckPoint(ref SkinSection, CurrentPlace, pts, pt.X + 1, pt.Y, old_color, new_color);
                    CheckPoint(ref SkinSection, CurrentPlace, pts, pt.X, pt.Y + 1, old_color, new_color);
                }

                switch (CurrentPlace)
                {
                    case SkinPlace.Head:
                    case SkinPlace.Head2:
                        {

                            tmpSS = new Bitmap(32, 16);
                            tmpG = Graphics.FromImage(tmpSS);
                            tmpG.DrawImage(SkinSection, 0, 0);
                            tmpG.DrawImage(SkinSection, new Rectangle(16, 8, 8, -8), new Rectangle(8, 16, 8, 8), GraphicsUnit.Pixel);
                            break;
                        }

                    case SkinPlace.Body:
                    case SkinPlace.Body2:
                        {

                            tmpSS = new Bitmap(24, 16);
                            tmpG = Graphics.FromImage(tmpSS);
                            tmpG.DrawImage(SkinSection, 0, 0);
                            tmpG.DrawImage(SkinSection, new Rectangle(12, 4, 8, -4), new Rectangle(4, 16, 8, 4), GraphicsUnit.Pixel);
                            break;
                        }

                    case SkinPlace.LArm:
                    case SkinPlace.LArm2:
                    case SkinPlace.RArm:
                    case SkinPlace.RArm2:
                    case SkinPlace.LLeg:
                    case SkinPlace.LLeg2:
                    case SkinPlace.RLeg:
                    case SkinPlace.RLeg2:
                        {

                            if (Model == Models.Alex && (CurrentPlace == SkinPlace.LArm || CurrentPlace == SkinPlace.LArm2 || CurrentPlace == SkinPlace.RArm || CurrentPlace == SkinPlace.RArm2))
                            {
                                tmpSS = new Bitmap(14, 16);
                                tmpG = Graphics.FromImage(tmpSS);
                                tmpG.DrawImage(SkinSection, 0, 0);
                                tmpG.DrawImage(SkinSection, new Rectangle(7, 4, 3, -4), new Rectangle(4, 16, 3, 4), GraphicsUnit.Pixel);
                            }
                            else
                            {
                                tmpSS = new Bitmap(16, 16);
                                tmpG = Graphics.FromImage(tmpSS);
                                tmpG.DrawImage(SkinSection, 0, 0);
                                tmpG.DrawImage(SkinSection, new Rectangle(8, 4, 4, -4), new Rectangle(4, 16, 4, 4), GraphicsUnit.Pixel);
                            }

                            break;
                        }

                }

                tmpG = Graphics.FromImage(Texture);
                switch (CurrentPlace)
                {
                    case SkinPlace.Head:
                        {
                            TransparentFill(Texture, new Rectangle(0, 0, 32, 16));
                            tmpG.DrawImage(tmpSS, 0, 0, 32, 16);
                            break;
                        }
                    case SkinPlace.Head2:
                        {
                            TransparentFill(Texture, new Rectangle(32, 0, 32, 16));
                            tmpG.DrawImage(tmpSS, 32, 0, 32, 16);
                            break;
                        }
                    case SkinPlace.Body:
                        {
                            TransparentFill(Texture, new Rectangle(16, 16, 24, 16));
                            tmpG.DrawImage(tmpSS, 16, 16, 24, 16);
                            break;
                        }
                    case SkinPlace.Body2:
                        {
                            TransparentFill(Texture, new Rectangle(16, 32, 24, 16));
                            tmpG.DrawImage(tmpSS, 16, 32, 24, 16);
                            break;
                        }
                    case SkinPlace.RArm:
                        {
                            if (Model == Models.Steve)
                            {
                                TransparentFill(Texture, new Rectangle(40, 16, 16, 16));
                                tmpG.DrawImage(tmpSS, 40, 16, 16, 16);
                            }
                            else
                            {
                                TransparentFill(Texture, new Rectangle(40, 16, 14, 16));
                                tmpG.DrawImage(tmpSS, 40, 16, 14, 16);
                            }

                            break;
                        }
                    case SkinPlace.RArm2:
                        {
                            if (Model == Models.Steve)
                            {
                                TransparentFill(Texture, new Rectangle(40, 32, 16, 16));
                                tmpG.DrawImage(tmpSS, 40, 32, 16, 16);
                            }
                            else
                            {
                                TransparentFill(Texture, new Rectangle(40, 32, 14, 16));
                                tmpG.DrawImage(tmpSS, 40, 32, 14, 16);
                            }

                            break;
                        }
                    case SkinPlace.LArm:
                        {
                            if (Model == Models.Steve)
                            {
                                TransparentFill(Texture, new Rectangle(32, 48, 16, 16));
                                tmpG.DrawImage(tmpSS, 32, 48, 16, 16);
                            }
                            else
                            {
                                TransparentFill(Texture, new Rectangle(32, 48, 14, 16));
                                tmpG.DrawImage(tmpSS, 32, 48, 14, 16);
                            }

                            break;
                        }
                    case SkinPlace.LArm2:
                        {
                            if (Model == Models.Steve)
                            {
                                TransparentFill(Texture, new Rectangle(48, 48, 16, 16));
                                tmpG.DrawImage(tmpSS, 48, 48, 16, 16);
                            }
                            else
                            {
                                TransparentFill(Texture, new Rectangle(48, 48, 14, 16));
                                tmpG.DrawImage(tmpSS, 48, 48, 14, 16);
                            }

                            break;
                        }
                    case SkinPlace.RLeg:
                        {
                            TransparentFill(Texture, new Rectangle(0, 16, 16, 16));
                            tmpG.DrawImage(tmpSS, 0, 16, 16, 16);
                            break;
                        }
                    case SkinPlace.RLeg2:
                        {
                            TransparentFill(Texture, new Rectangle(0, 32, 16, 16));
                            tmpG.DrawImage(tmpSS, 0, 32, 16, 16);
                            break;
                        }
                    case SkinPlace.LLeg:
                        {
                            TransparentFill(Texture, new Rectangle(16, 48, 16, 16));
                            tmpG.DrawImage(tmpSS, 16, 48, 16, 16);
                            break;
                        }
                    case SkinPlace.LLeg2:
                        {
                            TransparentFill(Texture, new Rectangle(0, 48, 16, 16));
                            tmpG.DrawImage(tmpSS, 0, 48, 16, 16);
                            break;
                        }
                }
                tmpG.Dispose();
                tmpSS.Dispose();
            }
        }
        private Random _CheckPoint_rNumber = new Random();

        // See if this point should be added to the stack.
        public void CheckPoint(ref Bitmap SkinSection, SkinPlace SkinPlace, Stack pts, int x, int y, Color old_color, Color new_color)
        {
            // Correct the point
            switch (SkinPlace)
            {
                case SkinPlace.Head:
                case SkinPlace.Head2:
                    {
                        if (x == -1)
                            x = 31;
                        if (x == 32)
                            x = 0;

                        if (y == -1)
                        {
                            x = Math.Abs(x - 16) + 23;
                            y = 8;
                        }
                        else if (y == 24)
                        {
                            x = Math.Abs(x - 16) + 23;
                            y = 15;
                        }

                        if (y == 7)
                        {

                            if (x > 23)
                            {
                                x = Math.Abs(x - 32) + 7;
                                y = 0;
                            }
                            else if (x > 15 && x < 24)
                            {
                                y = Math.Abs(x - 23);
                                x = 15;
                            }
                            else if (x < 8)
                            {
                                y = x;
                                x = 8;
                            }
                        }

                        else if (y == 16)
                        {

                            if (x > 23)
                            {
                                x = Math.Abs(x - 32) + 7;
                                y = 23;
                            }
                            else if (x > 15 && x < 24)
                            {
                                y = x;
                                x = 15;
                            }
                            else if (x < 8)
                            {
                                y = Math.Abs(x - 7) + 16;
                                x = 8;
                            }

                        }

                        if (x == 16)
                        {

                            if (y < 8)
                            {
                                x = Math.Abs(y - 7) + 16;
                                y = 8;
                            }
                            else if (y > 15)
                            {
                                x = y;
                                y = 15;
                            }
                        }

                        else if (x == 7)
                        {

                            if (y < 8)
                            {
                                x = y;
                                y = 8;
                            }
                            else if (y > 15)
                            {
                                x = Math.Abs(y - 23);
                                y = 15;
                            }

                        }

                        break;
                    }

                case SkinPlace.Body:
                case SkinPlace.Body2:
                    {
                        if (x == -1)
                            x = 23;
                        if (x == 24)
                            x = 0;

                        if (y == -1)
                        {
                            x = Math.Abs(x - 12) + 15;
                            y = 4;
                        }
                        else if (y == 20)
                        {
                            x = Math.Abs(x - 12) + 15;
                            y = 15;
                        }

                        if (y == 3)
                        {

                            if (x > 15)
                            {
                                x = Math.Abs(x - 24) + 3;
                                y = 0;
                            }
                            else if (x > 11 && x < 16)
                            {
                                y = Math.Abs(x - 15);
                                x = 11;
                            }
                            else if (x < 4)
                            {
                                y = x;
                                x = 4;
                            }
                        }

                        else if (y == 16)
                        {

                            if (x > 15)
                            {
                                x = Math.Abs(x - 24) + 3;
                                y = 19;
                            }
                            else if (x > 11 && x < 16)
                            {
                                y = x + 4;
                                x = 11;
                            }
                            else if (x < 4)
                            {
                                y = Math.Abs(x - 3) + 16;
                                x = 4;
                            }

                        }

                        if (x == 12)
                        {

                            if (y < 4)
                            {
                                x = Math.Abs(y - 3) + 12;
                                y = 4;
                            }
                            else if (y > 15)
                            {
                                x = y - 4;
                                y = 15;
                            }
                        }

                        else if (x == 3)
                        {

                            if (y < 4)
                            {
                                x = y;
                                y = 4;
                            }
                            else if (y > 15)
                            {
                                x = Math.Abs(y - 19);
                                y = 15;
                            }

                        }

                        break;
                    }

                case SkinPlace.LArm:
                case SkinPlace.LArm2:
                case SkinPlace.RArm:
                case SkinPlace.RArm2:
                case SkinPlace.LLeg:
                case SkinPlace.LLeg2:
                case SkinPlace.RLeg:
                case SkinPlace.RLeg2:
                    {

                        if (Model == Models.Alex && (SkinPlace == SkinPlace.LArm || SkinPlace == SkinPlace.LArm2 || SkinPlace == SkinPlace.RArm || SkinPlace == SkinPlace.RArm2))
                        {
                            if (x == -1)
                                x = 13;
                            if (x == 14)
                                x = 0;

                            if (y == -1)
                            {
                                x = Math.Abs(x - 6) + 11;
                                y = 4;
                            }
                            else if (y == 20)
                            {
                                x = Math.Abs(x - 6) + 11;
                                y = 15;
                            }

                            if (y == 3)
                            {

                                if (x > 10)
                                {
                                    x = Math.Abs(x - 14) + 3;
                                    y = 0;
                                }
                                else if (x > 6 && x < 11)
                                {
                                    y = Math.Abs(x - 10);
                                    x = 6;
                                }
                                else if (x < 4)
                                {
                                    y = x;
                                    x = 4;
                                }
                            }

                            else if (y == 16)
                            {

                                if (x > 10)
                                {
                                    x = Math.Abs(x - 13) + 4;
                                    y = 19;
                                }
                                else if (x > 6 && x < 11)
                                {
                                    y = x + 9;
                                    x = 6;
                                }
                                else if (x < 4)
                                {
                                    y = Math.Abs(x - 3) + 16;
                                    x = 4;
                                }

                            }

                            if (x == 7)
                            {

                                if (y < 4)
                                {
                                    x = Math.Abs(y - 3) + 7;
                                    y = 4;
                                }
                                else if (y > 15)
                                {
                                    x = y - 9;
                                    y = 15;
                                }
                            }

                            else if (x == 3)
                            {

                                if (y < 4)
                                {
                                    x = y;
                                    y = 4;
                                }
                                else if (y > 15)
                                {
                                    x = Math.Abs(y - 19);
                                    y = 15;
                                }

                            }
                        }
                        else
                        {
                            if (x == -1)
                                x = 15;
                            if (x == 16)
                                x = 0;

                            if (y == -1)
                            {
                                x = Math.Abs(x - 7) + 12;
                                y = 4;
                            }
                            else if (y == 20)
                            {
                                x = Math.Abs(x - 7) + 12;
                                y = 15;
                            }

                            if (y == 3)
                            {

                                if (x > 11)
                                {
                                    x = Math.Abs(x - 16) + 3;
                                    y = 0;
                                }
                                else if (x > 7 && x < 12)
                                {
                                    y = Math.Abs(x - 11);
                                    x = 7;
                                }
                                else if (x < 4)
                                {
                                    y = x;
                                    x = 4;
                                }
                            }

                            else if (y == 16)
                            {

                                if (x > 10)
                                {
                                    x = Math.Abs(x - 16) + 3;
                                    y = 19;
                                }
                                else if (x > 7 && x < 12)
                                {
                                    y = x + 8;
                                    x = 7;
                                }
                                else if (x < 4)
                                {
                                    y = Math.Abs(x - 3) + 16;
                                    x = 4;
                                }

                            }

                            if (x == 8)
                            {

                                if (y < 4)
                                {
                                    x = Math.Abs(y - 3) + 8;
                                    y = 4;
                                }
                                else if (y > 15)
                                {
                                    x = y - 8;
                                    y = 15;
                                }
                            }

                            else if (x == 3)
                            {

                                if (y < 4)
                                {
                                    x = y;
                                    y = 4;
                                }
                                else if (y > 15)
                                {
                                    x = Math.Abs(y - 19);
                                    y = 15;
                                }

                            }
                        }

                        break;
                    }

            }

            var clr = SkinSection.GetPixel(x, y);
            if (clr.Equals(old_color))
            {
                pts.Push(new Point(x, y));

                var Color = new_color;

                SkinSection.SetPixel(x, y, Color);
            }
        }

        public void TransparentFill(Bitmap B, Rectangle R)
        {
            using (var g = Graphics.FromImage(B))
            {
                var originClip = g.Clip;
                g.Clip = new Region(R);
                g.FillRectangle(new SolidBrush(Color.Transparent), R);
                g.Clip = originClip;
            }
        }
    }
}

