using System;
using WeifenLuo.WinFormsUI.Docking;

using Syntec.Windows;
using System.Windows.Forms;
using Syntec.Plugin;

namespace Syntec
{
	public partial class MainForm : Form
	{
		DocumentsForm df;
		public MainForm( ) {
			InitializeComponent();

			PropertiesWindowForm pwf = new PropertiesWindowForm();
			pwf.Show( DockPanel, DockState.DockRightAutoHide );

			df = new DocumentsForm();
			df.Show( DockPanel, DockState.Document );
		}

		#region Form related

		private void MainForm_Load(object sender, EventArgs e) {
			// Find plugins in the folder
			Global.Plugins.FindPlugins( Application.StartupPath + "\\Plugins" );
		}

		#endregion

		#region Tools

		private void PluginManager_MenuItem_Click(object sender, EventArgs e) {
			using( PluginManagerForm PMF = new PluginManagerForm() )
			{
				PMF.ShowDialog();
			}
		}

		#endregion

	}
}