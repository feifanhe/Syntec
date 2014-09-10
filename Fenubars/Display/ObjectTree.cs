using System;
using System.Collections.Generic;
using Fenubars.XML;
using System.Windows.Forms;

namespace Fenubars.Display
{
	public partial class ObjectTree : TreeView
	{
		private readonly string CUSTOM_FENU_HEADER = "CUSTOMFENU_";

		private List<FenuLink> links = new List<FenuLink>();

		public ObjectTree( string fileName, List<FenuState> fenus )
		{
			InitializeComponent();

			CompileLinksInfo( fenus );

			// Save file name
			this.Name = fileName;
			this.ImageList = this.ObjectType_ImageList;

			// First time execution, fully reconstruct the tree
			//FullyReconstructTree();
			ConstructForest();
		}

		#region Build Links

		private void CompileLinksInfo( List<FenuState> fenus )
		{
			foreach( FenuState fenu in fenus ) {
				FenuLink newLink = new FenuLink( fenu.Name );
				CompileChildLinks( newLink, fenu );
				links.Add( newLink );
			}
		}

		private void CompileChildLinks( FenuLink parent, FenuState fenu )
		{
			List<string> links = new List<string>();

			//// Add links from Escape Button
			//links.AddRange( ParseLinksFromButton( fenu.EscapeButton ) );
			// ^ Causing stack overflow

			// Add links from Normal Buttons
			foreach( FenuButtonState parsedNormalButton in fenu.NormalButtonList )
				links.AddRange( ParseLinksFromButton( parsedNormalButton ) );

			// Add links from Next Button
			links.AddRange( ParseLinksFromButton( fenu.NextButton ) );

			// Add to fenu link object
			parent.Links = links;
		}

		private string[] ParseLinksFromButton( FenuButtonState button )
		{
			List<string> acquiredLinks = new List<string>();

			// Read from <link>
			if( button.Link != null )
				acquiredLinks.Add( button.Link );

			// Read from <action>
			string linkToTest = button.Actions.Action;
			if( linkToTest != null && linkToTest.IndexOf( CUSTOM_FENU_HEADER ) == 0 )
				acquiredLinks.Add( linkToTest.Substring( CUSTOM_FENU_HEADER.Length ) );


			// Read from <actions>
			foreach( string action in button.Actions.Actions ) {
				if( action == null )
					continue;
				linkToTest = action;
				if( linkToTest != null && linkToTest.IndexOf( CUSTOM_FENU_HEADER ) == 0 )
					acquiredLinks.Add( linkToTest.Substring( CUSTOM_FENU_HEADER.Length ) );
			}

			return acquiredLinks.ToArray();
		}

		#endregion

		#region Build Forest

		private void ConstructForest()
		{
			foreach( FenuLink Leaf in links ) {
				if( !IsInForest( Leaf.Name ) ) {
					this.Nodes.Add( Leaf.Name, Leaf.Name, 0, 0 );
					TreeNode Tree = this.Nodes[ Leaf.Name ];
					ConstructTree( Tree, Leaf );
				}
			}
		}

		private void ConstructTree( TreeNode Tree, FenuLink Parent )
		{
			if( Parent == null ) {
				return;
			}
			foreach( string ChildName in Parent.Links ) {
				if( !IsInForest( ChildName ) && !IsInTree( Tree, ChildName ) ) {
					Tree.Nodes.Add( ChildName, ChildName, 0, 0 );
					TreeNode Subtree = Tree.Nodes[ ChildName ];
					FenuLink Child = FindFenuLinkByName( ChildName );
					ConstructTree( Subtree, Child );
				}
			}
		}

		private bool IsInForest( string LeafName )
		{
			if( this.Nodes.ContainsKey( LeafName ) ) {
				return true;
			}

			foreach( TreeNode Tree in this.Nodes ) {
				if( IsInTree( Tree, LeafName ) ) {
					return true;
				}
			}

			return false;
		}

		private bool IsInTree( TreeNode Tree, string LeafName )
		{
			if( Tree.Nodes.ContainsKey( LeafName ) ) {
				return true;
			}
			else {
				foreach( TreeNode Subtree in Tree.Nodes ) {
					if( IsInTree( Subtree, LeafName ) ) {
						return true;
					}
				}
				return false;
			}
		}




		private FenuLink FindFenuLinkByName( string name )
		{
			return links.Find( delegate( FenuLink selectedFenuLink )
											{
												return selectedFenuLink.Name == name;
											} );
		}

		#endregion

		#region Events

		private bool preventExpandCollapse = false;
		private DateTime lastMouseDownTime = DateTime.Now;

		protected override void OnBeforeExpand( TreeViewCancelEventArgs e )
		{
			e.Cancel = preventExpandCollapse;
			preventExpandCollapse = false;
		}

		protected override void OnBeforeCollapse( TreeViewCancelEventArgs e )
		{
			e.Cancel = preventExpandCollapse;
			preventExpandCollapse = false;
		}

		protected override void OnMouseDown( MouseEventArgs e )
		{
			int delta = (int)DateTime.Now.Subtract( lastMouseDownTime ).TotalMilliseconds;
			preventExpandCollapse = ( delta < SystemInformation.DoubleClickTime );
			lastMouseDownTime = DateTime.Now;
		}

		#endregion
	}

	internal class FenuLink
	{
		public FenuLink( string name )
		{
			this._Name = name;
		}

		private string _Name = string.Empty;
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

		private List<string> _Links = new List<string>();
		public List<string> Links
		{
			get
			{
				return _Links;
			}
			set
			{
				_Links = value;
			}
		}

		private bool _IsRoot = true;
		public bool IsRoot
		{
			get
			{
				return _IsRoot;
			}
			set
			{
				_IsRoot = value;
			}
		}
	}
}
