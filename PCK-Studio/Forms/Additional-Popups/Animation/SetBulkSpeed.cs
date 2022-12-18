﻿using System;
using MetroFramework.Forms;
using System.Windows.Forms;
using PckStudio.Classes.ToolboxItems;

namespace PckStudio.Forms.Additional_Popups.Animation
{
	public partial class SetBulkSpeed : ThemeForm
	{
		public int time => (int)TimeUpDown.Value;
		public SetBulkSpeed(TreeView treeView)
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (time < 0) return;
			DialogResult = DialogResult.OK;
		}

		private void button2_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
		}
	}
}
