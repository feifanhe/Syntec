using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using System.IO;

namespace Syntec.Windows
{
	public partial class WorkspaceExplorerForm : DockContent
	{
		// Base path that the entire tree will be built on
		private string basePath;

		// Indicate to show every files or targeted only
		private bool showAllFiles = false;

		#region Events

		public delegate void ShowObjectsEventHandler( Control treeView );
		public event ShowObjectsEventHandler ShowOnObjectsBrowser;

		#endregion

		public WorkspaceExplorerForm()
		{
			InitializeComponent();

			// Set checked state for ShowAllFile_ToolStripMenuItem
			ShowAll_ToolStripButton.Checked = showAllFiles;

			Reset();
		}

		public void RefreshTree()
		{
			// Wipe tree
			Workspace_TreeView.Nodes.Clear();

			ParseDirectoryToTree();
		}

		public void ShowWorkspace( string path )
		{
			// Set explorer to default view
			if( path == null ) {
				Reset();
				return;
			}

			foreach( ToolStripItem TSMI in Workspace_ToolStrip.Items )
				TSMI.Enabled = true;

			// Dissect and analyze whether it's a legal workspace or not
			if( DissectBasePath( path ) )
				RefreshTree();
		}

		private void Reset()
		{
			basePath = string.Empty;

			foreach( ToolStripItem TSMI in Workspace_ToolStrip.Items )
				TSMI.Enabled = false;
		}

		private bool DissectBasePath( string path )
		{
			// Reset base path
			basePath = string.Empty;

			int index = path.ToUpper().LastIndexOf( "RES" );
			if( index < 0 ) {
				// This section should never occur
				MessageBox.Show( "Designated path isn't located in Res.",
									"Wrong File Path",
									MessageBoxButtons.OK,
									MessageBoxIcon.Error );
				return false;
			}

			basePath = path.Substring( 0, index ) + @"Res\";
			return true;
		}

		private void ParseDirectoryToTree()
		{
			TreeNode root = new TreeNode( basePath );
			root.ImageIndex = 5;
			root.SelectedImageIndex = root.ImageIndex;

			Workspace_TreeView.Nodes.Add( root );
			AddTopDirectories( root, basePath );
		}

		private void AddTopDirectories( TreeNode node, string path )
		{
			node.TreeView.BeginUpdate(); // for best performance
			// Clear dummy node if exists
			node.Nodes.Clear();

			try {
				#region Dump directories

				string[] subdirs = Directory.GetDirectories( path );

				foreach( string subdir in subdirs ) {
					TreeNode child = new TreeNode( subdir );
					// Save directory info into tag
					child.Tag = subdir;
					child.Text = Path.GetFileName( subdir );

					// Set product/normal folder image
					if( child.Text.IndexOf( '_' ) == 0 ) {
						child.ImageIndex = 0;
						child.Text = child.Text.Substring( 1 );
					}
					else
						child.ImageIndex = 1;

					child.SelectedImageIndex = child.ImageIndex;

					// Add dummy node if targeted file exists
					bool existTargetedFile = false;
					foreach( string file in Directory.GetFiles( subdir ) ) {
						if( file.ToUpper().Contains( ".XML" ) || showAllFiles ) {
							existTargetedFile = true;
							break;
						}
					}

					// Add dummy node when sub-dir exists, in order to show the expand sign
					if( Directory.GetDirectories( subdir ).Length > 0 || existTargetedFile ) {
						child.Nodes.Add( new TreeNode() );
					}
					node.Nodes.Add( child );
				}

				#endregion

				#region Dump files

				string[] files = Directory.GetFiles( path );

				foreach( string file in files ) {
					TreeNode child = new TreeNode( file );
					// Save directory info into tag
					child.Tag = file;
					child.Text = Path.GetFileName( file );

					// Set product/normal folder image
					switch( Path.GetExtension( file ).ToUpper() ) {
						case ".XML":
							child.ImageIndex = 2;
							break;
						default:
							if( showAllFiles )
								child.ImageIndex = 4;
							else
								continue; // Skip this iteration to hide non-targeted files
							break;
					}

					child.SelectedImageIndex = child.ImageIndex;

					node.Nodes.Add( child );
				}

				#endregion
			}
			catch( UnauthorizedAccessException ) // Ignore that directory if limited
			{
			}
			finally {
				// Restore paint state
				node.TreeView.EndUpdate();

				// Clear dummy tag
				node.Tag = null;
			}
		}

		#region Tree view events

		// Parsing the directory before expand
		private void WorkspaceTreeView_BeforeExpand( object sender, TreeViewCancelEventArgs e )
		{
			if( e.Node.Tag != null )
				AddTopDirectories( e.Node, (string)e.Node.Tag );

			// Change expanded icon
			if( e.Node.ImageIndex == 1 )
				e.Node.ImageIndex = 3;
			e.Node.SelectedImageIndex = e.Node.ImageIndex;
		}

		private void WorkspaceTreeView_BeforeCollapse( object sender, TreeViewCancelEventArgs e )
		{
			// Switch back icon to folder
			if( e.Node.ImageIndex == 3 )
				e.Node.ImageIndex = 1;
			e.Node.SelectedImageIndex = e.Node.ImageIndex;
		}

		private void WorkspaceTreeView_NodeMouseDoubleClick( object sender, TreeNodeMouseClickEventArgs e )
		{
			string path = e.Node.Tag as string;
			DocumentsForm openFromWorkspace = new DocumentsForm( path );
			if( openFromWorkspace.IsDisposed )
				return;			

			openFromWorkspace.ShowOnObjectsBrowser += new DocumentsForm.ShowObjectsEventHandler( this.ShowOnObjectsBrowser );
			
			openFromWorkspace.Show( MainForm.Main_DockPanel, DockState.Document );
			openFromWorkspace.TabText = Path.GetFileNameWithoutExtension( path );

			// Switch to Object Browser tab
			//MainForm.ObjectBrowser.Show();
		}

		#endregion

		#region Tool strip events

		private void ShowAll_ToolStripButton_Click( object sender, EventArgs e )
		{
			// Toggle and apply state
			showAllFiles = !showAllFiles;
			ShowAll_ToolStripButton.Checked = showAllFiles;

			RefreshTree();
		}

		private void Refresh_ToolStripButton_Click( object sender, EventArgs e )
		{
			RefreshTree();
		}

		#endregion

		
	}
}