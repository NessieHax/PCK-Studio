﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PckStudio.Rendering
{
    internal partial class SkinRenderer
    {
        [DebuggerNonUserCode()]
        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing && components is not null)
                {
                    components.Dispose();
                }
            }
            finally
            {
                base.Dispose(disposing);
            }
        }

        // Required by the Windows Form Designer
        private System.ComponentModel.IContainer components;

        // NOTE: The following procedure is required by the Windows Form Designer
        // It can be modified using the Windows Form Designer.  
        // Do not modify it using the code editor.
        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.reToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.guidelineModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // reToolStripMenuItem
            // 
            this.reToolStripMenuItem.Name = "reToolStripMenuItem";
            this.reToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.reToolStripMenuItem.Text = "Re-Init";
            this.reToolStripMenuItem.Click += new System.EventHandler(this.reInitToolStripMenuItem_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reToolStripMenuItem,
            this.guidelineModeToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(159, 48);
            // 
            // guidelineModeToolStripMenuItem
            // 
            this.guidelineModeToolStripMenuItem.Name = "guidelineModeToolStripMenuItem";
            this.guidelineModeToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.guidelineModeToolStripMenuItem.Text = "Guideline Mode";
            this.guidelineModeToolStripMenuItem.Click += new System.EventHandler(this.guidelineModeToolStripMenuItem_Click);
#if DEBUG
            // 
            // debugLabel
            // 
            this.debugLabel = new System.Windows.Forms.Label();
            this.debugLabel.AutoSize = true;
            this.debugLabel.Visible = false;
            this.debugLabel.BackColor = System.Drawing.Color.Transparent;
            this.debugLabel.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.debugLabel.Location = new System.Drawing.Point(3, 4);
            this.debugLabel.Name = "debugLabel";
            this.debugLabel.Size = new System.Drawing.Size(37, 13);
            this.debugLabel.TabIndex = 2;
            this.debugLabel.Text = "debug";
            var debugToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem("Show debug information");
            debugToolStripMenuItem.CheckOnClick = true;
            debugToolStripMenuItem.Click += (s, e) => debugLabel.Visible = debugToolStripMenuItem.Checked;
            this.contextMenuStrip1.Items.Add(debugToolStripMenuItem);
#endif
            // 
            // SkinRenderer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.debugLabel);
            this.Name = "SkinRenderer";
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private System.Windows.Forms.ToolStripMenuItem reToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem guidelineModeToolStripMenuItem;
#if DEBUG
        private System.Windows.Forms.Label debugLabel;
#endif
    }
}
