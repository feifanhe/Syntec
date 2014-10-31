using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using WeifenLuo.WinFormsUI.Docking;
using ModuleInterface;
using System.Reflection;

namespace Syntec.Windows
{
	public partial class ObjectBrowserForm : DockContent
	{
		// Corresponding document tab name
		private string filePath = string.Empty;
		private TreeView ObjectTree;

		public ObjectBrowserForm()
		{
			InitializeComponent();
		}

		public void SetContents( Control treeView )
		{
			if( treeView == null ) {
				this.ObjectTree_Panel.Controls.Clear();
				return;
			}

			TreeView templateTreeView = treeView as TreeView;

			templateTreeView.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler( this.TreeView_NodeMouseDoubleClick );
			templateTreeView.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler( this.TreeView_BeforeExpand );
			templateTreeView.BeforeCollapse += new System.Windows.Forms.TreeViewCancelEventHandler( this.TreeView_BeforeCollapse );
			templateTreeView.MouseDown += new System.Windows.Forms.MouseEventHandler( this.TreeView_MouseDown );
			templateTreeView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler( this.TreeView_NodeMouseClick );

			this.ObjectTree_Panel.Controls.Clear();
			this.ObjectTree_Panel.Controls.Add( templateTreeView );
			this.ObjectTree = templateTreeView;
			this.filePath = templateTreeView.Name;
			this.Refresh_ToolStripButton.Enabled = true;
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
			if( ObjectTree != null && this.ObjectTree.SelectedNode != null ) {
				OpenDesigner( this.ObjectTree.SelectedNode.Name );
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