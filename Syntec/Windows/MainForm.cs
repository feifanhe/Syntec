using System;
using System.Windows.Forms;

using WeifenLuo.WinFormsUI.Docking;

using Syntec.Module;

namespace Syntec.Windows
{
	public partial class MainForm : Form
	{
		DocumentsForm df, df2;

		// General windows
		internal static WorkspaceExplorerForm WorkspaceExplorer = new WorkspaceExplorerForm( null );
		internal static PropertiesWindowForm PropertiesWindow = new PropertiesWindowForm();
		internal static ObjectBrowserForm ObjectBrowser = new ObjectBrowserForm();

		public MainForm()
		{
			InitializeComponent();

			PropertiesWindow.Show( Main_DockPanel, DockState.DockRight );
			WorkspaceExplorer.Show( PropertiesWindow.Pane, DockAlignment.Top, 0.6 );
			ObjectBrowser.Show( Main_DockPanel, DockState.DockLeft );


			//df = new DocumentsForm();
			//df.Show( Main_DockPanel, DockState.Document );
			//df.TabText = "test1";
		}

		#region Form related

		private void MainForm_Load( object sender, EventArgs e )
		{
			// Initiate module manager
			ModuleManager.Refresh();
		}

		#endregion

		#region File

		private void Open_Workspace_ToolStripMenuItem_Click( object sender, EventArgs e )
		{
			OpenDialog( "Open Workspace", true );
		}

		private void Open_File_ToolStripMenuItem_Click( object sender, EventArgs e )
		{
			OpenDialog( "Open File", false, "XML Files (*.xml)|*.xml" );
		}

		private void File_Close_ToolStripMenuItem_Click( object sender, EventArgs e )
		{
			//Form df = this.ActiveMdiChild;
			//df.Dispose();
		}

		#endregion

		#region Tools

		private void Tools_ModuleManager_ToolStripMenuItem_Click( object sender, EventArgs e )
		{
			using( ModuleManagerForm PMF = new ModuleManagerForm() ) {
				PMF.ShowDialog();
			}
		}

		#endregion

		#region Methods

		private void OpenDialog( string title, bool dirMode )
		{
			OpenDialog( title, dirMode, "All Files|*.*" );
		}

		private void OpenDialog( string title, bool dirMode, string filter )
		{
			// Determine which type of dialog it is
			if( dirMode ) {
				FolderBrowserDialog dialog = new FolderBrowserDialog();

				dialog.Description = @"Workspace should located under ""Res"" folder.";
				dialog.ShowNewFolderButton = false;

				if( dialog.ShowDialog() != DialogResult.OK )
					return;

				WorkspaceExplorer.RefreshTree( dialog.SelectedPath );
			}
			else {
				OpenFileDialog dialog = new OpenFileDialog();

				dialog.InitialDirectory = @"C:\";
				dialog.Filter = filter;
				dialog.RestoreDirectory = true;

				if( dialog.ShowDialog() != DialogResult.OK )
					return;

				// CHECK IF FILE IS UNDER RES -> OPEN PROJECT, DOCUMENTS : DOCUMENTS 

				// PASS TO PROXY
			}
		}

		#endregion

		#region Test codes

		private void Test_Button_Click( object sender, EventArgs e )
		{
			string path = @"C:\Users\Andy\Documents\Visual Studio 2005\Projects\Syntec\Syntec\bin\Debug\CncFenu.xml";
			df2 = new DocumentsForm(  path);
			if( df2.IsDisposed )
				return;
			df2.Show( Main_DockPanel, DockState.Document );
			df2.TabText = System.IO.Path.GetFileNameWithoutExtension( path );
			df2.Name = df2.TabText;

			//Application.Restart();
		}

		#endregion
	}
}