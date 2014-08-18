using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using PluginInterface;
using System.Diagnostics;

namespace Syntec.Plugin
{
	public partial class PluginManagerForm : Form, IPluginHost
	{
		public PluginManagerForm( ) {
			InitializeComponent();
		}

		#region Form related

		private void PluginManagerForm_Load(object sender, EventArgs e) {
			RefreshPluginList();
		}

		#endregion

		#region Methods

		private void RefreshPluginList( ) {
			Global.Plugins.FindPlugins( Application.StartupPath + Global.PluginsFolderPath );

			PluginList.Items.Clear();

			ListViewItem LVI;
			// Populate available plugins to plugin list
			foreach( AvailablePlugin pluginOn in Global.Plugins.AvailablePlugins )
			{
				LVI = new ListViewItem( pluginOn.Instance.Name );
				LVI.SubItems.Add( pluginOn.Instance.Version );
				LVI.SubItems.Add( pluginOn.AssemblyPath );

				PluginList.Items.Add( LVI );
			}
		}

		#endregion

		#region Button actions

		private void BrowseButton_Click(object sender, EventArgs e) {
			Process.Start( Application.StartupPath + Global.PluginsFolderPath );
		}

		private void RefreshButton_Click(object sender, EventArgs e) {
			RefreshPluginList();
		}

		private void OKButton_Click(object sender, EventArgs e) {

		}

		private void CancelButton_Click(object sender, EventArgs e) {

		}

		#endregion
	}
}