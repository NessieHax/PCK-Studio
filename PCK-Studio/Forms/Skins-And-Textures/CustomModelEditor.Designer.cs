﻿namespace PckStudio.Forms
{
    partial class CustomModelEditor
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label label5;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomModelEditor));
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label7;
            System.Windows.Forms.Label labelTextureMappingPreview;
            PckStudio.Internal.SkinANIM skinANIM1 = new PckStudio.Internal.SkinANIM();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.createToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cloneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonDone = new MetroFramework.Controls.MetroButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tabBody = new System.Windows.Forms.TabControl();
            this.tabArmor = new System.Windows.Forms.TabPage();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.myTablePanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.offsetArms = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.offsetBody = new System.Windows.Forms.TextBox();
            this.offsetLegs = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.offsetHead = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.buttonEXPORT = new MetroFramework.Controls.MetroButton();
            this.buttonIMPORT = new MetroFramework.Controls.MetroButton();
            this.buttonImportModel = new MetroFramework.Controls.MetroButton();
            this.buttonExportModel = new MetroFramework.Controls.MetroButton();
            this.OpenJSONButton = new MetroFramework.Controls.MetroButton();
            this.generateTextureCheckBox = new MetroFramework.Controls.MetroCheckBox();
            this.checkGuide = new MetroFramework.Controls.MetroCheckBox();
            this.checkBoxArmor = new MetroFramework.Controls.MetroCheckBox();
            this.SizeXUpDown = new System.Windows.Forms.NumericUpDown();
            this.SizeYUpDown = new System.Windows.Forms.NumericUpDown();
            this.SizeZUpDown = new System.Windows.Forms.NumericUpDown();
            this.TextureXUpDown = new System.Windows.Forms.NumericUpDown();
            this.TextureYUpDown = new System.Windows.Forms.NumericUpDown();
            this.PosZUpDown = new System.Windows.Forms.NumericUpDown();
            this.PosYUpDown = new System.Windows.Forms.NumericUpDown();
            this.PosXUpDown = new System.Windows.Forms.NumericUpDown();
            this.renderer3D1 = new PckStudio.Rendering.SkinRenderer();
            this.uvPictureBox = new PckStudio.ToolboxItems.InterpolationPictureBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            label5 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            labelTextureMappingPreview = new System.Windows.Forms.Label();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabBody.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.myTablePanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SizeXUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SizeYUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SizeZUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextureXUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextureYUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PosZUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PosYUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PosXUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uvPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            resources.ApplyResources(label5, "label5");
            label5.ForeColor = System.Drawing.Color.White;
            label5.Name = "label5";
            // 
            // label3
            // 
            resources.ApplyResources(label3, "label3");
            label3.ForeColor = System.Drawing.Color.White;
            label3.Name = "label3";
            // 
            // label7
            // 
            resources.ApplyResources(label7, "label7");
            label7.ForeColor = System.Drawing.Color.White;
            label7.Name = "label7";
            // 
            // labelTextureMappingPreview
            // 
            resources.ApplyResources(labelTextureMappingPreview, "labelTextureMappingPreview");
            labelTextureMappingPreview.ForeColor = System.Drawing.Color.White;
            labelTextureMappingPreview.Name = "labelTextureMappingPreview";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createToolStripMenuItem,
            this.cloneToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.changeColorToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            resources.ApplyResources(this.contextMenuStrip1, "contextMenuStrip1");
            // 
            // createToolStripMenuItem
            // 
            resources.ApplyResources(this.createToolStripMenuItem, "createToolStripMenuItem");
            this.createToolStripMenuItem.Name = "createToolStripMenuItem";
            this.createToolStripMenuItem.Click += new System.EventHandler(this.createToolStripMenuItem_Click);
            // 
            // cloneToolStripMenuItem
            // 
            resources.ApplyResources(this.cloneToolStripMenuItem, "cloneToolStripMenuItem");
            this.cloneToolStripMenuItem.Name = "cloneToolStripMenuItem";
            this.cloneToolStripMenuItem.Click += new System.EventHandler(this.cloneToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            resources.ApplyResources(this.deleteToolStripMenuItem, "deleteToolStripMenuItem");
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // changeColorToolStripMenuItem
            // 
            resources.ApplyResources(this.changeColorToolStripMenuItem, "changeColorToolStripMenuItem");
            this.changeColorToolStripMenuItem.Name = "changeColorToolStripMenuItem";
            // 
            // buttonDone
            // 
            resources.ApplyResources(this.buttonDone, "buttonDone");
            this.buttonDone.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonDone.ForeColor = System.Drawing.Color.White;
            this.buttonDone.Name = "buttonDone";
            this.buttonDone.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.buttonDone.UseSelectable = true;
            this.buttonDone.Click += new System.EventHandler(this.buttonDone_Click);
            // 
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Controls.Add(this.tabBody);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // tabBody
            // 
            this.tabBody.Controls.Add(this.tabArmor);
            this.tabBody.Controls.Add(this.tabPage1);
            resources.ApplyResources(this.tabBody, "tabBody");
            this.tabBody.Name = "tabBody";
            this.tabBody.SelectedIndex = 0;
            // 
            // tabArmor
            // 
            this.tabArmor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            resources.ApplyResources(this.tabArmor, "tabArmor");
            this.tabArmor.Name = "tabArmor";
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.tabPage1.Controls.Add(this.myTablePanel2);
            resources.ApplyResources(this.tabPage1, "tabPage1");
            this.tabPage1.Name = "tabPage1";
            // 
            // myTablePanel2
            // 
            resources.ApplyResources(this.myTablePanel2, "myTablePanel2");
            this.myTablePanel2.Controls.Add(this.offsetArms, 1, 3);
            this.myTablePanel2.Controls.Add(this.label14, 0, 3);
            this.myTablePanel2.Controls.Add(this.offsetBody, 1, 1);
            this.myTablePanel2.Controls.Add(this.offsetLegs, 1, 2);
            this.myTablePanel2.Controls.Add(this.label10, 0, 0);
            this.myTablePanel2.Controls.Add(this.label13, 0, 2);
            this.myTablePanel2.Controls.Add(this.offsetHead, 1, 0);
            this.myTablePanel2.Controls.Add(this.label12, 0, 1);
            this.myTablePanel2.Name = "myTablePanel2";
            // 
            // offsetArms
            // 
            resources.ApplyResources(this.offsetArms, "offsetArms");
            this.offsetArms.Name = "offsetArms";
            // 
            // label14
            // 
            resources.ApplyResources(this.label14, "label14");
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label14.Name = "label14";
            // 
            // offsetBody
            // 
            resources.ApplyResources(this.offsetBody, "offsetBody");
            this.offsetBody.Name = "offsetBody";
            // 
            // offsetLegs
            // 
            resources.ApplyResources(this.offsetLegs, "offsetLegs");
            this.offsetLegs.Name = "offsetLegs";
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label10.Name = "label10";
            // 
            // label13
            // 
            resources.ApplyResources(this.label13, "label13");
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label13.Name = "label13";
            // 
            // offsetHead
            // 
            resources.ApplyResources(this.offsetHead, "offsetHead");
            this.offsetHead.Name = "offsetHead";
            // 
            // label12
            // 
            resources.ApplyResources(this.label12, "label12");
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label12.Name = "label12";
            // 
            // buttonEXPORT
            // 
            resources.ApplyResources(this.buttonEXPORT, "buttonEXPORT");
            this.buttonEXPORT.ForeColor = System.Drawing.Color.White;
            this.buttonEXPORT.Name = "buttonEXPORT";
            this.buttonEXPORT.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.buttonEXPORT.UseSelectable = true;
            this.buttonEXPORT.Click += new System.EventHandler(this.buttonEXPORT_Click);
            // 
            // buttonIMPORT
            // 
            resources.ApplyResources(this.buttonIMPORT, "buttonIMPORT");
            this.buttonIMPORT.ForeColor = System.Drawing.Color.White;
            this.buttonIMPORT.Name = "buttonIMPORT";
            this.buttonIMPORT.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.buttonIMPORT.UseSelectable = true;
            this.buttonIMPORT.Click += new System.EventHandler(this.buttonIMPORT_Click);
            // 
            // buttonImportModel
            // 
            resources.ApplyResources(this.buttonImportModel, "buttonImportModel");
            this.buttonImportModel.ForeColor = System.Drawing.Color.White;
            this.buttonImportModel.Name = "buttonImportModel";
            this.buttonImportModel.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.buttonImportModel.UseSelectable = true;
            this.buttonImportModel.Click += new System.EventHandler(this.buttonImportModel_Click);
            // 
            // buttonExportModel
            // 
            resources.ApplyResources(this.buttonExportModel, "buttonExportModel");
            this.buttonExportModel.ForeColor = System.Drawing.Color.White;
            this.buttonExportModel.Name = "buttonExportModel";
            this.buttonExportModel.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.buttonExportModel.UseSelectable = true;
            this.buttonExportModel.Click += new System.EventHandler(this.buttonExportModel_Click);
            // 
            // OpenJSONButton
            // 
            resources.ApplyResources(this.OpenJSONButton, "OpenJSONButton");
            this.OpenJSONButton.ForeColor = System.Drawing.Color.White;
            this.OpenJSONButton.Name = "OpenJSONButton";
            this.OpenJSONButton.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.OpenJSONButton.UseSelectable = true;
            this.OpenJSONButton.Click += new System.EventHandler(this.OpenJSONButton_Click);
            // 
            // generateTextureCheckBox
            // 
            resources.ApplyResources(this.generateTextureCheckBox, "generateTextureCheckBox");
            this.generateTextureCheckBox.Name = "generateTextureCheckBox";
            this.generateTextureCheckBox.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.generateTextureCheckBox.UseSelectable = true;
            // 
            // checkGuide
            // 
            resources.ApplyResources(this.checkGuide, "checkGuide");
            this.checkGuide.Name = "checkGuide";
            this.checkGuide.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.checkGuide.UseSelectable = true;
            // 
            // checkBoxArmor
            // 
            resources.ApplyResources(this.checkBoxArmor, "checkBoxArmor");
            this.checkBoxArmor.Name = "checkBoxArmor";
            this.checkBoxArmor.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.checkBoxArmor.UseSelectable = true;
            // 
            // SizeXUpDown
            // 
            resources.ApplyResources(this.SizeXUpDown, "SizeXUpDown");
            this.SizeXUpDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.SizeXUpDown.DecimalPlaces = 1;
            this.SizeXUpDown.ForeColor = System.Drawing.SystemColors.Menu;
            this.SizeXUpDown.Name = "SizeXUpDown";
            // 
            // SizeYUpDown
            // 
            resources.ApplyResources(this.SizeYUpDown, "SizeYUpDown");
            this.SizeYUpDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.SizeYUpDown.DecimalPlaces = 1;
            this.SizeYUpDown.ForeColor = System.Drawing.SystemColors.Menu;
            this.SizeYUpDown.Name = "SizeYUpDown";
            // 
            // SizeZUpDown
            // 
            resources.ApplyResources(this.SizeZUpDown, "SizeZUpDown");
            this.SizeZUpDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.SizeZUpDown.DecimalPlaces = 1;
            this.SizeZUpDown.ForeColor = System.Drawing.SystemColors.Menu;
            this.SizeZUpDown.Name = "SizeZUpDown";
            // 
            // TextureXUpDown
            // 
            resources.ApplyResources(this.TextureXUpDown, "TextureXUpDown");
            this.TextureXUpDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.TextureXUpDown.ForeColor = System.Drawing.SystemColors.Menu;
            this.TextureXUpDown.Maximum = new decimal(new int[] {
            64,
            0,
            0,
            0});
            this.TextureXUpDown.Name = "TextureXUpDown";
            // 
            // TextureYUpDown
            // 
            resources.ApplyResources(this.TextureYUpDown, "TextureYUpDown");
            this.TextureYUpDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.TextureYUpDown.ForeColor = System.Drawing.SystemColors.Menu;
            this.TextureYUpDown.Maximum = new decimal(new int[] {
            64,
            0,
            0,
            0});
            this.TextureYUpDown.Name = "TextureYUpDown";
            // 
            // PosZUpDown
            // 
            resources.ApplyResources(this.PosZUpDown, "PosZUpDown");
            this.PosZUpDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.PosZUpDown.DecimalPlaces = 1;
            this.PosZUpDown.ForeColor = System.Drawing.SystemColors.Menu;
            this.PosZUpDown.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.PosZUpDown.Name = "PosZUpDown";
            // 
            // PosYUpDown
            // 
            resources.ApplyResources(this.PosYUpDown, "PosYUpDown");
            this.PosYUpDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.PosYUpDown.DecimalPlaces = 1;
            this.PosYUpDown.ForeColor = System.Drawing.SystemColors.Menu;
            this.PosYUpDown.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.PosYUpDown.Name = "PosYUpDown";
            // 
            // PosXUpDown
            // 
            resources.ApplyResources(this.PosXUpDown, "PosXUpDown");
            this.PosXUpDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.PosXUpDown.DecimalPlaces = 1;
            this.PosXUpDown.ForeColor = System.Drawing.SystemColors.Menu;
            this.PosXUpDown.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.PosXUpDown.Name = "PosXUpDown";
            // 
            // renderer3D1
            // 
            resources.ApplyResources(this.renderer3D1, "renderer3D1");
            this.renderer3D1.ANIM = skinANIM1;
            this.renderer3D1.BackColor = System.Drawing.Color.DimGray;
            this.renderer3D1.CameraTarget = ((OpenTK.Vector2)(resources.GetObject("renderer3D1.CameraTarget")));
            this.renderer3D1.Name = "renderer3D1";
            this.renderer3D1.Texture = null;
            this.renderer3D1.VSync = true;
            this.renderer3D1.TextureChanging += new System.EventHandler<PckStudio.Rendering.TextureChangingEventArgs>(this.renderer3D1_TextureChanging);
            // 
            // uvPictureBox
            // 
            resources.ApplyResources(this.uvPictureBox, "uvPictureBox");
            this.uvPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uvPictureBox.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            this.uvPictureBox.Name = "uvPictureBox";
            this.uvPictureBox.TabStop = false;
            // 
            // listBox1
            // 
            this.listBox1.ContextMenuStrip = this.contextMenuStrip1;
            this.listBox1.FormattingEnabled = true;
            resources.ApplyResources(this.listBox1, "listBox1");
            this.listBox1.Name = "listBox1";
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            this.listBox1.DoubleClick += new System.EventHandler(this.listBox1_DoubleClick);
            // 
            // CustomModelEditor
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.renderer3D1);
            this.Controls.Add(this.PosZUpDown);
            this.Controls.Add(this.PosYUpDown);
            this.Controls.Add(this.PosXUpDown);
            this.Controls.Add(this.TextureYUpDown);
            this.Controls.Add(this.TextureXUpDown);
            this.Controls.Add(this.SizeZUpDown);
            this.Controls.Add(this.SizeYUpDown);
            this.Controls.Add(this.SizeXUpDown);
            this.Controls.Add(this.checkBoxArmor);
            this.Controls.Add(this.checkGuide);
            this.Controls.Add(this.generateTextureCheckBox);
            this.Controls.Add(this.OpenJSONButton);
            this.Controls.Add(this.buttonExportModel);
            this.Controls.Add(this.buttonImportModel);
            this.Controls.Add(this.buttonEXPORT);
            this.Controls.Add(labelTextureMappingPreview);
            this.Controls.Add(this.uvPictureBox);
            this.Controls.Add(this.buttonIMPORT);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(label7);
            this.Controls.Add(this.buttonDone);
            this.Controls.Add(label3);
            this.Controls.Add(label5);
            this.MaximizeBox = false;
            this.Name = "CustomModelEditor";
            this.Style = MetroFramework.MetroColorStyle.Silver;
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.generateModel_FormClosing);
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tabBody.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.myTablePanel2.ResumeLayout(false);
            this.myTablePanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SizeXUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SizeYUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SizeZUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextureXUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextureYUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PosZUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PosYUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PosXUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uvPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem createToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cloneToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeColorToolStripMenuItem;
        private MetroFramework.Controls.MetroButton buttonDone;
        private MetroFramework.Controls.MetroButton OpenJSONButton;
        private MetroFramework.Controls.MetroButton buttonExportModel;
        private MetroFramework.Controls.MetroButton buttonImportModel;
        private PckStudio.ToolboxItems.InterpolationPictureBox uvPictureBox;
        private MetroFramework.Controls.MetroButton buttonIMPORT;
        private MetroFramework.Controls.MetroButton buttonEXPORT;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabControl tabBody;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TableLayoutPanel myTablePanel2;
        private System.Windows.Forms.TextBox offsetArms;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox offsetBody;
        private System.Windows.Forms.TextBox offsetLegs;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox offsetHead;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TabPage tabArmor;
        private MetroFramework.Controls.MetroCheckBox generateTextureCheckBox;
        private MetroFramework.Controls.MetroCheckBox checkGuide;
        private MetroFramework.Controls.MetroCheckBox checkBoxArmor;
        private System.Windows.Forms.NumericUpDown SizeXUpDown;
        private System.Windows.Forms.NumericUpDown SizeYUpDown;
        private System.Windows.Forms.NumericUpDown SizeZUpDown;
        private System.Windows.Forms.NumericUpDown TextureXUpDown;
        private System.Windows.Forms.NumericUpDown TextureYUpDown;
        private System.Windows.Forms.NumericUpDown PosZUpDown;
        private System.Windows.Forms.NumericUpDown PosYUpDown;
        private System.Windows.Forms.NumericUpDown PosXUpDown;
        private Rendering.SkinRenderer renderer3D1;
        private System.Windows.Forms.ListBox listBox1;
    }
}