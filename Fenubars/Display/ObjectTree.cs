using System.Windows.Forms;
using System.ComponentModel;
using Fenubars.XML;
using System.Collections.Generic;
using System;

namespace Fenubars.Display
{
	[ToolboxItem( false )]
	public partial class ObjectTree : TreeView
	{
		private readonly string CUSTOM_FENU_HEADER = "CUSTOMFENU_";

		// Local container for overall fenu states
		private List<FenuState> fenusContainer;

		public ObjectTree( List<FenuState> fenusContainer )
		{
			InitializeComponent();

			this.fenusContainer = fenusContainer;

			RefreshTree();
		}

		#region Build tree

		public void RefreshTree()
		{
			// Wipe tree
			this.Nodes.Clear();

			// ONLY MAIN FENU
			ParseFenuToTree();
		}

		private void ParseFenuToTree()
		{
			TreeNode root = new TreeNode( "main" );

			this.Nodes.Add( root );
			AddTopFenus( root, fenusContainer.Find( delegate( FenuState testFenu )
														{
															return testFenu.Name == "main";
														} ) );
		}

		private void AddTopFenus( TreeNode parentNode, FenuState parentFenu )
		{
			parentNode.TreeView.BeginUpdate(); // for best performance
			// Clear dummy node if exists
			parentNode.Nodes.Clear();

			try {

				List<FenuState> subFenus = GetLinkedFenus( parentFenu );

				foreach( FenuState subFenu in subFenus ) {
					TreeNode child = new TreeNode( subFenu.Name );
					// Save fenu info into tag
					child.Tag = subFenu;
					child.Text = subFenu.Name;

					// Add dummy node if targeted file exists
					bool existTargetedFile = false;

					// Add dummy node when sub-dir exists, in order to show the expand sign
					if( HasLinkedFenus( subFenu ) ) {
						child.Nodes.Add( new TreeNode() );
					}
					parentNode.Nodes.Add( child );
				}
			}
			catch( UnauthorizedAccessException ) // Ignore that directory if limited
			{
			}
			finally {
				// Restore paint state
				parentNode.TreeView.EndUpdate();
				// Clear dummy tag
				parentNode.Tag = null;
			}
		}

		private List<FenuState> GetLinkedFenus( FenuState parentFenu )
		{
		}

		private bool HasLinkedFenus( FenuState fenu )
		{
		}

		#region Tree view events

		private void ObjectTree_BeforeExpand( object sender, TreeViewCancelEventArgs e )
		{
			if( e.Node.Tag != null )
				AddTopFenus( e.Node.Text, e.Node.Tag as FenuState );
		}

		#endregion

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

		#endregion
	}

	internal class Node
	{
		private string _Name;
		public string Name
		{
			get
			{
				return _Name;
			}
			set
			{
				_Name = value;
			}
		}

		private List<string> _ChildName;
		public List<string> ChildName
		{
			get
			{
				return _ChildName;
			}
			set
			{
				_ChildName = value;
			}
		}
	}
}
