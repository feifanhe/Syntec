using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace Syntec.Windows
{
	public partial class NewItemDialog : Form
	{
		private TreeView tvwCategory;

		public NewItemDialog()
		{
			InitializeComponent();
			this.tvwCategory = this.MainPanel.Category;
			PopulateCategory();
		}

		public static void NewWorkspace()
		{
			NewItemDialog dialog = new NewItemDialog();
			dialog.PopulateCategory();
		}

		private void PopulateCategory()
		{
			XmlDocument xDoc = new XmlDocument();
			try {
				xDoc.Load( "Product.xml" );
			}
			catch( System.IO.FileNotFoundException ) {
				MessageBox.Show( "Can't find Product.xml" );
			}
			catch( XmlException e ) {
				MessageBox.Show( "Invalid Xml Format: " + e.Message );
			}

			this.tvwCategory.Nodes.Clear();
			TreeNode Root = new TreeNode( xDoc.DocumentElement.Name );
			AddNode( Root, xDoc.DocumentElement );
			this.tvwCategory.Nodes.Add( Root );
			Root.ExpandAll();
		}

		private void AddNode( TreeNode ParentTreeNode, XmlElement ParentXmlNode )
		{
			if( ParentXmlNode.HasChildNodes ) {
				foreach( XmlElement Element in ParentXmlNode.ChildNodes ) {
					if( Element.Name == "Model" ) {
						ParentTreeNode.Nodes.Add(
							new TreeNode( Element.Attributes[ "name" ].Value ) );
					}
					else {
						TreeNode Child = new TreeNode( Element.Name );
						AddNode( Child, Element );
						ParentTreeNode.Nodes.Add( Child );
					}
				}
			}
		}
	}
}