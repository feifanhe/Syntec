using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Syntec.Module;
using System.IO;

namespace Syntec.Windows
{
	public partial class NewFileDialog : Form
	{
		#region Properties

		public string SelectedModule
		{
			get
			{
				return this.Modules_ListView.SelectedItems[ 0 ].SubItems[ 0 ].Text;
			}
		}

		public string FileName
		{
			get
			{
				return this.Location_TextBox.Text + "\\" + this.Name_TextBox.Text;
			}
		}

		#endregion

		#region ShowDialog

		public NewFileDialog( string workspacePath )
		{
			InitializeComponent();
			this.Location_TextBox.Text = workspacePath;
			RefreshPluginList();
		}

		private void RefreshPluginList()
		{
			//ModuleManager.Refresh();

			this.Modules_ListView.Items.Clear();

			// Dummy items
			ListViewItem LVI;

			// Populate available plugins to plugin list
			foreach( Syntec.Module.Module module in ModuleManager.AvailableModules ) {
				LVI = new ListViewItem( module.Name );
				LVI.SubItems.Add( module.Version );
				LVI.SubItems.Add( module.Description );

				LVI.Checked = module.Enabled;

				this.Modules_ListView.Items.Add( LVI );
			}

			if( this.Modules_ListView.Items.Count > 0 ) {
				this.Modules_ListView.Items[ 0 ].Selected = true;
			}
			else {
				MessageBox.Show( "No available modules" );
				this.DialogResult = DialogResult.Abort;
			}
		}

		#endregion

		#region Button Click

		private void Browse_Button_Click( object sender, EventArgs e )
		{
			Ookii.Dialogs.VistaFolderBrowserDialog dialog = new Ookii.Dialogs.VistaFolderBrowserDialog();
			dialog.SelectedPath = this.Location_TextBox.Text;
			if( dialog.ShowDialog() == DialogResult.OK ) {
				this.Location_TextBox.Text = dialog.SelectedPath;
			}
		}

		private void OK_Button_Click( object sender, EventArgs e )
		{
			// Check directory
			if( !Directory.Exists( this.Location_TextBox.Text ) ) {
				MessageBox.Show( "Directory not exists" );
				return;
			}

			// Check file name
			int ExtensionIndex = this.Name_TextBox.Text.ToLower().LastIndexOf( ".xml" );
			MessageBox.Show( this.Name_TextBox.Text );
			if( ExtensionIndex == -1 ) {
				this.Name_TextBox.Text = this.Name_TextBox.Text + ".xml";
			}
			else {
				this.Name_TextBox.Text = this.Name_TextBox.Text.Remove( ExtensionIndex ) + ".xml";
			}

			// TODO: File exists
			if( File.Exists( this.FileName ) ) {
				if( MessageBox.Show(
					this,
					this.Name_TextBox.Text + "already exists. Would you like to replace it?",
					"Confirm create file",
					MessageBoxButtons.OKCancel, 
					MessageBoxIcon.Warning ) != DialogResult.OK ) {
					return;
				}
			}

			// Create file
			File.Create( this.FileName );

			this.DialogResult = DialogResult.OK;
		}

		private void Cancel_Button_Click( object sender, EventArgs e )
		{
			this.DialogResult = DialogResult.Cancel;
		}

		#endregion

	}
}