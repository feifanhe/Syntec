using System;
using System.Windows.Forms;

using WeifenLuo.WinFormsUI.Docking;
using Syntec;
using Microsoft.Win32;

using Syntec.Module;

namespace Syntec.Windows
{
	public partial class MainForm : Form
	{
		// General windows
		private WorkspaceExplorerForm WorkspaceExplorer = new WorkspaceExplorerForm();
		internal static PropertiesWindowForm PropertiesWindow = new PropertiesWindowForm();
		private ObjectBrowserForm ObjectBrowser = new ObjectBrowserForm();

		// Most recently used items variables
		private MruStripMenu RecentWorkspacesMenu;
		private MruStripMenu RecentFilesMenu;

		public MainForm()
		{
			InitializeComponent();

			// Bind events
			WorkspaceExplorer.OnShowObjects += new WorkspaceExplorerForm.ShowObjectsEventHandler( this.ShowObjects );

			// Load all the windows and set them to default locations
			PropertiesWindow.Show( Main_DockPanel, DockState.DockRight );
			ObjectBrowser.Show( PropertiesWindow.Pane, DockAlignment.Top, 0.6 );
			WorkspaceExplorer.Show( ObjectBrowser.Pane, ObjectBrowser );

			RecentWorkspacesMenu = new MruStripMenu(File_Recent_Workspaces_ToolStripMenuItem, new MruStripMenu.ClickedHandler(RecentWorkspaces_OnClick), "Syntec.ini", "RecentWorkspaces", 4);
			RecentWorkspacesMenu.LoadFromINIFile();
			RecentFilesMenu = new MruStripMenu( File_Recent_Files_ToolStripMenuItem, new MruStripMenu.ClickedHandler( RecentFiles_OnClick ), "Syntec.ini", "RecentFiles", 4 );
			RecentFilesMenu.LoadFromINIFile();
		}

		#region Form related

		private void MainForm_Load( object sender, EventArgs e )
		{
			// Initiate module manager
			ModuleManager.Refresh();
		}

		private void MainForm_FormClosing( object sender, FormClosingEventArgs e )
		{
			RecentWorkspacesMenu.SaveToINIFile();
			RecentFilesMenu.SaveToINIFile();
		}

		#endregion

		#region File

		private void New_Workspace_ToolStripMenuItem_Click( object sender, EventArgs e )
		{
			NewWorkspaceDialog dialog = new NewWorkspaceDialog();
			dialog.ShowDialog();

			if( dialog.DialogResult == DialogResult.OK ) {
				// TODO: new workspace
			}
		}

		private void New_File_ToolStripMenuItem_Click( object sender, EventArgs e )
		{
			NewFileDialog dialog = new NewFileDialog();
			dialog.ShowDialog();

			if( dialog.DialogResult == DialogResult.OK ) {
				// TODO: new file
			}
		}

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

		#region Helper methods

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

				RecentWorkspacesMenu.AddFile( dialog.SelectedPath );

				WorkspaceExplorer.ShowWorkspace( dialog.SelectedPath );
			}
			else {
				OpenFileDialog dialog = new OpenFileDialog();

				dialog.InitialDirectory = @"C:\";
				dialog.Filter = filter;
				dialog.RestoreDirectory = true;

				if( dialog.ShowDialog() != DialogResult.OK )
					return;

				RecentFilesMenu.AddFiles( dialog.FileNames );

				// Open all the selected files
				foreach( string fileName in dialog.FileNames )
					OpenFile( fileName );
			}

			WorkspaceExplorer.Show();
		}

		private void OpenFile( string filePath )
		{

		}

		public void ShowObjects( Control treeView )
		{
			ObjectBrowser.SetContents( treeView );
		}

		#endregion

		#region Recent Workspaces/Files

		private void RecentWorkspaces_OnClick( int index, string filename )
		{
			WorkspaceExplorer.ShowWorkspace( filename );
		}

		private void RecentFiles_OnClick( int index, string filename )
		{
			OpenFile( filename );
		}

		#endregion

		#region Test codes

		private void Test_Button_Click( object sender, EventArgs e )
		{
			DocumentsForm df;

			string path = @"C:\Users\Andy\Documents\Visual Studio 2005\Projects\Syntec\Syntec\bin\Debug\CncFenu.xml";
			df = new DocumentsForm(  path, new DocumentsForm.ShowObjectsEventHandler(ShowObjects));
			if( df.IsDisposed )
				return;
			df.Show( Main_DockPanel, DockState.Document );
			df.TabText = System.IO.Path.GetFileNameWithoutExtension( path );

			//Application.Restart();
		}

		#endregion

	}
}