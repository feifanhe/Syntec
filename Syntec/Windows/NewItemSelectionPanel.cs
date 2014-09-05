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
		public TreeView Category
		{
			get
			{
				return this.Category_TreeView;
			}
		}

		public NewItemSelectionPanel()
		{
			InitializeComponent();
		}

		private void Category_TreeView_NodeMouseClick( object sender, TreeNodeMouseClickEventArgs e )
		{
			if( e.Node.Tag == null )
				return;
			if( e.Node.Tag.GetType() != typeof( XmlElement ) )
				return;

			XmlElement Tag = e.Node.Tag as XmlElement;

			// TODO: Show Desc of Node
			this.Description_TextBox.Text = Tag.Attributes[ "desc" ].Value;

			// TODO: Populate Template List
		}

		private void Template_ListView_ItemChecked( object sender, ItemCheckedEventArgs e )
		{
			if( e.Item.Tag == null )
				return;
			if( e.Item.Tag.GetType() != typeof( string ) )
				return;

			Description_TextBox.Text = e.Item.Tag as string;
		}

		public void PopulateCategory(string ConfigFile)
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
			TreeNode Root = new TreeNode( xDoc.DocumentElement.Name );
			Root.Tag = xDoc.DocumentElement;
			AddNode( Root, xDoc.DocumentElement );
			this.Category_TreeView.Nodes.Add( Root );
			Root.ExpandAll();
		}

		private void AddNode( TreeNode ParentTreeNode, XmlElement ParentXmlNode )
		{
			if( ParentXmlNode.HasChildNodes ) {
				foreach( XmlElement Element in ParentXmlNode.ChildNodes ) {
					if( Element.Name == "Model" ) {
						TreeNode Model = new TreeNode( Element.Attributes[ "name" ].Value );
						Model.Tag = Element;
						ParentTreeNode.Nodes.Add( Model );
					}
					else {
						TreeNode Child = new TreeNode( Element.Name );
						Child.Tag = Element;
						AddNode( Child, Element );
						ParentTreeNode.Nodes.Add( Child );
					}
				}
			}
		}
	}
}
