using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using WeifenLuo.WinFormsUI.Docking;

namespace Syntec.Windows
{
	public partial class ObjectBrowserForm : DockContent
	{
		public ObjectBrowserForm()
		{
			InitializeComponent();
		}

		public void SetContents( Control treeView )
		{
			this.SuspendLayout();

			if( treeView == null ) {
				// Wipe the existing tree view only
				foreach( Control item in this.Controls) {
					TreeView treeViewItem = item as TreeView;
					if( treeViewItem != null )
						treeViewItem.Nodes.Clear();
				}

			}
			else if( treeView is TreeView ) {
				// Remove the tree view
				foreach( Control item in this.Controls ) {
					if( item is TreeView )
						this.Controls.Remove( item );
				}

				// Add the assigned tree view
				// Remove tool strip first to maintain visibility of tree view
				treeView.Dock = DockStyle.Fill;
				( treeView as TreeView ).NodeMouseDoubleClick += new TreeNodeMouseClickEventHandler( treeView_NodeMouseDoubleClick );
				( treeView as TreeView ).NodeMouseClick += new TreeNodeMouseClickEventHandler( treeView_NodeMouseClick );

				this.Controls.Remove( ObjectBrowser_ToolStrip );
				this.Controls.Add( treeView );
				this.Controls.Add( ObjectBrowser_ToolStrip );

				this.Refresh_ToolStripButton.Enabled = true;
			}

			this.ResumeLayout();
		}

		#region Tree view event

		private void treeView_NodeMouseDoubleClick( object sender, TreeNodeMouseClickEventArgs e )
		{
			OpenDesigner(e.Node.Name);
		}

		private void treeView_NodeMouseClick( object sender, TreeNodeMouseClickEventArgs e )
		{
			foreach( ToolStripItem TSMI in ObjectBrowser_ToolStrip.Items )
				TSMI.Enabled = true;
		}

		#endregion

		#region Tool strip events

		private void Refresh_ToolStripButton_Click( object sender, EventArgs e )
		{

		}

		private void ViewCode_ToolStripButton_Click( object sender, EventArgs e )
		{

		}

		private void ViewDesigner_ToolStripButton_Click( object sender, EventArgs e )
		{
			string name = string.Empty;
			foreach( Control item in this.Controls ) {
				if( item is TreeView )
					name = ( item as TreeView ).SelectedNode.Name;
				OpenDesigner( name );
			}
		}

		private void ViewStructure_ToolStripButton_Click( object sender, EventArgs e )
		{

		}

		#endregion

		// All the operations ends up here, modify these methods when something changed else where
		#region Executions

		private void OpenCode( string path )
		{
		}

		private void OpenDesigner(string name)
		{
			string treeViewName = string.Empty;
			foreach( Control item in this.Controls ) {
				if( item is TreeView )
					treeViewName = item.Name;
			}

			foreach( Form form in Application.OpenForms ) {
				if( form is DocumentsForm ) {
					if( ( form as DocumentsForm ).TabText == treeViewName ) {
						( form as DocumentsForm ).Open( name );
						break;
					}
				}
			}
		}

		private void OpenStructure( string path )
		{
		}

		#endregion
	}
}