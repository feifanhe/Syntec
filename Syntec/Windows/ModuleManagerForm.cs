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
		public ModuleManagerForm( ) {
			InitializeComponent();
		}

		#region Form related

		private void PluginManagerForm_Load(object sender, EventArgs e) {
			RefreshPluginList();
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
				LVI.SubItems.Add( "?");
				LVI.SubItems.Add( module.Assembly.Location );

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

		}

		private void CancelButton_Click(object sender, EventArgs e) {
			this.Close();
		}

		#endregion
	}
}