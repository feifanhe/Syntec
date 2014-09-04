using System;
using System.Collections.Generic;
using Fenubars.XML;
using System.Windows.Forms;

namespace Fenubars.Display
{
	public class ObjectTree_Template : TreeView
	{
		private readonly string CUSTOM_FENU_HEADER = "CUSTOMFENU_";

		private List<FenuLink> links = new List<FenuLink>();

		public ObjectTree_Template( string fileName, List<FenuState> fenus )
		{
			CompileLinksInfo(fenus);

			// Save file name
			this.Name = fileName;

			// First time execution, fully reconstruct the tree
			FullyReconstructTree();
		}

		#region Build tree

		private void CompileLinksInfo( List<FenuState> fenus )
		{
			foreach( FenuState fenu in fenus ) {
				FenuLink newLink = new FenuLink(fenu.Name);
				CompileChildLinks( newLink, fenu );

				links.Add( newLink );
			}

			// Wipe out non-root nodes
			for( int i = 0; i < links.Count; i++ ) {
				foreach( FenuLink readLink in links ) {
					if( readLink.Name == links[ i ].Name )
						continue;

					foreach( string link in readLink.Links ) {
						if( link == links[ i ].Name ) {
							links[ i ].IsRoot = false;
							break;
						}
					}
				}
			}
		}

		private void FullyReconstructTree()
		{
			this.Nodes.Clear();

			// Add root nodes first
			foreach( FenuLink link in links ) {
				if( link.IsRoot )
					this.Nodes.Add( link.Name, link.Name );
			}

			// Add childs for the root nodes
			foreach( TreeNode parent in this.Nodes ) {
				ParseLinksToChild( parent );
			}
		}

		private void CompileChildLinks( FenuLink parent, FenuState fenu )
		{
			List<string> links = new List<string>();

			// Add links from Escape Button
			//links.AddRange( ParseLinksFromButton( fenu.EscapeButton ) );

			// Add links from Normal Buttons
			foreach( FenuButtonState parsedNormalButton in fenu.NormalButtonList )
				links.AddRange( ParseLinksFromButton( parsedNormalButton ) );

			// Add links from Next Button
			links.AddRange( ParseLinksFromButton( fenu.NextButton ) );

			// Add to fenu link object
			parent.Links.AddRange( links.ToArray() );
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

		private void ParseLinksToChild( TreeNode parent )
		{
			FenuLink foundedLink = FindFenuLinkByName( parent.Name );

			// Skip this cycle if no link exist
			if( foundedLink == null )
				return;

			// Start the iteration
			List<string> linkInfo = foundedLink.Links;
			foreach( string link in linkInfo ) {
				if( !IsLoopFormed( parent.Name, link ) ) {
					if(!parent.Nodes.ContainsKey(link))
						parent.Nodes.Add( link, link );
					foreach( TreeNode childNode in parent.Nodes )
						ParseLinksToChild( childNode );
				}
			}
		}

		private bool IsLoopFormed( string current, string childToCreate )
		{
			FenuLink foundedLink = FindFenuLinkParent( current );

			if( foundedLink == null )
				return false;

			if( foundedLink.Name == childToCreate )
				return true;

			// Stop at root layer
			if( foundedLink.IsRoot )
				return false;
			else
				return IsLoopFormed( foundedLink.Name, childToCreate );
		}

		private FenuLink FindFenuLinkByName( string name )
		{
			return links.Find( delegate( FenuLink selectedFenuLink )
											{
												return selectedFenuLink.Name == name;
											} );
		}

		private FenuLink FindFenuLinkParent( string childName )
		{
			return links.Find( delegate( FenuLink selectedFenuLink )
											{
												foreach( string linkName in selectedFenuLink.Links )
													if( linkName == childName )
														return true;
												return false;
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

		//protected override void OnNodeMouseDoubleClick( TreeNodeMouseClickEventArgs e )
		//{
		//    MessageBox.Show( "DOUBLE CLICKED: " + e.Node.Name );
		//}

		#endregion
	}

	internal class FenuLink_Template
	{
		public FenuLink_Template( string name )
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
