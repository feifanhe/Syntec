using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using WeifenLuo.WinFormsUI.Docking;
using System.Reflection;

namespace Syntec.Windows
{
	public partial class ObjectBrowserForm : DockContent
	{
		// Corresponding document tab name
		private string filePath = string.Empty;

		public ObjectBrowserForm()
		{
			InitializeComponent();
		}

		public void SetContents( Control treeView )
		{
			this.SuspendLayout();

			if( treeView == null ) {
				Object_TreeView.Nodes.Clear();
			}
			else {
				// Remove the tree view
				this.Object_TreeView.Nodes.Clear();

				// Copy tree nodes
				TreeView templateTreeView = treeView as TreeView;
				TreeNode[] treeNodes = new TreeNode[ templateTreeView.Nodes.Count ];
				templateTreeView.Nodes.CopyTo( treeNodes, 0 );
				Object_TreeView.Nodes.AddRange( treeNodes );

				// Copy image list
				Object_TreeView.ImageList = templateTreeView.ImageList;

				// Acquire target tab name
				filePath = templateTreeView.Name;

				//this.Refresh_ToolStripButton.Enabled = true;
			}

			this.ResumeLayout();
		}

		#region Tree view event

		private void TreeView_NodeMouseDoubleClick( object sender, TreeNodeMouseClickEventArgs e )
		{
			OpenDesigner( e.Node.Name );
		}

		private void TreeView_NodeMouseClick( object sender, TreeNodeMouseClickEventArgs e )
		{
			this.ViewDesigner_ToolStripButton.Enabled = true;
		}

		#region Disable double click expand/collapse

		private bool preventExpandCollapse = false;
		private DateTime lastMouseDownTime = DateTime.Now;

		private void TreeView_BeforeExpand( object sender, TreeViewCancelEventArgs e )
		{
			e.Cancel = preventExpandCollapse;
			preventExpandCollapse = false;
		}

		private void TreeView_BeforeCollapse( object sender, TreeViewCancelEventArgs e )
		{
			e.Cancel = preventExpandCollapse;
			preventExpandCollapse = false;
		}

		private void TreeView_MouseDown( object sender, MouseEventArgs e )
		{
			int delta = (int)DateTime.Now.Subtract( lastMouseDownTime ).TotalMilliseconds;
			preventExpandCollapse = ( delta < SystemInformation.DoubleClickTime );
			lastMouseDownTime = DateTime.Now;
		}

		#endregion

		#endregion

		#region Tool strip events

		private void Refresh_ToolStripButton_Click( object sender, EventArgs e )
		{
			foreach( Form form in Application.OpenForms ) {
				DocumentsForm holder = form as DocumentsForm;

				// TODO: SET NAME
				if( ( holder != null ) && ( holder.ToolTipText == filePath ) ) {
					holder.RefreshObject();
				}
			}
		}

		private void ViewCode_ToolStripButton_Click( object sender, EventArgs e )
		{

		}

		private void ViewDesigner_ToolStripButton_Click( object sender, EventArgs e )
		{
			OpenDesigner( Object_TreeView.SelectedNode.Name );
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

		private void OpenDesigner( string name )
		{
			foreach( Form form in Application.OpenForms ) {
				DocumentsForm holder = form as DocumentsForm;

				// TODO: SET NAME
				if( ( holder != null ) && ( holder.ToolTipText == filePath ) ) {
					holder.Open( name );
					break;
				}
			}
		}

		private void OpenStructure( string path )
		{
		}

		#endregion
	}
}