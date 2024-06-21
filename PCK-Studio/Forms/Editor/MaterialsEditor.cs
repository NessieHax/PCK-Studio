﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using MetroFramework.Forms;
using Newtonsoft.Json.Linq;
using OMI.Formats.Pck;
using OMI.Formats.Material;
using OMI.Workers.Material;
using PckStudio.Internal;
using PckStudio.Extensions;
using PckStudio.Internal.Json;
using PckStudio.Internal.App;

namespace PckStudio.Forms.Editor
{
	public partial class MaterialsEditor : MetroForm
	{
		// Materials File Format research by PhoenixARC
		private readonly PckAsset _asset;
		MaterialContainer materialFile;

		private readonly List<EntityInfo> MaterialData = Entities.BehaviourInfos;

		private bool showInvalidEntries;

		//Holds invalid entries so they can be added back to the material file on save should the user decide to hide them
		List<MaterialContainer.Material> hiddenInvalidEntries = new List<MaterialContainer.Material>();

		void SetUpTree()
		{
			treeView1.BeginUpdate();
			treeView1.Nodes.Clear();
			foreach (var entry in materialFile)
			{
				TreeNode EntryNode = new TreeNode(entry.Name);

				var material = MaterialData.Find(m => m.InternalName == entry.Name);
				if(material != null)
                {
					EntryNode.Text = material.DisplayName;
					EntryNode.ImageIndex = MaterialData.IndexOf(material);
					EntryNode.Tag = entry;
				}
				// check for invalid material entry
				else
                {
					EntryNode.ImageIndex = 127; // icon for invalid entry
					EntryNode.Text += " (Invalid)";

					if (!showInvalidEntries)
                    {
						hiddenInvalidEntries.Add(entry);
						continue;
					}
                }

				EntryNode.SelectedImageIndex = EntryNode.ImageIndex;

				treeView1.Nodes.Add(EntryNode);
			}
			treeView1.EndUpdate();
		}

		public MaterialsEditor(PckAsset asset)
		{
			InitializeComponent();
			_asset = asset;

			using (var stream = new MemoryStream(asset.Data))
			{
				var reader = new MaterialFileReader();
				materialFile = reader.FromStream(stream);

				if (materialFile.hasInvalidEntries())
                {
					DialogResult dr = MessageBox.Show(this, "Unsupported entities were found in this file. Would you like to display them?", "Invalid data found", MessageBoxButtons.YesNo);

					showInvalidEntries = dr == DialogResult.Yes;
				}

				treeView1.ImageList = new ImageList();
				ApplicationScope.EntityImages.ToList().ForEach(treeView1.ImageList.Images.Add);
				treeView1.ImageList.ColorDepth = ColorDepth.Depth32Bit;
				SetUpTree();
			}
		}

		private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
		{
			if (e.Node == null) return;

			bool enable = e.Node.Tag is MaterialContainer.Material && treeView1.SelectedNode != null;
			materialComboBox.Enabled = enable;

			if (e.Node.Tag is MaterialContainer.Material entry)
			{
				materialComboBox.SelectedIndexChanged -= materialComboBox_SelectedIndexChanged;
				materialComboBox.SelectedIndex = materialComboBox.Items.IndexOf(entry.Type);
				materialComboBox.SelectedIndexChanged += materialComboBox_SelectedIndexChanged;
			}
		}
		private void removeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (treeView1.SelectedNode == null) return;

			treeView1.SelectedNode.Remove();
		}

		private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
		{
			materialComboBox.Enabled = false;
		}

		private void treeView1_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Delete) removeToolStripMenuItem_Click(sender, e);
		}

		private void saveToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			materialFile = new MaterialContainer();

			foreach (TreeNode node in treeView1.Nodes)
			{
				if(node.Tag is MaterialContainer.Material entry)
				{
					materialFile.Add(entry);
				}
			}

			foreach (MaterialContainer.Material mat in hiddenInvalidEntries)
			{
				materialFile.Add(mat);
			}

			_asset.SetData(new MaterialFileWriter(materialFile));
			
			DialogResult = DialogResult.OK;
		}

		private void addToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var diag = new Additional_Popups.EntityForms.AddEntry("materials", ApplicationScope.EntityImages);

			if (diag.ShowDialog(this) == DialogResult.OK)
			{
				if (string.IsNullOrEmpty(diag.SelectedEntity)) return;
				if (materialFile.FindAll(mat => mat.Name == diag.SelectedEntity).Count() > 0)
				{
					MessageBox.Show(this, "You cannot have two entries for one entity. Please use the \"Add New Position Override\" tool to add multiple overrides for entities", "Error", MessageBoxButtons.OK);
					return;
				}
				var NewEntry = new MaterialContainer.Material(diag.SelectedEntity, "entity_alphatest");

				TreeNode NewEntryNode = new TreeNode(NewEntry.Name);
				NewEntryNode.Tag = NewEntry;

				var material = MaterialData.Find(m => m.InternalName == NewEntry.Name);
				NewEntryNode.Text = material.DisplayName;
				NewEntryNode.ImageIndex = MaterialData.IndexOf(material);
				NewEntryNode.SelectedImageIndex = NewEntryNode.ImageIndex;
				treeView1.Nodes.Add(NewEntryNode);
			}
		}

		private void materialComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (treeView1.SelectedNode.Tag is MaterialContainer.Material entry)
			{
				entry.Type = materialComboBox.SelectedItem.ToString();
				treeView1.SelectedNode.Tag = entry;
			}
		}
	}
}
