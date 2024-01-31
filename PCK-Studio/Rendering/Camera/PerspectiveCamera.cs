﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace PckStudio.Rendering.Camera
{
    internal class PerspectiveCamera : Camera
    {
        public override float Distance
        {
            get => _position.Z;
            set => _position.Z = value;
        }

        public override Vector2 Position
        {
            get => _position.Xy;
            set => _position.Xy = value;
        }

        public Vector3 WorldPosition => _position;

        public Vector2 Rotation
        {
            get => _rotation;
            set
            {
                _rotation.X = MathHelper.Clamp(value.X, -180f, 180f);
                _rotation.Y = MathHelper.Clamp(value.Y, -180f, 180f);
            }
        }

        public Vector3 Orientation => -Vector3.UnitZ;

        public Vector3 Up = Vector3.UnitY;
        public float MinimumFov { get; set; } = 30f;
        public float MaximumFov { get; set; } = 120f;
        public float Fov
        {
            get => fov;
            set => fov = MathHelper.Clamp(value, MinimumFov, MaximumFov);
        }

        public PerspectiveCamera(Vector3 position, Vector2 rotation, float fov) : this(position.Xy, position.Z, rotation, fov)
        { }

        public PerspectiveCamera(Vector2 position, float distance, Vector2 rotation, float fov)
        {
            LookAt(position);
            Distance = distance;
            Fov = fov;
        }

        private Matrix4 viewProjection;
        private Matrix4 viewMatrix;
        private float fov;

        private Vector3 _position;
        private Vector2 _rotation;


        internal override Matrix4 GetViewProjection()
        {
            return viewProjection;
        }

        private void UpdateView()
        {

            Matrix4 rotation = Matrix4.CreateFromAxisAngle(new Vector3(-1f, 0f, 0f), MathHelper.DegreesToRadians(Rotation.X))
                             * Matrix4.CreateFromAxisAngle(new Vector3(0f, 1f, 0f), MathHelper.DegreesToRadians(Rotation.Y));

            viewMatrix = Matrix4.LookAt(_position, _position + Orientation, Up) * rotation;
        }

        internal override void Update(float aspect)
        {
            UpdateView();
            var projection = Matrix4.CreatePerspectiveFieldOfView((float)MathHelper.DegreesToRadians(Fov), aspect, 1f, 1000f);
            viewProjection = viewMatrix * projection;
        }

        internal void LookAt(Vector2 pos)
        {
            Position = pos;
        }

        public override string ToString()
        {
            return $"FOV: {Fov}\nPosition: {Position}\nRotation: {Rotation}";
        }

    }
}
