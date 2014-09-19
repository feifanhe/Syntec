using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;

namespace Syntec.Windows
{
	public partial class StringViewerForm : WeifenLuo.WinFormsUI.Docking.DockContent
	{
		private string BasePath = string.Empty;
		private bool showAllFiles = false;

		public StringViewerForm()
		{
			InitializeComponent();
			Reset();
		}

		private void Reset()
		{
			this.BasePath = string.Empty;

			foreach( ToolStripItem TSMI in this.StringViewer_ToolStrip.Items )
				TSMI.Enabled = false;
		}

		public void ShowString( string path )
		{
			// Set vierwer to default view
			if( path == null || !Directory.Exists( path ) ) {
				Reset();
				return;
			}

			foreach( ToolStripItem TSMI in this.StringViewer_ToolStrip.Items )
				TSMI.Enabled = true;

			this.BasePath = path;
			RefreshTree();
		}

		public void RefreshTree()
		{
			MessageBox.Show( "RefreshTree");
			// Wipe tree
			String_TreeView.Nodes.Clear();

			ParseDirectoryToTree();
		}

		private void ParseDirectoryToTree()
		{
			TreeNode root = new TreeNode( BasePath );
			root.ImageIndex = 5;
			root.SelectedImageIndex = root.ImageIndex;

			String_TreeView.Nodes.Add( root );
			AddTopDirectories( root, BasePath );
		}

		private void AddTopDirectories( TreeNode node, string path )
		{
			node.TreeView.BeginUpdate(); // for best performance
			// Clear dummy node if exists
			node.Nodes.Clear();

			try {
				TreeNode String = new TreeNode( "String" );

				string[] subdirs = Directory.GetDirectories( path );

				foreach( string subdir in subdirs ) {
					string dirname = Path.GetFileName( subdir );
					// Set product/string folder image
					if( dirname.IndexOf( '_' ) == 0 ) {
						TreeNode child = new TreeNode( dirname.Substring( 1 ) );
						child.Tag = subdir;
						child.ImageIndex = 0;
						child.SelectedImageIndex = child.ImageIndex;
						node.Nodes.Add( child );
						AddTopDirectories( child, subdir );
					}
					else if( IsLanguageFolder( subdir ) ) {
						string[] files = Directory.GetFiles( subdir + @"\string" );

						foreach( string file in files ) {

							if( Path.GetExtension( file ).ToUpper() == ".XML" ) {
								AddStrings( String, file, Path.GetFileName(subdir).ToUpper() );
							}

							String.ImageIndex = 0;
							String.SelectedImageIndex = String.ImageIndex;

							node.Nodes.Add( String );
						}
					}
				}
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

		private void AddString(TreeNode String, string filename, string language )
		{

		}

		private bool IsLanguageFolder( string path )
		{
			return false;
		}

	}
}

