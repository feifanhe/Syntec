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
	public partial class WorkspaceExplorer : DockContent
	{
		// Base path that the entire tree will be built on
		private string basePath;

		public WorkspaceExplorer(string path) {
			InitializeComponent();

			RefreshTree( path );
		}

		public void RefreshTree( ) {
			RefreshTree( basePath );
		}

		public void RefreshTree(string path) {
			DissectBasePath( path );

			ParseDirectoryToTree();
		}

		private void DissectBasePath(string path) {
			// Reset base path
			basePath = string.Empty;

			int index = path.ToUpper().LastIndexOf( "RES" );
			if( index < 0 )
			{
				// This section should never occur
				MessageBox.Show( "Designated path isn't located in Res.",
									"Wrong File Path",
									MessageBoxButtons.OK,
									MessageBoxIcon.Error );
				return;
			}

			basePath = path.Substring( 0, index ) + @"Res\";
		}

		private void ParseDirectoryToTree( ) {
			TreeNode root = new TreeNode( basePath );
			WorkspaceTreeView.Nodes.Add( root );
			AddTopDirectories( root, basePath );
		}

		#region Tree view events

		// Parsing the directory before expand
		private void WorkspaceTreeView_BeforeExpand(object sender, TreeViewCancelEventArgs e) {
			if( e.Node.Tag != null )
				AddTopDirectories( e.Node, (string)e.Node.Tag );

			// Change expanded icon
			if( e.Node.ImageIndex == 1 )
				e.Node.ImageIndex = 3;
		}

		private void WorkspaceTreeView_BeforeCollapse(object sender, TreeViewCancelEventArgs e) {
			// Switch back icon to folder
			if( e.Node.ImageIndex == 3 )
				e.Node.ImageIndex = 1;
		}

		#endregion

		private void AddTopDirectories(TreeNode node, string path) {
			node.TreeView.BeginUpdate(); // for best performance
			// Clear dummy node if exists
			node.Nodes.Clear();

			try
			{
				#region Dump directories

				string[] subdirs = Directory.GetDirectories( path );

				foreach( string subdir in subdirs )
				{
					TreeNode child = new TreeNode( subdir );
					// Save directory info into tag
					child.Tag = subdir;
					child.Text = Path.GetFileName( subdir );

					// Set product/normal folder image
					if( child.Text.IndexOf( '_' ) == 0 )
					{
						child.ImageIndex = 0;
						child.Text = child.Text.Substring( 1 );
					}
					else
						child.ImageIndex = 1;

					child.SelectedImageIndex = child.ImageIndex;

					// Add dummy node when sub-dir exists, in order to show the expand sign
					if( Directory.GetDirectories( subdir ).Length > 0 ||
						Directory.GetFiles( subdir ).Length > 0 )
					{
						child.Nodes.Add( new TreeNode() );
					}
					node.Nodes.Add( child );
				}

				#endregion

				#region Dump files

				string[] files = Directory.GetFiles( path );

				foreach( string file in files )
				{
					TreeNode child = new TreeNode( file );
					// Save directory info into tag
					child.Tag = file;
					child.Text = Path.GetFileName( file );

					// Set product/normal folder image
					if( child.Text.ToUpper().IndexOf( "XML" ) < 0 )
						continue; // Skip this itereation if it's not an XML file
					else
						child.ImageIndex = 2;

					child.SelectedImageIndex = child.ImageIndex;

					node.Nodes.Add( child );
				}

				#endregion
			}
			catch( UnauthorizedAccessException ) // Ignore that directory if limited
			{
			}
			finally
			{
				// Restore paint state
				node.TreeView.EndUpdate();
				// Clear dummy tag
				node.Tag = null;
			}
		}

		#region Tool strip events

		private void Refresh_ToolStripButton_Click(object sender, EventArgs e) {
			Refresh();
		}

		#endregion
	}
}