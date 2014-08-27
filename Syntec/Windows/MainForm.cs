using System;
using System.Windows.Forms;

using WeifenLuo.WinFormsUI.Docking;

using Syntec.Plugin;

namespace Syntec.Windows
{
	public partial class MainForm : Form
	{
		DocumentsForm df;

		// General windows
		internal static WorkspaceExplorerForm WorkspaceExplorer = new WorkspaceExplorerForm( null );
		internal static PropertiesWindowForm PropertiesWindow = new PropertiesWindowForm();

		public MainForm( ) {
			InitializeComponent();

			PropertiesWindow.Show( Main_DockPanel, DockState.DockRight );

			WorkspaceExplorer.Show( PropertiesWindow.Pane, DockAlignment.Top, 0.6 );

			df = new DocumentsForm();
			df.Show( Main_DockPanel, DockState.Document );
			df.TabText = "test";
		}

		#region Form related

		private void MainForm_Load(object sender, EventArgs e) {
			// Initiate the plugin collection, find plugins in the folder
			Global.Plugins.FindPlugins( Application.StartupPath + Global.PluginsFolderPath );
		}

		#endregion

		#region File

		private void Open_Workspace_ToolStripMenuItem_Click(object sender, EventArgs e) {
			OpenDialog( "Open Workspace", true );
		}

		private void Open_File_ToolStripMenuItem_Click(object sender, EventArgs e) {
			OpenDialog( "Open File", false, "XML Files (*.xml)|*.xml" );
		}

		#endregion

		#region Tools

		private void Tools_ModuleManager_ToolStripMenuItem_Click(object sender, EventArgs e) {
			using( ModuleManagerForm PMF = new ModuleManagerForm() )
			{
				PMF.ShowDialog();
			}
		}

		#endregion

		#region Executions

		private void OpenDialog(string title, bool dirMode) {
			OpenDialog( title, dirMode, null );
		}

		private void OpenDialog(string title, bool dirMode, string filter) {
			// Determine which type of dialog it is
			if( dirMode )
			{
				FolderBrowserDialog dialog = new FolderBrowserDialog();

				dialog.Description = @"Workspace should located under ""Res"" folder.";
				dialog.ShowNewFolderButton = false;

				if( dialog.ShowDialog() != DialogResult.OK )
					return;

				WorkspaceExplorer.RefreshTree( dialog.SelectedPath );
			}
			else
			{
				OpenFileDialog dialog = new OpenFileDialog();

				dialog.InitialDirectory = @"C:\";
				dialog.Filter = filter;
				dialog.RestoreDirectory = true;

				if( dialog.ShowDialog() != DialogResult.OK )
					return;

				// PASS TO PROXY
			}
		}

		#endregion

		#region Test codes

		private void Test_MenuItem_Click(object sender, EventArgs e) {
			AvailablePlugin SelectedPlugin = Global.Plugins.AvailablePlugins.Find( "Fenubar" );

			if( SelectedPlugin != null )
			{
				if( SelectedPlugin.Instance.Initialize( "output.xml" ) )
				{
					SelectedPlugin.Instance.Load( "main" );
				}
			}
		}

		#endregion
	}
}