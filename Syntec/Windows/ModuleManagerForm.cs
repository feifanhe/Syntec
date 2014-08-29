using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Diagnostics;
using Syntec.Module;

namespace Syntec.Windows
{
	public partial class ModuleManagerForm : Form
	{
		// Indicate whether the check state has varied
		private bool checkboxModified;
		
		public ModuleManagerForm( ) {
			InitializeComponent();
		}

		#region Form related

		private void PluginManagerForm_Load(object sender, EventArgs e) {
			RefreshPluginList();

			checkboxModified = false;
		}

		#endregion

		#region Methods

		private void RefreshPluginList( ) {
			//ModuleManager.Refresh();

			PluginList.Items.Clear();

			// Dummy items
			ListViewItem LVI;

			// Populate available plugins to plugin list
			foreach( Syntec.Module.Module module in ModuleManager.AvailableModules )
			{
				LVI = new ListViewItem( module.Name);
				LVI.SubItems.Add( module.Version);
				LVI.SubItems.Add( module.Description );

				LVI.Checked = module.Enabled;

				PluginList.Items.Add( LVI );
			}
		}

		#endregion

		#region Button actions

		private void BrowseButton_Click(object sender, EventArgs e) {
			Process.Start( Application.StartupPath + ModuleManager.ModuleFolderPath );
		}

		private void RefreshButton_Click(object sender, EventArgs e) {
			RefreshPluginList();
		}

		private void OKButton_Click(object sender, EventArgs e) {
			if( checkboxModified )
			{
				MessageBox.Show( "Any changed won't be applied until restart!",
									"Save Change",
									MessageBoxButtons.OK,
									MessageBoxIcon.Exclamation );
				// SAVE

			}

			this.Close();
		}

		private void CancelButton_Click(object sender, EventArgs e) {
			this.Close();
		}

		#endregion

		#region List view events

		private void PluginList_ItemChecked(object sender, ItemCheckedEventArgs e) {
			checkboxModified = true;
		}

		#endregion
	}
}