﻿namespace PckStudio.Forms
{
    partial class TestGL
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.renderer3D1 = new PckStudio.Rendering.Renderer3D();
            this.SuspendLayout();
            // 
            // renderer3D1
            // 
            this.renderer3D1.BackColor = System.Drawing.Color.Gray;
            this.renderer3D1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.renderer3D1.Location = new System.Drawing.Point(0, 0);
            this.renderer3D1.Model = PckStudio.Rendering.Renderer3D.Models.Steve;
            this.renderer3D1.Name = "renderer3D1";
            this.renderer3D1.RotationX = 0;
            this.renderer3D1.RotationY = 0;
            this.renderer3D1.ShowBodyOverlay = true;
            this.renderer3D1.ShowHeadOverlay = true;
            this.renderer3D1.ShowLeftArmOverlay = true;
            this.renderer3D1.ShowLeftLegOverlay = true;
            this.renderer3D1.ShowRightArmOverlay = true;
            this.renderer3D1.ShowRightLegOverlay = true;
            this.renderer3D1.ShowBody = true;
            this.renderer3D1.ShowHead = true;
            this.renderer3D1.ShowLeftArm = true;
            this.renderer3D1.ShowLeftLeg = true;
            this.renderer3D1.ShowRightArm = true;
            this.renderer3D1.ShowRightLeg = true;
            this.renderer3D1.Size = new System.Drawing.Size(426, 428);
            this.renderer3D1.Texture = global::PckStudio.Properties.Resources.classic_template;
            this.renderer3D1.TabIndex = 8;
            this.renderer3D1.Zoom = 1D;
            // 
            // TestGL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 428);
            this.Controls.Add(this.renderer3D1);
            this.Name = "TestGL";
            this.Text = "TestGL";
            this.Load += new System.EventHandler(this.TestGL_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private PckStudio.Rendering.Renderer3D renderer3D1;
    }
}