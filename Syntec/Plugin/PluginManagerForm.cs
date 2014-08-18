using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using PluginInterface;

namespace Syntec.Plugin
{
	public partial class PluginManagerForm : Form, IPluginHost
	{
		public PluginManagerForm( ) {
			InitializeComponent();
		}

		#region Form related

		private void PluginManagerForm_Load(object sender, EventArgs e) {
			MessageBox.Show(Global.Plugins.AvailablePlugins.Count.ToString() );

			ListViewItem LVI;
			foreach( AvailablePlugin pluginOn in Global.Plugins.AvailablePlugins )
			{
				LVI = new ListViewItem( pluginOn.Instance.Name );
				LVI.SubItems.Add(pluginOn.Instance.Version);
				LVI.SubItems.Add(pluginOn.AssemblyPath);

				PluginList.Items.Add( LVI );
			}
		}

		#endregion
	}
}