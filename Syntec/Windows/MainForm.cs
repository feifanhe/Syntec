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
		DocumentsForm df;

		// General windows
		internal static WorkspaceExplorerForm WorkspaceExplorer = new WorkspaceExplorerForm( null );
		internal static PropertiesWindowForm PropertiesWindow = new PropertiesWindowForm();
		internal static ObjectBrowserForm ObjectBrowser = new ObjectBrowserForm();

		private const string REGISTRY_KEY = "SOFTWARE\\SYNTEC\\Syntec";
		private MruStripMenu RecentWorkspacesMenu;
		private MruStripMenu RecentFilesMenu;

		public MainForm()
		{
			InitializeComponent();

			PropertiesWindow.Show( Main_DockPanel, DockState.DockRight );
			WorkspaceExplorer.Show( PropertiesWindow.Pane, DockAlignment.Top, 0.6 );
			ObjectBrowser.Show( Main_DockPanel, DockState.DockLeft );


			RecentWorkspacesMenu = new MruStripMenu(File_Recent_Workspaces_ToolStripMenuItem, new MruStripMenu.ClickedHandler(RecentWorkspaces_OnClick), "Syntec.ini", "RecentWorkspaces", 4);
			RecentWorkspacesMenu.LoadFromINIFile();


			RecentFilesMenu = new MruStripMenu( File_Recent_Files_ToolStripMenuItem, new MruStripMenu.ClickedHandler( RecentFiles_OnClick ), "Syntec.ini", "RecentFiles", 4 );
			RecentFilesMenu.LoadFromINIFile();

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

		private void MainForm_FormClosing( object sender, FormClosingEventArgs e )
		{
			RecentWorkspacesMenu.SaveToINIFile();
			RecentFilesMenu.SaveToINIFile();
		}

		#endregion

		#region File

		private void New_Workspace_ToolStripMenuItem_Click( object sender, EventArgs e )
		{
			new NewItemDialog().ShowDialog( this );
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

				RecentWorkspacesMenu.AddFile( dialog.SelectedPath );
				WorkspaceExplorer.RefreshTree( dialog.SelectedPath );
			}
			else {
				OpenFileDialog dialog = new OpenFileDialog();

				dialog.InitialDirectory = @"C:\";
				dialog.Filter = filter;
				dialog.RestoreDirectory = true;

				if( dialog.ShowDialog() != DialogResult.OK )
					return;

				RecentFilesMenu.AddFiles( dialog.FileNames );
				// CHECK IF FILE IS UNDER RES -> OPEN PROJECT, DOCUMENTS : DOCUMENTS 
				// PASS TO PROXY
			}
		}

		#endregion

		#region Test codes

		private void Test_Button_Click( object sender, EventArgs e )
		{
			string path = @"C:\Users\Andy\Documents\Visual Studio 2005\Projects\Syntec\Syntec\bin\Debug\CncFenu.xml";
			df = new DocumentsForm(  path);
			if( df.IsDisposed )
				return;
			df.Show( Main_DockPanel, DockState.Document );
			df.TabText = System.IO.Path.GetFileNameWithoutExtension( path );

			//Application.Restart();
		}

		#endregion

		#region Recent Workspaces/Files

		private void RecentWorkspaces_OnClick( int index, string filename )
		{
			WorkspaceExplorer.RefreshTree( filename );
		}

		private void RecentFiles_OnClick( int index, string filename )
		{
			// TODO: Open File
		}

		#endregion

	}
}