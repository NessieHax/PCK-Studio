﻿namespace PckStudio.Forms.Utilities
{
    partial class AppBehaviorSettingsForm
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
            this.autoSaveCheckBox = new MetroFramework.Controls.MetroCheckBox();
            this.SettingToolTip = new MetroFramework.Components.MetroToolTip();
            this.endianCheckBox = new MetroFramework.Controls.MetroCheckBox();
            this.autoUpdateCheckBox = new MetroFramework.Controls.MetroCheckBox();
            this.SuspendLayout();
            // 
            // autoSaveCheckBox
            // 
            this.autoSaveCheckBox.AutoSize = true;
            this.autoSaveCheckBox.Location = new System.Drawing.Point(23, 63);
            this.autoSaveCheckBox.Name = "autoSaveCheckBox";
            this.autoSaveCheckBox.Size = new System.Drawing.Size(76, 15);
            this.autoSaveCheckBox.Style = MetroFramework.MetroColorStyle.White;
            this.autoSaveCheckBox.TabIndex = 0;
            this.autoSaveCheckBox.Text = "Auto Save";
            this.autoSaveCheckBox.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.SettingToolTip.SetToolTip(this.autoSaveCheckBox, "Whether to automatically save changes inside of file editor such as the loc edito" +
        "r");
            this.autoSaveCheckBox.UseSelectable = true;
            this.autoSaveCheckBox.CheckedChanged += new System.EventHandler(this.autoSaveCheckBox_CheckedChanged);
            // 
            // SettingToolTip
            // 
            this.SettingToolTip.Style = MetroFramework.MetroColorStyle.White;
            this.SettingToolTip.StyleManager = null;
            this.SettingToolTip.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // endianCheckBox
            // 
            this.endianCheckBox.AutoSize = true;
            this.endianCheckBox.Location = new System.Drawing.Point(23, 84);
            this.endianCheckBox.Name = "endianCheckBox";
            this.endianCheckBox.Size = new System.Drawing.Size(75, 15);
            this.endianCheckBox.Style = MetroFramework.MetroColorStyle.White;
            this.endianCheckBox.TabIndex = 1;
            this.endianCheckBox.Text = "Open Vita";
            this.endianCheckBox.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.SettingToolTip.SetToolTip(this.endianCheckBox, "Whether to automatically set the \'Open as Switch/Vita pck\' checkbox");
            this.endianCheckBox.UseSelectable = true;
            this.endianCheckBox.CheckedChanged += new System.EventHandler(this.endianCheckBox_CheckedChanged);
            // 
            // autoUpdateCheckBox
            // 
            this.autoUpdateCheckBox.AutoSize = true;
            this.autoUpdateCheckBox.Enabled = false;
            this.autoUpdateCheckBox.Location = new System.Drawing.Point(23, 105);
            this.autoUpdateCheckBox.Name = "autoUpdateCheckBox";
            this.autoUpdateCheckBox.Size = new System.Drawing.Size(90, 15);
            this.autoUpdateCheckBox.Style = MetroFramework.MetroColorStyle.White;
            this.autoUpdateCheckBox.TabIndex = 2;
            this.autoUpdateCheckBox.Text = "Auto Update";
            this.autoUpdateCheckBox.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.SettingToolTip.SetToolTip(this.autoUpdateCheckBox, "Whether to automatically check for updates");
            this.autoUpdateCheckBox.UseSelectable = true;
            // 
            // AppBehaviorSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(527, 270);
            this.Controls.Add(this.autoUpdateCheckBox);
            this.Controls.Add(this.endianCheckBox);
            this.Controls.Add(this.autoSaveCheckBox);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AppBehaviorSettingsForm";
            this.Resizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Style = MetroFramework.MetroColorStyle.Black;
            this.Text = "Application Settings";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AppBehaviorSettingsForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroCheckBox autoSaveCheckBox;
        private MetroFramework.Components.MetroToolTip SettingToolTip;
        private MetroFramework.Controls.MetroCheckBox endianCheckBox;
        private MetroFramework.Controls.MetroCheckBox autoUpdateCheckBox;
    }
}