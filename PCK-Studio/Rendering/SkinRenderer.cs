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
using System;
using System.Collections.Generic;
using System.Diagnostics;
using OpenTK;
using PckStudio.Internal;
using PckStudio.Extensions;
using OpenTK.Graphics.OpenGL;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using PckStudio.Properties;
using PckStudio.Forms.Editor;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Drawing.Imaging;
using System.IO;
using PckStudio.Rendering.Camera;
using PckStudio.Rendering.Texture;

namespace PckStudio.Rendering
{
    internal partial class SkinRenderer : Renderer3D
    {
        /// <summary>
        /// The visible Texture on the renderer
        /// </summary>
        /// <returns>The visible Texture</returns>
        [Description("The current Texture")]
        [Category("Appearance")]
        public Image Texture
        {
            get => _texture;
            set
            {
                var args = new TextureChangingEventArgs(value);
                Events[nameof(TextureChanging)]?.DynamicInvoke(this, args);
                if (!args.Cancel)
                {
                    RenderTexture = _texture = value; 
                }
            }
        }

        public bool ClampModel { get; set; } = false;

        [Description("Event that gets fired when the Texture is changing")]
        [Category("Property Chnaged")]
        [Browsable(true)]
        public event EventHandler<TextureChangingEventArgs> TextureChanging
        {
            add => Events.AddHandler(nameof(TextureChanging), value);
            remove => Events.RemoveHandler(nameof(TextureChanging), value);
        }

        public SkinANIM ANIM
        {
            get => _anim;
            set
            {
                _anim = value;
                OnANIMUpdate();
            }
        }

        public ObservableCollection<SkinBOX> ModelData { get; }

        private Vector2 CameraTarget
        {
            get => camera.Position;
            set
            {
                if (ClampModel)
                    value = Vector2.Clamp(value, new Vector2(camera.Distance / 2f * -1), new Vector2(camera.Distance / 2f));
                camera.LookAt(value);
            }
        }

        private Vector2 _globalModelRotation;
        private Vector2 GlobalModelRotation
        {
            get => _globalModelRotation;
            set
            {
                _globalModelRotation.X = MathHelper.Clamp(value.X, -30f, 30f);
                _globalModelRotation.Y = value.Y % 360f;
            }
        }

        public Size TextureSize { get; private set; } = new Size(64, 64);
        private const float OverlayScale = 1.12f;

        private bool _isLeftMouseDown;
        private bool _isRightMouseDown;

        private Image RenderTexture
        {
            set
            {
                if (value is not null && HasValidContext && _skinShader is not null)
                {
                    MakeCurrent();
                    TextureSize = value.Width == value.Height ? new Size(64, 64) : new Size(64, 32);
                    UvTranslation = value.Width == value.Height ? new Vector2(1f / 64) : new Vector2(1f / 64, 1f / 32);
                    var texture = new Texture2D(value);
                    _skinShader.Bind();
                    _skinShader.SetUniform1("u_Texture", 0);
                    Refresh();
                }
            }
        }

        private bool IsMouseHidden
        {
            get => !Cursor.IsVisible();
            set
            {
                if (value)
                {
                    Cursor.Hide();
                    return;
                }
                Cursor.Show();
            }
        }
        private Point PreviousMouseLocation;
        private Point CurrentMouseLocation;

        private Shader _skinShader;
        private SkinANIM _anim;
        private Image _texture;

        private Shader _skyboxShader;
        private RenderBuffer _skyboxRenderBuffer;
        private CubeTexture _skyboxTexture;
        private float skyboxRotation = 0f;
        private float skyboxRotationStep = 0.5f;

        private Dictionary<string, CubeRenderGroup> additionalModelRenderGroups;
        private Dictionary<string, float> partOffset;
        private CubeRenderGroup head;
        private CubeRenderGroup body;
        private CubeRenderGroup rightArm;
        private CubeRenderGroup leftArm;
        private CubeRenderGroup rightLeg;
        private CubeRenderGroup leftLeg;

        private CubeRenderGroup headOverlay;
        private CubeRenderGroup bodyOverlay;
        private CubeRenderGroup rightArmOverlay;
        private CubeRenderGroup leftArmOverlay;
        private CubeRenderGroup rightLegOverlay;
        private CubeRenderGroup leftLegOverlay;

        private float animationCurrentRotationAngle;
        private float animationRotationStep = 0.5f;
        private float animationMaxAngleInDegrees = 5f;

        private bool showWireFrame = false;

        internal Matrix4 HeadMatrix { get; set; } = Matrix4.Identity;
        internal Matrix4 BodyMatrix { get; set; } = Matrix4.Identity;
        internal Matrix4 RightArmMatrix { get; set; } = Matrix4.CreateFromAxisAngle(Vector3.UnitZ,  25f);
        internal Matrix4 LeftArmMatrix  { get; set; } = Matrix4.CreateFromAxisAngle(Vector3.UnitZ, -25f);
        internal Matrix4 RightLegMatrix { get; set; } = Matrix4.Identity;
        internal Matrix4 LeftLegMatrix { get; set; } = Matrix4.Identity;

        public SkinRenderer() : base()
        {
            InitializeComponent();
            InitializeCamera();
            InitializeSkinData();
            ModelData = new ObservableCollection<SkinBOX>();
            ModelData.CollectionChanged += ModelData_CollectionChanged;
            additionalModelRenderGroups = new Dictionary<string, CubeRenderGroup>(6)
            {
                { "HEAD", head },
                { "BODY", body },
                { "ARM0", rightArm },
                { "ARM1", leftArm },
                { "LEG0", rightLeg },
                { "LEG1", leftLeg },

                { "HEADWEAR", headOverlay },
                { "JACKET"  , bodyOverlay },
                { "SLEEVE0" , rightArmOverlay },
                { "SLEEVE1" , leftArmOverlay },
                { "PANTS0"  , rightLegOverlay },
                { "PANTS1"  , leftLegOverlay },

                { "BODYARMOR", new CubeRenderGroup("BODYARMOR") },
                { "BELT",      new CubeRenderGroup("BELT") },
            };
            
            partOffset = new Dictionary<string, float>()
            {
                { "HEAD", 0f },
                { "BODY", 0f },
                { "ARM0", 0f },
                { "ARM1", 0f },
                { "LEG0", 0f },
                { "LEG1", 0f },

                { "HEADWEAR" , 0f },
                { "JACKET"   , 0f },
                { "SLEEVE0"  , 0f },
                { "SLEEVE1"  , 0f },
                { "PANTS0"   , 0f },
                { "PANTS1"   , 0f },

                { "BODYARMOR", 0f },
                { "BELT"     , 0f },
            };
        }

        public void SetPartOffset(ModelOffset offset)
        {
            SetPartOffset(offset.Name, offset.Value);
        }

        public void SetPartOffset(string name, float value)
        {
            if (!partOffset.ContainsKey(name))
            {
                Debug.WriteLine($"'{name}' is not inside {nameof(partOffset)}");
                return;
            }
            partOffset[name] = value;
        }

        private float GetOffset(string name)
        {
            return partOffset.ContainsKey(name) ? partOffset[name] : 0f;
        }

        private void ModelData_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action != NotifyCollectionChangedAction.Move &&
                e.Action != NotifyCollectionChangedAction.Reset)
            {
                UpdateModelData();
            }
        }

        // TODO: calculate CameraDistance based on model size
        private const float DefaultCameraDistance = 64f;
        private void InitializeCamera()
        {
            camera = new PerspectiveCamera(new Vector2(0f, 5f), DefaultCameraDistance, Vector2.Zero, 60f)
            {
                MinimumFov = 30f,
                MaximumFov = 90f,
            };
        }

        private void InitializeSkinData()
        {
            head ??= new CubeRenderGroup("Head");
            head.AddCube(new(-4, -8, -4), new(8, 8, 8), new(0, 0), flipZMapping: true);
            head.Submit();
            
            headOverlay ??= new CubeRenderGroup("Head Overlay", OverlayScale);
            headOverlay.AddCube(new(-4, -8, -4), new(8, 8, 8), new(32, 0), flipZMapping: true, scale: OverlayScale);
            headOverlay.Submit();

            body ??= new CubeRenderGroup("Body");
            body.AddCube(new(-4, 0, -2), new(8, 12, 4), new(16, 16));
            body.Submit();
            
            bodyOverlay ??= new CubeRenderGroup("Body Overlay", OverlayScale);
            bodyOverlay.AddCube(new(-4, 0, -2), new(8, 12, 4), new(16, 32), scale: OverlayScale);
            bodyOverlay.Submit();

            rightArm ??= new CubeRenderGroup("Right Arm");
            rightArm.AddCube(new(-3, -2, -2), new(4, 12, 4), new(40, 16));
            rightArm.Submit();
            
            rightArmOverlay ??= new CubeRenderGroup("Right Arm Overlay", OverlayScale);
            rightArmOverlay.AddCube(new(-3, -2, -2), new(4, 12, 4), new(40, 32), scale: OverlayScale);
            rightArmOverlay.Submit();
            
            leftArm ??= new CubeRenderGroup("Left Arm");
            leftArm.AddCube(new(-1, -2, -2), new(4, 12, 4), new(32, 48));
            leftArm.Submit();

            leftArmOverlay ??= new CubeRenderGroup("Left Arm Overlay", OverlayScale);
            leftArmOverlay.AddCube(new(-1, -2, -2), new(4, 12, 4), new(48, 48), scale: OverlayScale);
            leftArmOverlay.Submit();

            rightLeg ??= new CubeRenderGroup("Right Leg");
            rightLeg.AddCube(new(-2, 0, -2), new(4, 12, 4), new(0, 16));
            rightLeg.Submit();

            rightLegOverlay ??= new CubeRenderGroup("Right Leg Overlay", OverlayScale);
            rightLegOverlay.AddCube(new(-2, 0, -2), new(4, 12, 4), new(0, 32), scale: OverlayScale);
            rightLegOverlay.Submit();

            leftLeg ??= new CubeRenderGroup("Left Leg");
            leftLeg.AddCube(new(-2, 0, -2), new(4, 12, 4), new(16, 48));
            leftLeg.Submit();

            leftLegOverlay ??= new CubeRenderGroup("Left Leg Overlay", OverlayScale);
            leftLegOverlay.AddCube(new(-2, 0, -2), new(4, 12, 4), new(0, 48), scale: OverlayScale);
            leftLegOverlay.Submit();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (DesignMode)
                return;

            // use backing field to not raise OnANIMUpdate
            _anim ??= new SkinANIM();
            MakeCurrent();

            Trace.TraceInformation(GL.GetString(StringName.Version));

            // Initialize skybox shader
            {
                Vector3[] cubeVertices = new Vector3[]
                {
                    // front
                    new Vector3(-1.0f, -1.0f,  1.0f),
                    new Vector3( 1.0f, -1.0f,  1.0f),
                    new Vector3( 1.0f,  1.0f,  1.0f),
                    new Vector3(-1.0f,  1.0f,  1.0f),
                    // back
                    new Vector3(-1.0f, -1.0f, -1.0f),
                    new Vector3( 1.0f, -1.0f, -1.0f),
                    new Vector3( 1.0f,  1.0f, -1.0f),
                    new Vector3(-1.0f,  1.0f, -1.0f)
                };

                var skyboxVAO = new VertexArray();
                var skyboxVBO = new VertexBuffer<Vector3>(cubeVertices, cubeVertices.Length * Vector3.SizeInBytes);
                var vboLayout = new VertexBufferLayout();
                vboLayout.Add<float>(3);
                skyboxVAO.AddBuffer(skyboxVBO, vboLayout);
                var skybocIBO = IndexBuffer.Create(
                    // front
                    0, 1, 2,
                    2, 3, 0,
                    // right
                    1, 5, 6,
                    6, 2, 1,
                    // back
                    7, 6, 5,
                    5, 4, 7,
                    // left
                    4, 0, 3,
                    3, 7, 4,
                    // bottom
                    4, 5, 1,
                    1, 0, 4,
                    // top
                    3, 2, 6,
                    6, 7, 3);

                _skyboxRenderBuffer = new RenderBuffer(skyboxVAO, skybocIBO, PrimitiveType.Triangles);

                skyboxVAO.Unbind();
                skybocIBO.Unbind();

                string customSkyboxFilepath = Path.Combine(Program.AppData, "cubemap.png");
                Image skyboxImage = File.Exists(customSkyboxFilepath)
                    ? Image.FromFile(customSkyboxFilepath)
                    : Resources.DefaultSkyTexture;

                _skyboxTexture = new CubeTexture(skyboxImage);

                _skyboxShader = Shader.Create(Resources.skyboxVertexShader, Resources.skyboxFragmentShader);
                _skyboxShader.Bind();
                _skyboxShader.SetUniform1("skybox", 1);
                _skyboxShader.Validate();

                GLErrorCheck();
            }

            // Initialize skin shader
            {
                _skinShader = Shader.Create(
                    new ShaderSource(ShaderType.VertexShader, Resources.skinVertexShader),
                    new ShaderSource(ShaderType.FragmentShader, Resources.skinFragmentShader),
                    new ShaderSource(ShaderType.GeometryShader, Resources.skinGeometryShader)
                    );
                _skinShader.Bind();
                _skinShader.Validate();
            
                Texture ??= Resources.classic_template;
                RenderTexture = Texture;

                GLErrorCheck();
            }
        }

        public void UpdateModelData()
        {
            ReInitialzeSkinData();
            Refresh();
        }

        private void AddCustomModelPart(SkinBOX skinBox)
        {
            if (!additionalModelRenderGroups.ContainsKey(skinBox.Type))
                throw new KeyNotFoundException(skinBox.Type);

            CubeRenderGroup group = additionalModelRenderGroups[skinBox.Type];
            group.AddSkinBox(skinBox);
            group.Validate(TextureSize);
            group.Submit();
        }

        [Conditional("DEBUG")]
        private void GLErrorCheck()
        {
            var error = GL.GetError();
            Debug.Assert(error == ErrorCode.NoError, error.ToString());
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Escape:
                    ReleaseMouse();
                    var point = new Point(Parent.Location.X + Location.X, Parent.Location.Y + Location.Y);
                    contextMenuStrip1.Show(point);
                    return true;
                case Keys.F3:
                    showWireFrame = !showWireFrame;
                    return true;
                case Keys.R:
                    GlobalModelRotation = Vector2.Zero;
                    CameraTarget = Vector2.Zero;
                    camera.Distance = DefaultCameraDistance;
                    Refresh();
                    return true;
                case Keys.A:
                    ReleaseMouse();
                    {
                        using var animeditor = new ANIMEditor(ANIM);
                        if (animeditor.ShowDialog() == DialogResult.OK)
                        {
                            ANIM = animeditor.ResultAnim;
                            Refresh();
                        }
                    }
                    return true;
            }
            return base.ProcessDialogKey(keyData);
        }

        private void ReleaseMouse()
        {
            if (IsMouseHidden || _isLeftMouseDown || _isRightMouseDown)
            {
                IsMouseHidden = _isRightMouseDown = _isLeftMouseDown = false;
                Cursor.Position = PreviousMouseLocation;
            }
        }

        private void OnANIMUpdate()
        {
            head.SetEnabled(0, !ANIM.GetFlag(SkinAnimFlag.HEAD_DISABLED));
            headOverlay.SetEnabled(0, !ANIM.GetFlag(SkinAnimFlag.HEAD_OVERLAY_DISABLED));
            
            body.SetEnabled(0, !ANIM.GetFlag(SkinAnimFlag.BODY_DISABLED));
            rightArm.SetEnabled(0, !ANIM.GetFlag(SkinAnimFlag.RIGHT_ARM_DISABLED));
            leftArm.SetEnabled(0, !ANIM.GetFlag(SkinAnimFlag.LEFT_ARM_DISABLED));
            rightLeg.SetEnabled(0, !ANIM.GetFlag(SkinAnimFlag.RIGHT_LEG_DISABLED));
            leftLeg.SetEnabled(0, !ANIM.GetFlag(SkinAnimFlag.LEFT_LEG_DISABLED));

            bool slim = ANIM.GetFlag(SkinAnimFlag.SLIM_MODEL);
            if (slim || ANIM.GetFlag(SkinAnimFlag.RESOLUTION_64x64))
            {
                TextureSize = new Size(64, 64);
                bodyOverlay.SetEnabled(0, !ANIM.GetFlag(SkinAnimFlag.BODY_OVERLAY_DISABLED));
                rightArmOverlay.SetEnabled(0, !ANIM.GetFlag(SkinAnimFlag.RIGHT_ARM_OVERLAY_DISABLED));
                leftArmOverlay.SetEnabled(0, !ANIM.GetFlag(SkinAnimFlag.LEFT_ARM_OVERLAY_DISABLED));
                rightLegOverlay.SetEnabled(0, !ANIM.GetFlag(SkinAnimFlag.RIGHT_LEG_OVERLAY_DISABLED));
                leftLegOverlay.SetEnabled(0, !ANIM.GetFlag(SkinAnimFlag.LEFT_LEG_OVERLAY_DISABLED));

                int slimValue = slim ? 3 : 4;
                rightArm.ReplaceCube(0, new(-3, -2, -2), new(slimValue, 12, 4), new(40, 16));
                rightArmOverlay.ReplaceCube(0, new(-3, -2, -2), new(slimValue, 12, 4), new(40, 32), scale: OverlayScale);
                leftArm.ReplaceCube(0, new(-1, -2, -2), new(slimValue, 12, 4), new(32, 48));
                leftArmOverlay.ReplaceCube(0, new(-1, -2, -2), new(slimValue, 12, 4), new(48, 48), scale: OverlayScale);

                rightLeg.ReplaceCube(0, new(-2, 0, -2), new(4, 12, 4), new(0, 16));
                leftLeg.ReplaceCube(0, new(-2, 0, -2), new(4, 12, 4), new(16, 48));
                return;
            }
            
            TextureSize = new Size(64, 32);
            
            rightArm.ReplaceCube(0, new(-3, -2, -2), new(4, 12, 4), new(40, 16));
            rightArmOverlay.SetEnabled(0, false);
            
            leftArm.ReplaceCube(0, new(-1, -2, -2), new(4, 12, 4), new(40, 16), mirrorTexture: true);
            leftArmOverlay.SetEnabled(0, false);

            rightLeg.ReplaceCube(0, new(-2, 0, -2), new(4, 12, 4), new(0, 16));
            leftLeg.ReplaceCube(0, new(-2, 0, -2), new(4, 12, 4), new(0, 16), mirrorTexture: true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (DesignMode)
            {
                return;
            }

            MakeCurrent(); 

            camera.Update(AspectRatio);

            var viewProjection = camera.GetViewProjection();
            _skinShader.Bind();
            _skinShader.SetUniformMat4("u_ViewProjection", ref viewProjection);
            _skinShader.SetUniform2("u_TexSize", new Vector2(TextureSize.Width, TextureSize.Height));

            GL.Viewport(Size);

            GL.ClearColor(BackColor);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            GL.Enable(EnableCap.Texture2D); // Enable textures

            GL.Enable(EnableCap.DepthTest); // Enable correct Z Drawings
            GL.DepthFunc(DepthFunction.Lequal); // Enable correct Z Drawings
            GL.DepthMask(true);

            GL.Enable(EnableCap.Blend);
            GL.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);

            GL.Enable(EnableCap.AlphaTest); // Enable transparent
            GL.AlphaFunc(AlphaFunction.Greater, 0.4f);

            GL.PolygonMode(MaterialFace.FrontAndBack, showWireFrame ? PolygonMode.Line : PolygonMode.Fill);

            Matrix4 modelMatrix = Matrix4.CreateTranslation(0f, 4f, 0f) * // <- model rotation pivot point
                Matrix4.CreateFromAxisAngle(-Vector3.UnitX, MathHelper.DegreesToRadians(GlobalModelRotation.X)) * 
                Matrix4.CreateFromAxisAngle( Vector3.UnitY, MathHelper.DegreesToRadians(GlobalModelRotation.Y));

            bool slimModel = ANIM.GetFlag(SkinAnimFlag.SLIM_MODEL);

            var legRightMatrix = Matrix4.Identity;
            var legLeftMatrix = Matrix4.Identity;
            var armRightMatrix = Matrix4.Identity;
            var armLeftMatrix  = Matrix4.Identity;
            
            if (!ANIM.GetFlag(SkinAnimFlag.STATIC_ARMS))
            {
                armRightMatrix = Matrix4.CreateRotationX(MathHelper.DegreesToRadians(animationCurrentRotationAngle));
                armLeftMatrix  = Matrix4.CreateRotationX(MathHelper.DegreesToRadians(-animationCurrentRotationAngle));
            }

            if (!ANIM.GetFlag(SkinAnimFlag.STATIC_LEGS))
            {
                legRightMatrix = Matrix4.CreateRotationX(MathHelper.DegreesToRadians(-animationCurrentRotationAngle));
                legLeftMatrix  = Matrix4.CreateRotationX(MathHelper.DegreesToRadians(animationCurrentRotationAngle));
            }

            if (ANIM.GetFlag(SkinAnimFlag.ZOMBIE_ARMS))
            {
                var rotation = Matrix4.CreateRotationX(MathHelper.DegreesToRadians(-90f));
                armRightMatrix = rotation;
                armLeftMatrix  = rotation;
            }

            if (ANIM.GetFlag(SkinAnimFlag.STATUE_OF_LIBERTY))
            {
                armRightMatrix = Matrix4.CreateRotationX(MathHelper.DegreesToRadians(-180f));
                armLeftMatrix = Matrix4.CreateRotationX(0f);
            }

            RenderBodyPart(new Vector3(0f, 0f, 0f), Vector3.Zero, HeadMatrix, modelMatrix, "HEAD", "HEADWEAR");
            RenderBodyPart(new Vector3(0f, 0f, 0f), Vector3.Zero, BodyMatrix, modelMatrix, "BODY", "JACKET");
            RenderBodyPart(new Vector3( 4f, 2f, 0f), new Vector3(slimModel ? -4f : -5f, -2f, 0f), RightArmMatrix * armRightMatrix, modelMatrix, "ARM0", "SLEEVE0");
            RenderBodyPart(new Vector3(-4f, 2f, 0f), new Vector3(                   5f, -2f, 0f), LeftArmMatrix  * armLeftMatrix , modelMatrix, "ARM1", "SLEEVE1");
            RenderBodyPart(new Vector3(0f, 12f, 0f), new Vector3(-2f, -12f, 0f), RightLegMatrix * legRightMatrix, modelMatrix, "LEG0", "PANTS0");
            RenderBodyPart(new Vector3(0f, 12f, 0f), new Vector3( 2f, -12f, 0f), LeftLegMatrix  * legLeftMatrix , modelMatrix, "LEG1", "PANTS1");
            
            if (true)
            {
                GL.DepthFunc(DepthFunction.Lequal);
                GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Fill);
                _skyboxShader.Bind();
                _skyboxTexture.Bind(1);

                var view = new Matrix4(new Matrix3(Matrix4.LookAt(camera.WorldPosition, camera.WorldPosition + camera.Orientation, camera.Up)))
                    * Matrix4.CreateRotationY(MathHelper.DegreesToRadians(skyboxRotation));
                var proj = Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(camera.Fov), AspectRatio, 1f, 1000f);
                var viewproj = view * proj;
                _skyboxShader.SetUniformMat4("viewProjection", ref viewproj);
                Renderer.Draw(_skyboxShader, _skyboxRenderBuffer);
                GL.DepthFunc(DepthFunction.Less);
            }

            SwapBuffers();
        }

        private void RenderBodyPart(Vector3 pivot, Vector3 translation, Matrix4 partMatrix, Matrix4 globalMatrix, params string[] additionalData)
        {
            foreach (var data in additionalData)
            {
                RenderPart(data, pivot, translation, partMatrix, globalMatrix);
            }
        }

        private void RenderPart(string name, Vector3 pivot, Vector3 translation, Matrix4 partMatrix, Matrix4 globalMatrix)
        {
            CubeRenderGroup renderGroup = additionalModelRenderGroups[name];
            float yOffset = GetOffset(name);
            translation.Y -= yOffset;
            pivot.Y += yOffset;
            renderGroup.Submit();
            RenderBuffer buffer = renderGroup.GetRenderBuffer();
            Matrix4 model = Pivot(translation, pivot, partMatrix);
            model *= globalMatrix;
            _skinShader.SetUniformMat4("u_Model", ref model);
            Renderer.Draw(_skinShader, buffer);
        }

        private static Matrix4 Pivot(Vector3 translation, Vector3 pivot, Matrix4 target)
        {
            var model = Matrix4.CreateTranslation(translation);
            model *= Matrix4.CreateTranslation(pivot);
            model *= target;
            model *= Matrix4.CreateTranslation(pivot).Inverted();
            return model;
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            camera.Distance -= e.Delta / System.Windows.Input.Mouse.MouseWheelDeltaForOneLine;
            Refresh();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (!_isLeftMouseDown && e.Button == MouseButtons.Left)
            {
                // If the ray didn't hit the model then rotate the model
                PreviousMouseLocation = Cursor.Position; // Store the old mouse position to reset it when the action is over
                if (!IsMouseHidden) // Hide the mouse
                {
                    IsMouseHidden = true;
                }
                CurrentMouseLocation = Cursor.Position; // Store the current mouse position to use it for the rotate action
                _isLeftMouseDown = true;
            }
            else if (!_isRightMouseDown && e.Button == MouseButtons.Right)
            {
                PreviousMouseLocation = Cursor.Position; // Store the old mouse position to reset it when the action is over 
                if (!IsMouseHidden) // Hide the mouse
                {
                    IsMouseHidden = true;
                }
                CurrentMouseLocation = Cursor.Position; // Store the current mouse position to use it for the move action
                _isRightMouseDown = true;
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            ReleaseMouse();
            base.OnMouseUp(e);
        }

        private void animationTimer_Tick(object sender, EventArgs e)
        {
            skyboxRotation += skyboxRotationStep;
            skyboxRotation %= 360f;
            animationCurrentRotationAngle += animationRotationStep;
            if (animationCurrentRotationAngle >= animationMaxAngleInDegrees || animationCurrentRotationAngle <= -animationMaxAngleInDegrees)
                animationRotationStep = -animationRotationStep;
            Refresh();
        }

        private void moveTimer_Tick(object sender, EventArgs e)
        {
            if (!Focused)
            {
                return;
            }

            // Rotate the model
            if (_isLeftMouseDown)
            {
                float rotationYDelta = (float)Math.Round((Cursor.Position.X - CurrentMouseLocation.X) * 0.5f);
                float rotationXDelta = (float)Math.Round(-(Cursor.Position.Y - CurrentMouseLocation.Y) * 0.5f);
                GlobalModelRotation += new Vector2(rotationXDelta, rotationYDelta);
                Refresh();
                Cursor.Position = new Point((int)Math.Round(Screen.PrimaryScreen.Bounds.Width / 2d), (int)Math.Round(Screen.PrimaryScreen.Bounds.Height / 2d));
                CurrentMouseLocation = Cursor.Position;
                return;
            }
            // Move the model
            if (_isRightMouseDown)
            {
                float deltaX = -(Cursor.Position.X - CurrentMouseLocation.X) * 0.05f / (float)MathHelper.DegreesToRadians(camera.Fov);
                float deltaY = (Cursor.Position.Y - CurrentMouseLocation.Y) * 0.05f / (float)MathHelper.DegreesToRadians(camera.Fov);
                CameraTarget += new Vector2(deltaX, deltaY);
                Refresh();
                Cursor.Position = new Point((int)Math.Round(Screen.PrimaryScreen.Bounds.Width / 2d), (int)Math.Round(Screen.PrimaryScreen.Bounds.Height / 2d));
                CurrentMouseLocation = Cursor.Position;
            }
        }

        private void ReInitialzeSkinData()
        {
            foreach (var renderGroup in additionalModelRenderGroups.Values)
            {
                renderGroup.Clear();
            }

            InitializeSkinData();
            foreach (var item in ModelData)
            {
                AddCustomModelPart(item);
            }
            OnANIMUpdate();
            Refresh();
        }

        private void reInitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReInitialzeSkinData();
        }

        /// <summary>
        /// Captures the currently displayed frame
        /// </summary>
        /// <returns>Image of the cameras current view</returns>
        public Image GetThumbnail()
        {
            Bitmap bmp = new Bitmap(Width, Height);
            BitmapData data = bmp.LockBits(ClientRectangle, ImageLockMode.WriteOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            MakeCurrent();
            GL.Finish();
            GL.ReadPixels(0, 0, Width, Height, OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, data.Scan0);
            bmp.UnlockBits(data);
            bmp.RotateFlip(RotateFlipType.RotateNoneFlipY);
            return bmp;
        }
    }
}