﻿using System;
using System.Collections.Generic;
using System.Drawing;
using OpenTK;
using PckStudio.Rendering;

namespace PckStudio.Classes.Utils
{
    public class Ray
    {
        public Vector3 CurrentRay { get; set; } = new Vector3();

        public Matrix4 ViewMatrix { get; set; }
        public Matrix4 ProjectionMatrix { get; set; }

        public Vector3 CamPos { get; set; }

        public Size Size { get; set; }

        public Point Pos { get; set; }

        // TODO: remove Renderer3D from Ray
        public Renderer3D Renderer { get; set; }

        public struct RayResult
        {
            public float Distance { get; set; }

            public enum Is
            {
                X,
                Y,
                Z
            }

            public Is IsWhat { get; set; }

            public RayResult(float Distance, Is IsWhat)
            {
                this.Distance = Distance;
                this.IsWhat = IsWhat;
            }
        }

        public Vector3 MouseHit
        {
            get
            {

                Update(Pos.X, Pos.Y);
                var HeadIndex = new float[2];
                var BodyIndex = new float[2];
                HeadIndex[0] = (4f - CamPos.Z) / CurrentRay.Z;
                BodyIndex[0] = (2f - CamPos.Z) / CurrentRay.Z;
                HeadIndex[1] = (-4 - CamPos.Z) / CurrentRay.Z;
                BodyIndex[1] = (-2 - CamPos.Z) / CurrentRay.Z;

                var HeadXIndex = new float[2];
                var BodyXIndex = new float[4];
                var LegXIndex = new float[3];
                HeadXIndex[0] = (4f - CamPos.X) / CurrentRay.X;
                if (Renderer.Model == Renderer3D.Models.Steve)
                {
                    BodyXIndex[0] = (8f - CamPos.X) / CurrentRay.X;
                    BodyXIndex[1] = (-8 - CamPos.X) / CurrentRay.X;
                }
                else
                {
                    BodyXIndex[0] = (7f - CamPos.X) / CurrentRay.X;
                    BodyXIndex[1] = (-7 - CamPos.X) / CurrentRay.X;
                }
                HeadXIndex[1] = (-4 - CamPos.X) / CurrentRay.X;
                BodyXIndex[2] = (-4 - CamPos.X) / CurrentRay.X;
                BodyXIndex[3] = (4f - CamPos.X) / CurrentRay.X;
                LegXIndex[0] = (4f - CamPos.X) / CurrentRay.X;
                LegXIndex[1] = (-4 - CamPos.X) / CurrentRay.X;
                LegXIndex[2] = -CamPos.X / CurrentRay.X;

                var HeadYIndex = new float[2];
                var BodyYIndex = new float[2];
                var LegYIndex = new float[2];
                HeadYIndex[0] = (16f - CamPos.Y) / CurrentRay.Y;
                BodyYIndex[0] = (8f - CamPos.Y) / CurrentRay.Y;
                HeadYIndex[1] = (8f - CamPos.Y) / CurrentRay.Y;
                BodyYIndex[1] = (-4 - CamPos.Y) / CurrentRay.Y;
                LegYIndex[0] = (-4 - CamPos.Y) / CurrentRay.Y;
                LegYIndex[1] = (-16 - CamPos.Y) / CurrentRay.Y;

                var PointsDis = new List<RayResult>();

                Vector3 HeadPoint, BodyPoint, HeadXPoint, BodyXPoint, LegXPoint, HeadYPoint, BodyYPoint, LegYPoint;

                for (byte I = 0; I <= 3; I++)
                {

                    if (!(I > 1))
                    {
                        HeadPoint = GetPointOnRay(CurrentRay, HeadIndex[I]);
                    }
                    else
                    {
                        HeadPoint = new Vector3(20f, 20f, 20f);
                    }
                    if (!(I > 1))
                    {
                        BodyPoint = GetPointOnRay(CurrentRay, BodyIndex[I]);
                    }
                    else
                    {
                        BodyPoint = new Vector3(20f, 20f, 20f);
                    }

                    if (!(I > 1))
                    {
                        HeadXPoint = GetPointOnRay(CurrentRay, HeadXIndex[I]);
                    }
                    else
                    {
                        HeadXPoint = new Vector3(20f, 20f, 20f);
                    }
                    BodyXPoint = GetPointOnRay(CurrentRay, BodyXIndex[I]);
                    if (!(I > 2))
                    {
                        LegXPoint = GetPointOnRay(CurrentRay, LegXIndex[I]);
                    }
                    else
                    {
                        LegXPoint = new Vector3(20f, 20f, 20f);
                    }

                    if (!(I > 1))
                    {
                        HeadYPoint = GetPointOnRay(CurrentRay, HeadYIndex[I]);
                    }
                    else
                    {
                        HeadYPoint = new Vector3(20f, 20f, 20f);
                    }
                    if (!(I > 1))
                    {
                        BodyYPoint = GetPointOnRay(CurrentRay, BodyYIndex[I]);
                    }
                    else
                    {
                        BodyYPoint = new Vector3(20f, 20f, 20f);
                    }
                    if (!(I > 1))
                    {
                        LegYPoint = GetPointOnRay(CurrentRay, LegYIndex[I]);
                    }
                    else
                    {
                        LegYPoint = new Vector3(20f, 20f, 20f);
                    }

                    if (Renderer.ShowHead && HeadPoint.X < 4f && HeadPoint.X > -4 && HeadPoint.Y < 16f && HeadPoint.Y > 8f)
                    {
                        PointsDis.Add(new RayResult(HeadIndex[I], RayResult.Is.Z));
                    }
                    if (Renderer.ShowBody && BodyPoint.X < 4f && BodyPoint.X > -4 && BodyPoint.Y < 8f && BodyPoint.Y > -4)
                    {
                        PointsDis.Add(new RayResult(BodyIndex[I], RayResult.Is.Z));
                    }
                    if (Renderer.ShowRightArm && BodyPoint.Y > -4 && BodyPoint.Y < 8f)
                    {
                        if (Renderer.Model == Renderer3D.Models.Steve && BodyPoint.X > -8 && BodyPoint.X < -4 || Renderer.Model == Renderer3D.Models.Alex && BodyPoint.X > -7 && BodyPoint.X < -4)
                        {
                            PointsDis.Add(new RayResult(BodyIndex[I], RayResult.Is.Z));
                        }
                    }
                    if (Renderer.ShowLeftArm && BodyPoint.Y < 8f && BodyPoint.Y > -4)
                    {
                        if (Renderer.Model == Renderer3D.Models.Steve && BodyPoint.X < 8f && BodyPoint.X > 4f || Renderer.Model == Renderer3D.Models.Alex && BodyPoint.X < 7f && BodyPoint.X > 4f)
                        {
                            PointsDis.Add(new RayResult(BodyIndex[I], RayResult.Is.Z));
                        }
                    }
                    if (Renderer.ShowRightLeg && BodyPoint.X < 0f && BodyPoint.X > -4 && BodyPoint.Y < -4 && BodyPoint.Y > -16)
                    {
                        PointsDis.Add(new RayResult(BodyIndex[I], RayResult.Is.Z));
                    }
                    if (Renderer.ShowLeftLeg && BodyPoint.X < 4f && BodyPoint.X > 0f && BodyPoint.Y < -4 && BodyPoint.Y > -16)
                    {
                        PointsDis.Add(new RayResult(BodyIndex[I], RayResult.Is.Z));
                    }
                    if (Renderer.ShowHead && HeadXPoint.Z < 4f && HeadXPoint.Z > -4 && HeadXPoint.Y < 16f && HeadXPoint.Y > 8f)
                    {
                        PointsDis.Add(new RayResult(HeadXIndex[I], RayResult.Is.X));
                    }
                    if (Renderer.ShowRightArm && (Convert.ToInt32(BodyXPoint.X) == -8 || Convert.ToInt32(BodyXPoint.X) == -7) && BodyXPoint.Z < 2f && BodyXPoint.Z > -2 && BodyXPoint.Y < 8f && BodyXPoint.Y > -4)
                    {
                        PointsDis.Add(new RayResult(BodyXIndex[I], RayResult.Is.X));
                    }
                    if (Renderer.ShowLeftArm && (Convert.ToInt32(BodyXPoint.X) == 8 || Convert.ToInt32(BodyXPoint.X) == 7) && BodyXPoint.Z < 2f && BodyXPoint.Z > -2 && BodyXPoint.Y < 8f && BodyXPoint.Y > -4)
                    {
                        PointsDis.Add(new RayResult(BodyXIndex[I], RayResult.Is.X));
                    }
                    if (Renderer.ShowRightArm ^ Renderer.ShowBody && Convert.ToInt32(BodyXPoint.X) == -4 && BodyXPoint.Z < 2f && BodyXPoint.Z > -2 && BodyXPoint.Y < 8f && BodyXPoint.Y > -4)
                    {
                        PointsDis.Add(new RayResult(BodyXIndex[I], RayResult.Is.X));
                    }
                    if (Renderer.ShowLeftArm ^ Renderer.ShowBody && Convert.ToInt32(BodyXPoint.X) == 4 && BodyXPoint.Z < 2f && BodyXPoint.Z > -2 && BodyXPoint.Y < 8f && BodyXPoint.Y > -4)
                    {
                        PointsDis.Add(new RayResult(BodyXIndex[I], RayResult.Is.X));
                    }
                    if (Renderer.ShowRightLeg && Convert.ToInt32(LegXPoint.X) == -4 && LegXPoint.Z < 2f && LegXPoint.Z > -2 && LegXPoint.Y < -4 && LegXPoint.Y > -16)
                    {
                        PointsDis.Add(new RayResult(LegXIndex[I], RayResult.Is.X));
                    }
                    if (Renderer.ShowLeftLeg && Convert.ToInt32(LegXPoint.X) == 4 && LegXPoint.Z < 2f && LegXPoint.Z > -2 && LegXPoint.Y < -4 && LegXPoint.Y > -16)
                    {
                        PointsDis.Add(new RayResult(LegXIndex[I], RayResult.Is.X));
                    }
                    if (Renderer.ShowRightLeg ^ Renderer.ShowLeftLeg && Convert.ToInt32(LegXPoint.X) == 0 && LegXPoint.Z < 2f && LegXPoint.Z > -2 && LegXPoint.Y < -4 && LegXPoint.Y > -16)
                    {
                        PointsDis.Add(new RayResult(LegXIndex[I], RayResult.Is.X));
                    }
                    if (Renderer.ShowHead && HeadYPoint.Z < 4f && HeadYPoint.Z > -4 && HeadYPoint.X < 4f && HeadYPoint.X > -4)
                    {
                        PointsDis.Add(new RayResult(HeadYIndex[I], RayResult.Is.Y));
                    }
                    if (Renderer.ShowBody && BodyYPoint.Z < 2f && BodyYPoint.Z > -2 && BodyYPoint.X < 4f && BodyYPoint.X > -4)
                    {
                        PointsDis.Add(new RayResult(BodyYIndex[I], RayResult.Is.Y));
                    }
                    if (Renderer.ShowRightArm && BodyYPoint.Z < 2f && BodyYPoint.Z > -2)
                    {
                        if (Renderer.Model == Renderer3D.Models.Steve && BodyYPoint.X > -8 && BodyYPoint.X < -4 || Renderer.Model == Renderer3D.Models.Alex && BodyYPoint.X > -7 && BodyYPoint.X < -4)
                        {
                            PointsDis.Add(new RayResult(BodyYIndex[I], RayResult.Is.Y));
                        }
                    }
                    if (Renderer.ShowLeftArm && BodyYPoint.Z < 2f && BodyYPoint.Z > -2)
                    {
                        if (Renderer.Model == Renderer3D.Models.Steve && BodyYPoint.X < 8f && BodyYPoint.X > 4f || Renderer.Model == Renderer3D.Models.Alex && BodyYPoint.X < 7f && BodyYPoint.X > 4f)
                        {
                            PointsDis.Add(new RayResult(BodyYIndex[I], RayResult.Is.Y));
                        }
                    }
                    if (Renderer.ShowRightLeg && LegYPoint.Z < 2f && LegYPoint.Z > -2 && LegYPoint.X < 0f && LegYPoint.X > -4)
                    {
                        PointsDis.Add(new RayResult(LegYIndex[I], RayResult.Is.Y));
                    }
                    if (Renderer.ShowLeftLeg && LegYPoint.Z < 2f && LegYPoint.Z > -2 && LegYPoint.X < 4f && LegYPoint.X > 0f)
                    {
                        PointsDis.Add(new RayResult(LegYIndex[I], RayResult.Is.Y));
                    }

                }

                if (PointsDis.Count == 0)
                    return default;

                var Smallest = new RayResult(1000f, RayResult.Is.X);

                foreach (RayResult value in PointsDis)
                {
                    if (value.Distance < Smallest.Distance)
                        Smallest = value;
                }

                var Result = GetPointOnRay(CurrentRay, Smallest.Distance);
                if (Smallest.IsWhat == RayResult.Is.X)
                {
                    Result.X = (int)Math.Round(Result.X);
                }
                else if (Smallest.IsWhat == RayResult.Is.Y)
                {
                    Result.Y = (int)Math.Round(Result.Y);
                }
                else if (Smallest.IsWhat == RayResult.Is.Z)
                {
                    Result.Z = (int)Math.Round(Result.Z);
                }

                return Result;
            }
        }

        public Vector3 Mouse2ndHit
        {
            get
            {
                Update(Pos.X, Pos.Y);
                var HeadIndex = new float[2];
                var BodyIndex = new float[2];
                HeadIndex[0] = (float)((4.24d - CamPos.Z) / CurrentRay.Z);
                BodyIndex[0] = (float)((2.12d - CamPos.Z) / CurrentRay.Z);
                HeadIndex[1] = (float)((-4.24d - CamPos.Z) / CurrentRay.Z);
                BodyIndex[1] = (float)((-2.12d - CamPos.Z) / CurrentRay.Z);

                var HeadXIndex = new float[2];
                var BodyXIndex = new float[2];
                var RArmXIndex = new float[2];
                var LArmXIndex = new float[2];
                var RLegXIndex = new float[2];
                var LLegXIndex = new float[2];
                HeadXIndex[0] = (float)((4.24d - CamPos.X) / CurrentRay.X);
                HeadXIndex[1] = (float)((-4.24d - CamPos.X) / CurrentRay.X);
                BodyXIndex[0] = (float)((-4.24d - CamPos.X) / CurrentRay.X);
                BodyXIndex[1] = (float)((4.24d - CamPos.X) / CurrentRay.X);
                if (Renderer.Model == Renderer3D.Models.Steve)
                {
                    RArmXIndex[0] = (float)((-3.88d - CamPos.X) / CurrentRay.X);
                    RArmXIndex[1] = (float)((-8.12d - CamPos.X) / CurrentRay.X);
                    LArmXIndex[0] = (float)((3.88d - CamPos.X) / CurrentRay.X);
                    LArmXIndex[1] = (float)((8.12d - CamPos.X) / CurrentRay.X);
                }
                else
                {
                    RArmXIndex[0] = (float)((-3.91d - CamPos.X) / CurrentRay.X);
                    RArmXIndex[1] = (float)((-7.09d - CamPos.X) / CurrentRay.X);
                    LArmXIndex[0] = (float)((3.91d - CamPos.X) / CurrentRay.X);
                    LArmXIndex[1] = (float)((7.09d - CamPos.X) / CurrentRay.X);
                }
                LLegXIndex[0] = (float)((4.24d - CamPos.X) / CurrentRay.X);
                RLegXIndex[0] = (float)((-4.24d - CamPos.X) / CurrentRay.X);
                RLegXIndex[1] = (float)((0.12d - CamPos.X) / CurrentRay.X);
                LLegXIndex[1] = (float)((-0.12d - CamPos.X) / CurrentRay.X);

                var HeadYIndex = new float[2];
                var BodyYIndex = new float[2];
                var LegYIndex = new float[2];
                HeadYIndex[0] = (float)((16.24d - CamPos.Y) / CurrentRay.Y);
                BodyYIndex[0] = (float)((8.36d - CamPos.Y) / CurrentRay.Y);
                HeadYIndex[1] = (float)((7.76d - CamPos.Y) / CurrentRay.Y);
                BodyYIndex[1] = (float)((-4.36d - CamPos.Y) / CurrentRay.Y);
                LegYIndex[0] = (float)((-3.64d - CamPos.Y) / CurrentRay.Y);
                LegYIndex[1] = (float)((-16.36d - CamPos.Y) / CurrentRay.Y);

                var PointsDis = new List<RayResult>();

                Vector3 HeadPoint, BodyPoint, HeadXPoint, BodyXPoint, LArmXPoint, RArmXPoint, LLegXPoint, RLegXPoint, HeadYPoint, BodyYPoint, LegYPoint;

                for (byte I = 0; I <= 1; I++)
                {

                    HeadPoint = GetPointOnRay(CurrentRay, HeadIndex[I]);
                    BodyPoint = GetPointOnRay(CurrentRay, BodyIndex[I]);

                    HeadXPoint = GetPointOnRay(CurrentRay, HeadXIndex[I]);
                    BodyXPoint = GetPointOnRay(CurrentRay, BodyXIndex[I]);
                    RArmXPoint = GetPointOnRay(CurrentRay, RArmXIndex[I]);
                    LArmXPoint = GetPointOnRay(CurrentRay, LArmXIndex[I]);
                    RLegXPoint = GetPointOnRay(CurrentRay, RLegXIndex[I]);
                    LLegXPoint = GetPointOnRay(CurrentRay, LLegXIndex[I]);

                    HeadYPoint = GetPointOnRay(CurrentRay, HeadYIndex[I]);
                    BodyYPoint = GetPointOnRay(CurrentRay, BodyYIndex[I]);
                    LegYPoint = GetPointOnRay(CurrentRay, LegYIndex[I]);

                    if (Renderer.ShowHeadOverlay && HeadPoint.X < 4.24d && HeadPoint.X > -4.24d && HeadPoint.Y < 16.24d && HeadPoint.Y > 7.76d)
                    {
                        PointsDis.Add(new RayResult(HeadIndex[I], RayResult.Is.Z));
                    }
                    if (Renderer.ShowBodyOverlay && BodyPoint.X < 4.24d && BodyPoint.X > -4.24d && BodyPoint.Y < 8.36d && BodyPoint.Y > -4.36d)
                    {
                        PointsDis.Add(new RayResult(BodyIndex[I], RayResult.Is.Z));
                    }
                    if (Renderer.ShowRightArmOverlay && BodyPoint.Y < 8.36d && BodyPoint.Y > -4.36d)
                    {
                        if (Renderer.Model == Renderer3D.Models.Steve && BodyPoint.X < -3.88d && BodyPoint.X > -8.12d || Renderer.Model == Renderer3D.Models.Alex && BodyPoint.X < -3.91d && BodyPoint.X > -7.09d)
                        {
                            PointsDis.Add(new RayResult(BodyIndex[I], RayResult.Is.Z));
                        }
                    }
                    if (Renderer.ShowLeftArmOverlay && BodyPoint.Y < 8.36d && BodyPoint.Y > -4.36d)
                    {
                        if (Renderer.Model == Renderer3D.Models.Steve && BodyPoint.X < 8.12d && BodyPoint.X > 3.88d || Renderer.Model == Renderer3D.Models.Alex && BodyPoint.X < 7.09d && BodyPoint.X > 3.91d)
                        {
                            PointsDis.Add(new RayResult(BodyIndex[I], RayResult.Is.Z));
                        }
                    }
                    if (Renderer.ShowRightLegOverlay && BodyPoint.X < 0.12d && BodyPoint.X > -4.12d && BodyPoint.Y < -3.64d && BodyPoint.Y > -16.36d)
                    {
                        PointsDis.Add(new RayResult(BodyIndex[I], RayResult.Is.Z));
                    }
                    if (Renderer.ShowLeftLegOverlay && BodyPoint.X < 4.12d && BodyPoint.X > -0.12d && BodyPoint.Y < -3.64d && BodyPoint.Y > -16.36d)
                    {
                        PointsDis.Add(new RayResult(BodyIndex[I], RayResult.Is.Z));
                    }
                    if (Renderer.ShowHeadOverlay && HeadXPoint.Z < 4.24d && HeadXPoint.Z > -4.24d && HeadXPoint.Y < 16.24d && HeadXPoint.Y > 7.76d)
                    {
                        PointsDis.Add(new RayResult(HeadXIndex[I], RayResult.Is.X));
                    }
                    if (Renderer.ShowBodyOverlay && BodyXPoint.Z < 2.12d && BodyXPoint.Z > -2.12d && BodyXPoint.Y < 8.36d && BodyXPoint.Y > -4.36d)
                    {
                        PointsDis.Add(new RayResult(BodyXIndex[I], RayResult.Is.X));
                    }
                    if (Renderer.ShowRightArmOverlay && RArmXPoint.Z < 2.12d && RArmXPoint.Z > -2.12d && RArmXPoint.Y < 8.36d && RArmXPoint.Y > -4.36d)
                    {
                        PointsDis.Add(new RayResult(RArmXIndex[I], RayResult.Is.X));
                    }
                    if (Renderer.ShowLeftArmOverlay && LArmXPoint.Z < 2.12d && LArmXPoint.Z > -2.12d && LArmXPoint.Y < 8.36d && LArmXPoint.Y > -4.36d)
                    {
                        PointsDis.Add(new RayResult(LArmXIndex[I], RayResult.Is.X));
                    }
                    if (Renderer.ShowRightLegOverlay && RLegXPoint.Z < 2.12d && RLegXPoint.Z > -2.12d && RLegXPoint.Y < -3.64d && RLegXPoint.Y > -16.36d)
                    {
                        PointsDis.Add(new RayResult(RLegXIndex[I], RayResult.Is.X));
                    }
                    if (Renderer.ShowLeftLegOverlay && LLegXPoint.Z < 2.12d && LLegXPoint.Z > -2.12d && LLegXPoint.Y < -3.64d && LLegXPoint.Y > -16.36d)
                    {
                        PointsDis.Add(new RayResult(LLegXIndex[I], RayResult.Is.X));
                    }
                    if (Renderer.ShowHeadOverlay && HeadYPoint.Z < 4.24d && HeadYPoint.Z > -4.24d && HeadYPoint.X < 4.24d && HeadYPoint.X > -4.24d)
                    {
                        PointsDis.Add(new RayResult(HeadYIndex[I], RayResult.Is.Y));
                    }
                    if (Renderer.ShowBodyOverlay && BodyYPoint.Z < 2.12d && BodyYPoint.Z > -2.12d && BodyYPoint.X < 4.24d && BodyYPoint.X > -4.24d)
                    {
                        PointsDis.Add(new RayResult(BodyYIndex[I], RayResult.Is.Y));
                    }
                    if (Renderer.ShowRightArmOverlay && BodyYPoint.Z < 2.12d && BodyYPoint.Z > -2.12d)
                    {
                        if (Renderer.Model == Renderer3D.Models.Steve && BodyYPoint.X < -3.88d && BodyYPoint.X > -8.12d || Renderer.Model == Renderer3D.Models.Alex && BodyYPoint.X < -3.91d && BodyYPoint.X > -7.09d)
                        {
                            PointsDis.Add(new RayResult(BodyYIndex[I], RayResult.Is.Y));
                        }
                    }
                    if (Renderer.ShowLeftArmOverlay && BodyYPoint.Z < 2.12d && BodyYPoint.Z > -2.12d)
                    {
                        if (Renderer.Model == Renderer3D.Models.Steve && BodyYPoint.X < 8.12d && BodyYPoint.X > 3.88d || Renderer.Model == Renderer3D.Models.Alex && BodyYPoint.X < 7.09d && BodyYPoint.X > 3.91d)
                        {
                            PointsDis.Add(new RayResult(BodyYIndex[I], RayResult.Is.Y));
                        }
                    }
                    if (Renderer.ShowRightLegOverlay && LegYPoint.Z < 2.12d && LegYPoint.Z > -2.12d && LegYPoint.X < 0.12d && LegYPoint.X > -4.12d)
                    {
                        PointsDis.Add(new RayResult(LegYIndex[I], RayResult.Is.Y));
                    }
                    if (Renderer.ShowLeftLegOverlay && LegYPoint.Z < 2.12d && LegYPoint.Z > -2.12d && LegYPoint.X < 4.12d && LegYPoint.X > -0.12d)
                    {
                        PointsDis.Add(new RayResult(LegYIndex[I], RayResult.Is.Y));
                    }

                }

                if (PointsDis.Count == 0)
                    return new Vector3(100f, 100f, 100f);

                var Smallest = new RayResult(1000f, RayResult.Is.Z);

                foreach (RayResult value in PointsDis)
                {
                    if (value.Distance < Smallest.Distance)
                        Smallest = value;
                }

                var Result = GetPointOnRay(CurrentRay, Smallest.Distance);

                float[] ZIndex = new[] { 4.24f, 2.12f, (float)-4.24d, (float)-2.12d };
                float[] XIndex;
                if (Renderer.Model == Renderer3D.Models.Steve)
                {
                    XIndex = new[] { 4.24f, 8.12f, (float)-4.24d, (float)-8.12d, (float)-3.88d, 3.88f, 0.12f, (float)-0.12d };
                }
                else
                {
                    XIndex = new[] { 4.24f, 7.09f, (float)-4.24d, (float)-7.09d, (float)-3.91d, 3.91f, 0.12f, (float)-0.12d };
                }
                float[] YIndex = new[] { 16.24f, 8.36f, 7.76f, (float)-4.36d, (float)-3.64d, (float)-16.36d };

                float AResult = 20f;

                if (Smallest.IsWhat == RayResult.Is.X)
                {
                    foreach (float value in XIndex)
                    {
                        if (Math.Abs(value - Result.X) < Math.Abs(AResult - Result.X))
                        {
                            AResult = value;
                        }
                    }
                    Result.X = AResult;
                }
                else if (Smallest.IsWhat == RayResult.Is.Y)
                {
                    foreach (float value in YIndex)
                    {
                        if (Math.Abs(value - Result.Y) < Math.Abs(AResult - Result.Y))
                        {
                            AResult = value;
                        }
                    }
                    Result.Y = AResult;
                }
                else if (Smallest.IsWhat == RayResult.Is.Z)
                {
                    foreach (float value in ZIndex)
                    {
                        if (Math.Abs(value - Result.Z) < Math.Abs(AResult - Result.Z))
                        {
                            AResult = value;
                        }
                    }
                    Result.Z = AResult;
                }

                return Result;
            }
        }

        public Ray(ref Matrix4 viewMatrix, ref Matrix4 projectionMatrix, Size size, Vector3 cameraPosition, Renderer3D renderer)
        {
            ProjectionMatrix = projectionMatrix;
            ViewMatrix = viewMatrix;
            Size = size;
            CamPos = cameraPosition;
            Renderer = renderer;
        }

        private void Update(int X, int Y)
        {
            CurrentRay = CalculateRay(X, Y);
        }

        private Vector3 CalculateRay(int x, int y)
        {
            var normalizedCoords = GetNormalisedDeviceCoordinates(x, y);
            var clipCoords = new Vector4(normalizedCoords.X, normalizedCoords.Y, -1.0f, 1.0f);
            var eyeCoords = ToEyeCoords(clipCoords);
            var worldRay = ToWorldCoords(eyeCoords);
            return worldRay;
        }

        private Vector4 ToEyeCoords(Vector4 clipCoords)
        {
            var invertedProjection = Matrix4.Invert(ProjectionMatrix);
            var eyeCoords = Vector4.Transform(clipCoords, invertedProjection);
            return new Vector4(eyeCoords.X, eyeCoords.Y, -1.0f, 0f);
        }

        private Vector3 ToWorldCoords(Vector4 eyeCoords)
        {
            var invertedView = Matrix4.Invert(ViewMatrix);
            var rayWorld = Vector4.Transform(eyeCoords, invertedView);
            var ray = new Vector3(rayWorld);
            ray.Normalize();
            return ray;
        }

        private Vector2 GetNormalisedDeviceCoordinates(int x, int y)
        {
            float x2 = 2.0f * x / Size.Width - 1.0f;
            float y2 = -(2.0f * y / Size.Height - 1.0f);
            return new Vector2(x2, y2);
        }

        private Vector3 GetPointOnRay(Vector3 ray, float distance)
        {
            var start = new Vector3(CamPos);
            var scaledRay = new Vector3(ray.X * distance, ray.Y * distance, ray.Z * distance);
            return start + scaledRay;
        }
    }
}