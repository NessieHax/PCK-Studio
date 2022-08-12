﻿namespace PckStudio
{
    partial class addNewSkin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(addNewSkin));
            this.textTheme = new System.Windows.Forms.TextBox();
            this.contextMenuSkin = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.replaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuCape = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.replaceToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonDone = new System.Windows.Forms.Button();
            this.buttonModelGen = new System.Windows.Forms.Button();
            this.comboBoxSkinType = new System.Windows.Forms.ComboBox();
            this.buttonCape = new System.Windows.Forms.Button();
            this.buttonSkin = new System.Windows.Forms.Button();
            this.displayBox = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textThemeName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textSkinName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textSkinID = new System.Windows.Forms.TextBox();
            this.radioAUTO = new System.Windows.Forms.RadioButton();
            this.radioLOCAL = new System.Windows.Forms.RadioButton();
            this.labelSelectTexture = new System.Windows.Forms.Label();
            this.radioSERVER = new System.Windows.Forms.RadioButton();
            this.capePictureBox = new PckStudio.PictureBoxWithInterpolationMode();
            this.skinPictureBoxTexture = new PckStudio.PictureBoxWithInterpolationMode();
            this.contextMenuSkin.SuspendLayout();
            this.contextMenuCape.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.displayBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.capePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.skinPictureBoxTexture)).BeginInit();
            this.SuspendLayout();
            // 
            // textTheme
            // 
            resources.ApplyResources(this.textTheme, "textTheme");
            this.textTheme.Name = "textTheme";
            // 
            // contextMenuSkin
            // 
            this.contextMenuSkin.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.replaceToolStripMenuItem});
            this.contextMenuSkin.Name = "contextMenuSkin";
            resources.ApplyResources(this.contextMenuSkin, "contextMenuSkin");
            // 
            // replaceToolStripMenuItem
            // 
            resources.ApplyResources(this.replaceToolStripMenuItem, "replaceToolStripMenuItem");
            this.replaceToolStripMenuItem.Name = "replaceToolStripMenuItem";
            this.replaceToolStripMenuItem.Click += new System.EventHandler(this.replaceToolStripMenuItem_Click);
            // 
            // contextMenuCape
            // 
            this.contextMenuCape.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.replaceToolStripMenuItem1});
            this.contextMenuCape.Name = "contextMenuCape";
            resources.ApplyResources(this.contextMenuCape, "contextMenuCape");
            // 
            // replaceToolStripMenuItem1
            // 
            resources.ApplyResources(this.replaceToolStripMenuItem1, "replaceToolStripMenuItem1");
            this.replaceToolStripMenuItem1.Name = "replaceToolStripMenuItem1";
            this.replaceToolStripMenuItem1.Click += new System.EventHandler(this.replaceToolStripMenuItem1_Click);
            // 
            // buttonDone
            // 
            resources.ApplyResources(this.buttonDone, "buttonDone");
            this.buttonDone.ForeColor = System.Drawing.Color.White;
            this.buttonDone.Name = "buttonDone";
            this.buttonDone.UseVisualStyleBackColor = true;
            this.buttonDone.Click += new System.EventHandler(this.CreateButton_Click);
            // 
            // buttonModelGen
            // 
            resources.ApplyResources(this.buttonModelGen, "buttonModelGen");
            this.buttonModelGen.ForeColor = System.Drawing.Color.White;
            this.buttonModelGen.Name = "buttonModelGen";
            this.buttonModelGen.UseVisualStyleBackColor = true;
            this.buttonModelGen.Click += new System.EventHandler(this.CreateCustomModel_Click);
            // 
            // comboBoxSkinType
            // 
            resources.ApplyResources(this.comboBoxSkinType, "comboBoxSkinType");
            this.comboBoxSkinType.FormattingEnabled = true;
            this.comboBoxSkinType.Items.AddRange(new object[] {
            resources.GetString("comboBoxSkinType.Items"),
            resources.GetString("comboBoxSkinType.Items1"),
            resources.GetString("comboBoxSkinType.Items2")});
            this.comboBoxSkinType.Name = "comboBoxSkinType";
            // 
            // buttonCape
            // 
            resources.ApplyResources(this.buttonCape, "buttonCape");
            this.buttonCape.Name = "buttonCape";
            this.buttonCape.UseVisualStyleBackColor = true;
            this.buttonCape.Click += new System.EventHandler(this.buttonCape_Click);
            // 
            // buttonSkin
            // 
            resources.ApplyResources(this.buttonSkin, "buttonSkin");
            this.buttonSkin.Name = "buttonSkin";
            this.buttonSkin.UseVisualStyleBackColor = true;
            this.buttonSkin.Click += new System.EventHandler(this.buttonSkin_Click);
            // 
            // displayBox
            // 
            this.displayBox.BackColor = System.Drawing.SystemColors.ControlDark;
            this.displayBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.displayBox, "displayBox");
            this.displayBox.Name = "displayBox";
            this.displayBox.TabStop = false;
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Name = "label3";
            // 
            // textThemeName
            // 
            this.textThemeName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.textThemeName, "textThemeName");
            this.textThemeName.Name = "textThemeName";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Name = "label2";
            // 
            // textSkinName
            // 
            this.textSkinName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.textSkinName, "textSkinName");
            this.textSkinName.Name = "textSkinName";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Name = "label1";
            // 
            // textSkinID
            // 
            this.textSkinID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.textSkinID, "textSkinID");
            this.textSkinID.Name = "textSkinID";
            this.textSkinID.TextChanged += new System.EventHandler(this.textSkinID_TextChanged_1);
            // 
            // radioAUTO
            // 
            resources.ApplyResources(this.radioAUTO, "radioAUTO");
            this.radioAUTO.ForeColor = System.Drawing.Color.White;
            this.radioAUTO.Name = "radioAUTO";
            this.radioAUTO.UseVisualStyleBackColor = true;
            this.radioAUTO.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioLOCAL
            // 
            resources.ApplyResources(this.radioLOCAL, "radioLOCAL");
            this.radioLOCAL.Checked = true;
            this.radioLOCAL.ForeColor = System.Drawing.Color.White;
            this.radioLOCAL.Name = "radioLOCAL";
            this.radioLOCAL.TabStop = true;
            this.radioLOCAL.UseVisualStyleBackColor = true;
            this.radioLOCAL.CheckedChanged += new System.EventHandler(this.radioLOCAL_CheckedChanged);
            // 
            // labelSelectTexture
            // 
            resources.ApplyResources(this.labelSelectTexture, "labelSelectTexture");
            this.labelSelectTexture.ForeColor = System.Drawing.Color.White;
            this.labelSelectTexture.Name = "labelSelectTexture";
            this.labelSelectTexture.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // radioSERVER
            // 
            resources.ApplyResources(this.radioSERVER, "radioSERVER");
            this.radioSERVER.ForeColor = System.Drawing.Color.White;
            this.radioSERVER.Name = "radioSERVER";
            this.radioSERVER.UseVisualStyleBackColor = true;
            this.radioSERVER.CheckedChanged += new System.EventHandler(this.radioSERVER_CheckedChanged);
            // 
            // capePictureBox
            // 
            resources.ApplyResources(this.capePictureBox, "capePictureBox");
            this.capePictureBox.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Default;
            this.capePictureBox.Name = "capePictureBox";
            this.capePictureBox.TabStop = false;
            // 
            // skinPictureBoxTexture
            // 
            resources.ApplyResources(this.skinPictureBoxTexture, "skinPictureBoxTexture");
            this.skinPictureBoxTexture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.skinPictureBoxTexture.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Default;
            this.skinPictureBoxTexture.Name = "skinPictureBoxTexture";
            this.skinPictureBoxTexture.TabStop = false;
            this.skinPictureBoxTexture.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // addnewskin
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.radioSERVER);
            this.Controls.Add(this.labelSelectTexture);
            this.Controls.Add(this.radioLOCAL);
            this.Controls.Add(this.radioAUTO);
            this.Controls.Add(this.buttonDone);
            this.Controls.Add(this.buttonModelGen);
            this.Controls.Add(this.comboBoxSkinType);
            this.Controls.Add(this.buttonCape);
            this.Controls.Add(this.buttonSkin);
            this.Controls.Add(this.capePictureBox);
            this.Controls.Add(this.skinPictureBoxTexture);
            this.Controls.Add(this.displayBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textThemeName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textSkinName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textSkinID);
            this.MaximizeBox = false;
            this.Name = "addnewskin";
            this.Resizable = false;
            this.Style = MetroFramework.MetroColorStyle.Silver;
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.Load += new System.EventHandler(this.addnewskin_Load);
            this.contextMenuSkin.ResumeLayout(false);
            this.contextMenuCape.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.displayBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.capePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.skinPictureBoxTexture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textTheme;
        private System.Windows.Forms.ContextMenuStrip contextMenuSkin;
        private System.Windows.Forms.ToolStripMenuItem replaceToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuCape;
        private System.Windows.Forms.ToolStripMenuItem replaceToolStripMenuItem1;
        private System.Windows.Forms.Button buttonDone;
        private System.Windows.Forms.Button buttonModelGen;
        private System.Windows.Forms.ComboBox comboBoxSkinType;
        private System.Windows.Forms.Button buttonCape;
        private System.Windows.Forms.Button buttonSkin;
        private PictureBoxWithInterpolationMode capePictureBox;
        private PictureBoxWithInterpolationMode skinPictureBoxTexture;
        private System.Windows.Forms.PictureBox displayBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textThemeName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textSkinName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textSkinID;
        private System.Windows.Forms.RadioButton radioAUTO;
        private System.Windows.Forms.RadioButton radioLOCAL;
        private System.Windows.Forms.Label labelSelectTexture;
        private System.Windows.Forms.RadioButton radioSERVER;
    }
}