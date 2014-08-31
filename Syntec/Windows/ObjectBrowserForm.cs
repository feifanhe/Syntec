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

		public void SetTreeView( Control treeView )
		{
			if( treeView is TreeView ) {
				this.Controls.Clear();

				this.Controls.Add( treeView );
				treeView.Dock = DockStyle.Fill;
			}
		}


		#region Print test

		private int level = 0;

		private void PrintRecursive( TreeNode treeNode, int level )
		{
			// Print the node.
			for( int i = 0; i < level; i++ )
				System.Console.Write( "-" );

			System.Console.WriteLine( treeNode.Text );

			level++;
			// Print each node recursively.
			foreach( TreeNode tn in treeNode.Nodes ) {
				PrintRecursive( tn, level );
			}
		}

		// Call the procedure using the TreeView.
		private void CallRecursive( TreeView treeView )
		{
			// Print each node recursively.
			TreeNodeCollection nodes = treeView.Nodes;
			foreach( TreeNode n in nodes ) {
				//if( n.Text == "main" )
				PrintRecursive( n, level );
			}
		}

		#endregion


		private void Copy( TreeView treeview1, TreeView treeview2 )
		{
			TreeNode newTn;
			foreach( TreeNode tn in treeview1.Nodes ) {
				newTn = new TreeNode( tn.Text );
				newTn.Tag = tn.Tag;
				CopyChilds( newTn, tn );
				treeview2.Nodes.Add( newTn );
			}
		}

		private void CopyChilds( TreeNode parent, TreeNode willCopied )
		{
			TreeNode newTn;
			foreach( TreeNode tn in willCopied.Nodes ) {
				newTn = new TreeNode( tn.Text );
				newTn.Tag = tn.Tag;
				parent.Nodes.Add( newTn );
			}
		} 
	}
}