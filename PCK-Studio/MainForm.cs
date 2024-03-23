﻿using System;
using System.Collections.Generic;
using System.Collections;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Diagnostics;
using System.Drawing.Imaging;
using OMI.Formats.Archive;
using OMI.Formats.Pck;
using OMI.Formats.GameRule;
using OMI.Formats.Languages;
using OMI.Workers.Archive;
using OMI.Workers.Pck;
using OMI.Workers.GameRule;
using OMI.Workers.Language;
using PckStudio.Properties;
using PckStudio.Forms;
using PckStudio.Forms.Editor;
using PckStudio.Forms.Additional_Popups.Animation;
using PckStudio.Forms.Additional_Popups;
using PckStudio.Classes.Misc;
using PckStudio.IO.PckAudio;
using PckStudio.IO._3DST;
using PckStudio.Internal;
using PckStudio.Features;
using PckStudio.Extensions;
using PckStudio.Popups;
using PckStudio.Classes.Utils;
using PckStudio.Helper;
using PckStudio.Controls;
using PckStudio.Interfaces;
using PCKStudio_Updater;

namespace PckStudio
{
	public partial class MainForm : MetroFramework.Forms.MetroForm
	{
		private PckManager PckManager = null;

		private Dictionary<string, TabPage> openFiles = new Dictionary<string, TabPage>();

		IComparer NodeSorter = new PckNodeSorter();

		public MainForm()
		{
			InitializeComponent();
			pckOpen.AllowDrop = true;
			Text = Application.ProductName;
			ChangelogRichTextBox.Text = Resources.CHANGELOG;
			labelVersion.Text = $"{Application.ProductName}: {Application.ProductVersion}";
		}

		public void LoadPckFromFile(IEnumerable<string> filepaths)
		{
			foreach (string filepath in filepaths)
			{
				LoadPckFromFile(filepath);
			}
		}

		public void LoadPckFromFile(string filepath)
		{
			AddEditorPage(filepath);
		}

		private TabPage AddPage(string caption, Control control)
		{
			control.Dock = DockStyle.Fill;
			var page = new TabPage(caption);
			page.Controls.Add(control);
			tabControl.TabPages.Add(page);
			tabControl.SelectTab(page);
			return page;
		}

		private void AddEditorPage(PckFile pck)
		{
			var editor = new PckEditor();
			editor.Open(pck);
			AddPage("Unsaved pck", editor);
		}

		private void AddEditorPage(string filepath)
		{
			if (openFiles.ContainsKey(filepath))
			{
				tabControl.SelectTab(openFiles[filepath]);
				return;
			}

			var editor = new PckEditor();
			if (editor.Open(filepath, Settings.Default.UseLittleEndianAsDefault ? OMI.Endianness.LittleEndian : OMI.Endianness.BigEndian))
			{
				var page = AddPage(Path.GetFileName(filepath), editor);
				openFiles.Add(filepath, page);
				return;
			}
			MessageBox.Show(string.Format("Failed to load {0}", Path.GetFileName(filepath)), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		private bool TryGetEditor(TabPage page, out IEditor<PckFile> editor)
		{
			if (page.Controls[0] is IEditor<PckFile> _editor)
			{
				editor = _editor;
				return true;
			}
			editor = null;
			return false;
		}

		private bool TryGetEditor(out IEditor<PckFile> editor)
		{
			return TryGetEditor(tabControl.SelectedTab, out editor);
		}

		#region drag and drop for main tree node

		// Most of the code below is modified code from this link: https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.treeview.itemdrag?view=windowsdesktop-6.0
		// - MattNL

		private void treeViewMain_ItemDrag(object sender, ItemDragEventArgs e)
		{

		}

		// Set the target drop effect to the effect 
		// specified in the ItemDrag event handler.
		private void treeViewMain_DragEnter(object sender, DragEventArgs e)
		{
			e.Effect = e.AllowedEffect;
		}

		// Select the node under the mouse pointer to indicate the 
		// expected drop location.
		private void treeViewMain_DragOver(object sender, DragEventArgs e)
		{

		}

		private void treeViewMain_DragDrop(object sender, DragEventArgs e)
		{

		}

		#endregion

		private PckFile InitializePack(int packId, int packVersion, string packName, bool createSkinsPCK)
		{
			var pack = new PckFile(3);

			var zeroFile = pack.CreateNewFile("0", PckFileType.InfoFile);
			zeroFile.AddProperty("PACKID", packId);
			zeroFile.AddProperty("PACKVERSION", packVersion);

			var locFile = new LOCFile();
			locFile.InitializeDefault(packName);
			pack.CreateNewFile("localisation.loc", PckFileType.LocalisationFile, new LOCFileWriter(locFile, 2));

			pack.CreateNewFileIf(createSkinsPCK, "Skins.pck", PckFileType.SkinDataFile, new PckFileWriter(new PckFile(3, true),
				LittleEndianCheckBox.Checked
					? OMI.Endianness.LittleEndian
					: OMI.Endianness.BigEndian));

			return pack;
		}

		private PckFile InitializeTexturePack(int packId, int packVersion, string packName, string res, bool createSkinsPCK)
		{
			var pack = InitializePack(packId, packVersion, packName, createSkinsPCK);
			PckFile infoPCK = new PckFile(3);

			var icon = infoPCK.CreateNewFile("icon.png", PckFileType.TextureFile);
			icon.SetData(Resources.TexturePackIcon, ImageFormat.Png);

			var comparison = infoPCK.CreateNewFile("comparison.png", PckFileType.TextureFile);
			comparison.SetData(Resources.Comparison, ImageFormat.Png);

			var texturepackInfo = pack.CreateNewFile($"{res}/{res}Info.pck", PckFileType.TexturePackInfoFile);

			texturepackInfo.AddProperty("PACKID", "0");
			texturepackInfo.AddProperty("DATAPATH", $"{res}Data.pck");

			texturepackInfo.SetData(new PckFileWriter(infoPCK, LittleEndianCheckBox.Checked ? OMI.Endianness.LittleEndian : OMI.Endianness.BigEndian));

			return pack;
		}

		private PckFile InitializeMashUpPack(int packId, int packVersion, string packName, string res)
		{
			var pack = InitializeTexturePack(packId, packVersion, packName, res, true);
			var gameRuleFile = pack.CreateNewFile("GameRules.grf", PckFileType.GameRulesFile);
			var grfFile = new GameRuleFile();
			grfFile.AddRule("MapOptions",
				new KeyValuePair<string, string>("seed", "0"),
				new KeyValuePair<string, string>("baseSaveName", string.Empty),
				new KeyValuePair<string, string>("flatworld", "false"),
				new KeyValuePair<string, string>("texturePackId", packId.ToString())
				);
			grfFile.AddRule("LevelRules")
				.AddRule("UpdatePlayer",
				new KeyValuePair<string, string>("yRot", "0"),
				new KeyValuePair<string, string>("xRot", "0"),
				new KeyValuePair<string, string>("spawnX", "0"),
				new KeyValuePair<string, string>("spawnY", "0"),
				new KeyValuePair<string, string>("spawnZ", "0")
				);

			gameRuleFile.SetData(new GameRuleFileWriter(grfFile));

			return pack;
		}

		private void skinPackToolStripMenuItem_Click(object sender, EventArgs e)
		{
			TextPrompt namePrompt = new TextPrompt();
			namePrompt.OKButtonText = "Ok";
			if (namePrompt.ShowDialog() == DialogResult.OK)
			{
                var currentPCK = InitializePack(new Random().Next(8000, int.MaxValue), 0, namePrompt.NewText, true);
                AddEditorPage(currentPCK);
            }
		}

		private void texturePackToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var packPrompt = new CreateTexturePackPrompt();
			if (packPrompt.ShowDialog() == DialogResult.OK)
			{
                var currentPCK = InitializeTexturePack(new Random().Next(8000, int.MaxValue), 0, packPrompt.PackName, packPrompt.PackRes, packPrompt.CreateSkinsPck);
                AddEditorPage(currentPCK);
            }
		}

		private void mashUpPackToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var packPrompt = new CreateTexturePackPrompt();
			if (packPrompt.ShowDialog() == DialogResult.OK)
			{
                var currentPCK = InitializeMashUpPack(new Random().Next(8000, int.MaxValue), 0, packPrompt.PackName, packPrompt.PackRes);
				AddEditorPage(currentPCK);
            }
		}

		private void CloseTab(TabControl.TabPageCollection collection, TabPage page)
		{
			if (TryGetEditor(page, out var editor))
			{
				editor.Close();
				RemoveOpenFile(page);
				collection.Remove(page);
			}
		}

		private void openToolStripMenuItem_Click(object sender, EventArgs e)
		{
			using (var ofd = new OpenFileDialog())
			{
				ofd.CheckFileExists = true;
				ofd.Multiselect = true;
				ofd.Filter = "PCK (Minecraft Console Package)|*.pck";
				if (ofd.ShowDialog() == DialogResult.OK)
				{
					LoadPckFromFile(ofd.FileNames);
				}
			}
		}

		private void quickChangeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (TryGetEditor(out var editor))
			{
				using AdvancedOptions advanced = new AdvancedOptions(editor.Value);
				advanced.IsLittleEndian = LittleEndianCheckBox.Checked;
				if (advanced.ShowDialog() == DialogResult.OK)
				{
					editor.UpdateView();
				}
			}
		}

		private void closeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			CloseTab(tabControl.TabPages, tabControl.SelectedTab);
		}

		private void RemoveOpenFile()
		{
			RemoveOpenFile(tabControl.SelectedTab);
		}

		private void RemoveOpenFile(TabPage page)
		{
			var kv = openFiles.FirstOrDefault((kv) => kv.Value == page);
			if (kv.Key != null && kv.Value != null)
			{
				openFiles.Remove(kv.Key);
			}
		}

		private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
		{
			using CreditsForm info = new CreditsForm();
			info.ShowDialog();
		}

		private void extractToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			// Tries to extract a chosen pck file to a chosen destination
			try
			{
				using OpenFileDialog ofd = new OpenFileDialog();
				using FolderBrowserDialog sfd = new FolderBrowserDialog();
				ofd.CheckFileExists = true;
				ofd.Filter = "PCK (Minecraft Console Package)|*.pck";

				if (ofd.ShowDialog() == DialogResult.OK && sfd.ShowDialog() == DialogResult.OK)
				{
					PckFile pckfile = null;
					using (var fs = File.OpenRead(ofd.FileName))
					{
						try
						{
							var reader = new PckFileReader(
								Settings.Default.UseLittleEndianAsDefault
									? OMI.Endianness.LittleEndian
									: OMI.Endianness.BigEndian);
							pckfile = reader.FromStream(fs);
						}
						catch (OverflowException ex)
						{
							Debug.WriteLine(ex.Message);
							Trace.WriteLine("Failed to open " + ofd.FileName);
							MessageBox.Show("Error", "Failed to open pck\nTry checking the 'Open/Save as Switch/Vita/PS4 pck' check box in the upper right corner.",
								MessageBoxButtons.OK, MessageBoxIcon.Error);
						}
					}
					foreach (PckFileData file in pckfile.GetFiles())
					{
						string filepath = $"{sfd.SelectedPath}/{file.Filename}";
						Directory.CreateDirectory(filepath);
						File.WriteAllBytes(filepath, file.Data); // writes data to file
																 //attempts to generate reimportable metadata file out of minefiles metadata
						string metaData = "";

						foreach (var entry in file.GetProperties())
						{
							metaData += $"{entry.Key}: {entry.Value}{Environment.NewLine}";
						}

						File.WriteAllText(sfd.SelectedPath + @"\" + file.Filename + ".txt", metaData);
					}
				}
			}
			catch (Exception)
			{
				MessageBox.Show("An Error occured while extracting data");
			}
		}

		public string GetDataPath()
		{
			throw new NotImplementedException();
			//return Path.Combine(Path.GetDirectoryName(saveLocation), "Data");
		}

		public bool HasDataFolder()
		{
			return Directory.Exists(GetDataPath());
		}

		public bool CreateDataFolder()
		{
			if (!HasDataFolder())
			{
				DialogResult result = MessageBox.Show("There is not a \"Data\" folder present in the pack folder. Would you like to create one?", "Folder missing", MessageBoxButtons.YesNo);
				if (result == DialogResult.No) return false;
				else Directory.CreateDirectory(GetDataPath());
			}
			return true;
		}

		private void binkaConversionToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Process.Start("https://www.youtube.com/watch?v=v6EYr4zc7rI");
		}

		private void fAQToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			//System.Diagnostics.Process.Start(hosturl + "pckStudio#faq");
		}

		private void openPckCenterToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MessageBox.Show("This feature is currently being reworked.", "Currently unavailable", MessageBoxButtons.OK, MessageBoxIcon.Information);
#if false
			DateTime Begin = DateTime.Now;
			//pckCenter open = new pckCenter();
			PckCenterBeta open = new PckCenterBeta();
			open.Show();
			TimeSpan duration = new TimeSpan(DateTime.Now.Ticks - Begin.Ticks);

			Debug.WriteLine("Completed in: " + duration);
#endif
		}

		private void howToMakeABasicSkinPackToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Process.Start("https://www.youtube.com/watch?v=A43aHRHkKxk");
		}

		private void howToMakeACustomSkinModelToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Process.Start("https://www.youtube.com/watch?v=pEC_ug55lag");
		}

		private void howToMakeCustomSkinModelsbedrockToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Process.Start("https://www.youtube.com/watch?v=6z8NTogw5x4");
		}

		private void howToMakeCustomMusicToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Process.Start("https://www.youtube.com/watch?v=v6EYr4zc7rI");
		}

		private void howToInstallPcksDirectlyToWiiUToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Process.Start("https://www.youtube.com/watch?v=hRQagnEplec");
		}

		private void pckCenterReleaseToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Process.Start("https://www.youtube.com/watch?v=E_6bXSh6yqw");
		}

		private void howPCKsWorkToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Process.Start("https://www.youtube.com/watch?v=hTlImrRrCKQ");
		}

		private void toPhoenixARCDeveloperToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Process.Start("https://cash.app/$PhoenixARC");
		}

		private void toNobledezJackToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Process.Start("https://www.paypal.me/realnobledez");
		}

		private void forMattNLContributorToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Process.Start("https://ko-fi.com/mattnl");
		}

		private void joinDevelopmentDiscordToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Process.Start("https://discord.gg/aJtZNFVQTv");
		}

		private void OpenPck_MouseEnter(object sender, EventArgs e)
		{
			pckOpen.Image = Resources.pckOpen;
		}

		private void OpenPck_MouseLeave(object sender, EventArgs e)
		{
			pckOpen.Image = Resources.pckClosed;
		}

		private void OpenPck_DragEnter(object sender, DragEventArgs e)
		{
			pckOpen.Image = Resources.pckDrop;
			string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
			foreach (var file in files)
			{
				var ext = Path.GetExtension(file);
				if (ext.Equals(".pck", StringComparison.CurrentCultureIgnoreCase))
					e.Effect = DragDropEffects.Copy;
				return;
			}
		}

		private void OpenPck_DragDrop(object sender, DragEventArgs e)
		{
			string[] filepaths = (string[])e.Data.GetData(DataFormats.FileDrop, false);
			LoadPckFromFile(filepaths);
		}

		private void OpenPck_DragLeave(object sender, EventArgs e)
		{
			pckOpen.Image = Resources.pckClosed;
		}

		private void OpenPck_Click(object sender, EventArgs e)
		{
			openToolStripMenuItem_Click(sender, e);
		}

		private void saveToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (TryGetEditor(out var editor))
			{
				editor.Save();
			}
		}

		private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (TryGetEditor(out var editor))
			{
				editor.SaveAs();
			}
		}

		private void trelloBoardToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Process.Start("https://trello.com/b/0XLNOEbe/pck-studio");
		}

		private void openPckManagerToolStripMenuItem_Click(object sender, EventArgs e)
		{
			PckManager ??= new PckManager();
			PckManager.FormClosing += (s, e) =>
			{
				PckManager.Hide();
				e.Cancel = true;
			};
			if (!PckManager.Visible)
			{
				PckManager.Show();
				PckManager.BringToFront();
			}
			if (PckManager.Focus())
				PckManager.BringToFront();
		}

		private void wavBinkaToolStripMenuItem_Click(object sender, EventArgs e)
		{
			using OpenFileDialog fileDialog = new OpenFileDialog
			{
				Multiselect = true,
				Filter = "WAV files (*.wav)|*.wav",
				Title = "Please choose WAV files to convert to BINKA"
			};
			if (fileDialog.ShowDialog() == DialogResult.OK)
			{
				BinkaConverter.ToBinka(fileDialog.FileNames, new DirectoryInfo(Path.GetDirectoryName(fileDialog.FileName)));
			}
		}

		private void binkaWavToolStripMenuItem_Click(object sender, EventArgs e)
		{
			using OpenFileDialog fileDialog = new OpenFileDialog
			{
				Multiselect = true,
				Filter = "BINKA files (*.binka)|*.binka",
				Title = "Please choose BINKA files to convert to WAV"
			};
			if (fileDialog.ShowDialog() == DialogResult.OK)
			{
				BinkaConverter.ToWav(fileDialog.FileNames, new DirectoryInfo(Path.GetDirectoryName(fileDialog.FileName)));
			}
		}

		private void fullBoxSupportToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
		{
			if (TryGetEditor(out var editor))
			{
				editor.Value.SetVersion(fullBoxSupportToolStripMenuItem.Checked);
			}
		}

		private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var appSettings = new AppSettingsForm();
			appSettings.ShowDialog(this);
		}

		private void tabControl_PageClosing(object sender, PageClosingEventArgs e)
		{
			if (TryGetEditor(e.Page, out var editor))
			{
				editor.Close();
				RemoveOpenFile();
			}
		}

		private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
		{
			closeToolStripMenuItem.Visible = tabControl.SelectedIndex > 0;
			closeAllToolStripMenuItem.Visible = tabControl.SelectedIndex == 0 && tabControl.TabCount > 1;
			saveAsToolStripMenuItem.Visible = tabControl.SelectedIndex > 0;
			saveToolStripMenuItem.Visible = tabControl.SelectedIndex > 0;


			if (tabControl.TabPages.Count == 1)
			{
				RPC.SetPresence("An Open Source .PCK File Editor");
			}
		}

		private void closeAllToolStripMenuItem_Click(object sender, EventArgs e)
		{
			foreach (TabPage tab in tabControl.TabPages)
			{
				CloseTab(tabControl.TabPages, tab);
			}
			closeAllToolStripMenuItem.Visible = false;
		}

		private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			PckManager?.Close();
			closeAllToolStripMenuItem_Click(sender, e);
        }

		private void MainForm_Load(object sender, EventArgs e)
		{
			RPC.SetPresence("An Open Source .PCK File Editor");
            SettingsManager.RegisterPropertyChangedCallback(nameof(Settings.Default.LoadSubPcks), () =>
			{
				if (TryGetEditor(out var editor))
				{
					editor.UpdateView();
				}
			});
		}
	}
}