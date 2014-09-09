using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace Syntec.Windows
{
	public partial class NewItemSelectionPanel : UserControl
	{
		#region Properties

		public string SelectedTreeNode
		{
			get
			{
				return Category_TreeView.SelectedNode.FullPath;
			}
		}

		#endregion

		public NewItemSelectionPanel()
		{
			InitializeComponent();
		}

		#region Category

		public void PopulateCategory( string ConfigFile )
		{
			XmlDocument xDoc = new XmlDocument();
			try {
				xDoc.Load( ConfigFile );
			}
			catch( System.IO.FileNotFoundException ) {
				MessageBox.Show( "Can't find " + ConfigFile );
				return;
			}
			catch( XmlException e ) {
				MessageBox.Show( "Invalid Format: " + e.Message );
				return;
			}

			this.Category_TreeView.Nodes.Clear();

			if( xDoc.DocumentElement == null ||
				string.Compare( xDoc.DocumentElement.Name, "Category" ) != 0 ||
				xDoc.DocumentElement.Attributes[ "name" ] == null ) {
				return;
			}

			TreeNode Root = new TreeNode( xDoc.DocumentElement.Attributes[ "name" ].Value );
			Root.Tag = xDoc.DocumentElement;
			AddNode( Root, xDoc.DocumentElement );
			this.Category_TreeView.Nodes.Add( Root );
			Root.ExpandAll();
		}

		private void AddNode( TreeNode ParentTreeNode, XmlElement ParentXmlNode )
		{
			if( ParentXmlNode.HasChildNodes ) {
				foreach( XmlElement Element in ParentXmlNode.ChildNodes ) {
					if( Element.Name == "Category" ) {
						{
							TreeNode Child = new TreeNode( Element.Attributes[ "name" ].Value );
							Child.Tag = Element;
							AddNode( Child, Element );
							ParentTreeNode.Nodes.Add( Child );
						}
					}
				}
			}
		}

		#endregion

		#region Event

		private void Category_TreeView_NodeMouseClick( object sender, TreeNodeMouseClickEventArgs e )
		{
			if( e.Node.Tag == null )
				return;
			if( e.Node.Tag.GetType() != typeof( XmlElement ) )
				return;

			XmlElement Tag = e.Node.Tag as XmlElement;

			// TODO: Show Desc of Node
			if( Tag.Attributes[ "desc" ] != null ) {
				this.Description_TextBox.Text = Tag.Attributes[ "desc" ].Value;
			}

			// TODO: Populate Template List
		}

		private void Template_ListView_ItemChecked( object sender, ItemCheckedEventArgs e )
		{
			if( e.Item.Tag == null )
				return;
			if( e.Item.Tag.GetType() != typeof( XmlElement ) )
				return;

			// TODO: Show Desc & Select Template
		}

		#endregion
	}
}
