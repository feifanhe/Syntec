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
		private List<string> awaitingFenus = new List<string>();

		public ObjectTree( List<FenuState> fenusContainer )
		{
			InitializeComponent();

			this.fenusContainer = fenusContainer;

			RefreshTree();

			//CallRecursive( this );
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
			root.Tag = fenusContainer.Find( delegate( FenuState testFenu )
														{
															return testFenu.Name == "main";
														} );
			root.Name = root.Text;

			this.Nodes.Add( root );
			AddTopFenus( root, root.Tag as FenuState );
		}

		private void AddTopFenus( TreeNode parentNode, FenuState parentFenu )
		{
			parentNode.TreeView.BeginUpdate(); // for best performance
			// Clear dummy node if exists
			parentNode.Nodes.Clear();

			try {

				List<FenuState> subFenus = GetLinkedFenus( parentFenu );

				foreach( FenuState subFenu in subFenus ) {
					// Check if this fenu is linked previously
					if( IsLinked( subFenu ) )
						continue;

					TreeNode child = new TreeNode( subFenu.Name );
					// Save fenu info into tag
					child.Tag = subFenu;
					child.Name = child.Text;

					// Add dummy node when sub-fenu exists, in order to show the expand sign
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
			List<FenuState> acquiredFenus = new List<FenuState>();

			// Escape buttons
			acquiredFenus.AddRange( ParseFenuFromButton( parentFenu.EscapeButton ) );

			// Normal buttons
			foreach( FenuButtonState FBS in parentFenu.NormalButtonList )
				acquiredFenus.AddRange( ParseFenuFromButton( FBS ) );

			// Next button
			acquiredFenus.AddRange( ParseFenuFromButton( parentFenu.NextButton ) );

			return acquiredFenus;
		}

		private FenuState[] ParseFenuFromButton( FenuButtonState button )
		{
			List<FenuState> acquiredFenus = new List<FenuState>();

			// Read from <link>
			string linkToTest = button.Link;
			if( linkToTest != null ) {
				AddFenuByName( ref acquiredFenus, linkToTest );
			}

			// Read from <action>
			linkToTest = button.Actions.Action;
			if( linkToTest != null && linkToTest.IndexOf( CUSTOM_FENU_HEADER ) == 0 )
				AddFenuByName( ref acquiredFenus, linkToTest.Substring( CUSTOM_FENU_HEADER.Length ) );


			// Read from <actions>
			foreach( string action in button.Actions.Actions ) {
				if( action == null )
					continue;
				linkToTest = action;
				if( linkToTest != null && linkToTest.IndexOf( CUSTOM_FENU_HEADER ) == 0 )
					AddFenuByName( ref acquiredFenus, linkToTest.Substring( CUSTOM_FENU_HEADER.Length ) );
			}

			return acquiredFenus.ToArray();
		}

		private void AddFenuByName( ref List<FenuState> fenuList, string name )
		{
			FenuState foundedFenu = fenusContainer.Find( delegate( FenuState selectedFenu )
															{
																return selectedFenu.Name == name;
															} );
			if( foundedFenu != null )
				fenuList.Add( foundedFenu );
		}

		private bool HasLinkedFenus( FenuState fenu )
		{
			return GetLinkedFenus( fenu ).Count > 0;
		}

		private bool IsLinked( FenuState fenu )
		{
			return this.Nodes.Find( fenu.Name, true ).Length > 0;
		}

		#region Tree view events

		private void ObjectTree_BeforeExpand( object sender, TreeViewCancelEventArgs e )
		{
			if( e.Node.Tag != null )
				AddTopFenus( e.Node, e.Node.Tag as FenuState );
		}

		private void ObjectTree_NodeMouseDoubleClick( object sender, TreeNodeMouseClickEventArgs e )
		{

		}

		#endregion

		#endregion
	}
}
