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

		public string SelectedCategory
		{
			get
			{
				return Categories_TreeView.SelectedNode.FullPath;
			}
		}

		ListViewItem _SelectedTemplate;
		public string SelectedTemplate
		{
			get
			{
				if( _SelectedTemplate == null ) {
					return string.Empty;
				}
				XmlElement Tag = _SelectedTemplate.Tag as XmlElement;
				if( Tag.Attributes[ "value" ] != null ) {
					return Tag.Attributes[ "value" ].Value;
				}
				else {
					return string.Empty;
				}
			}
		}

		#endregion

		#region Constructor

		public NewItemSelectionPanel()
		{
			InitializeComponent();
		}

		#endregion

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

			this.Categories_TreeView.Nodes.Clear();

			if( xDoc.DocumentElement == null ||
				string.Compare( xDoc.DocumentElement.Name, "Category" ) != 0 ||
				xDoc.DocumentElement.Attributes[ "name" ] == null ) {
				return;
			}

			TreeNode Root = new TreeNode( xDoc.DocumentElement.Attributes[ "name" ].Value );
			Root.Tag = xDoc.DocumentElement;
			AddNode( Root, xDoc.DocumentElement );
			this.Categories_TreeView.Nodes.Add( Root );
			Root.ExpandAll();
			this.Categories_TreeView.SelectedNode = Root;
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

		#region Template

		public void PopulateTemplate( XmlElement CategoryNode )
		{
			this.Templates_ListView.Items.Clear();
			foreach( XmlElement Element in CategoryNode.ChildNodes ) {
				if( Element.Name == "Template" ) {
					{
						ListViewItem Template = new ListViewItem( Element.Attributes[ "name" ].Value, 0 );
						Template.Tag = Element;
						this.Templates_ListView.Items.Add( Template );
					}
				}
			}
			this.Templates_ListView.Select();
			if( this.Templates_ListView.Items.Count > 0 ) {
				this.Templates_ListView.Items[ 0 ].Selected = true;
			}
		}

		#endregion

		#region Event

		private void Category_TreeView_AfterSelect( object sender, TreeViewEventArgs e )
		{
			if( e.Node.Tag == null )
				return;
			if( e.Node.Tag.GetType() != typeof( XmlElement ) )
				return;

			XmlElement Tag = e.Node.Tag as XmlElement;

			PopulateTemplate( Tag );

			if( Tag.Attributes[ "desc" ] != null ) {
				this.Description_TextBox.Text = Tag.Attributes[ "desc" ].Value;
			}
		}

		private void Template_ListView_ItemSelectionChanged( object sender, ListViewItemSelectionChangedEventArgs e )
		{
			if( e.Item.Tag == null )
				return;
			if( e.Item.Tag.GetType() != typeof( XmlElement ) )
				return;

			this._SelectedTemplate = e.Item;

			XmlElement Tag = e.Item.Tag as XmlElement;

			if( Tag.Attributes[ "desc" ] != null ) {
				this.Description_TextBox.Text = Tag.Attributes[ "desc" ].Value;
			}
		}

		#endregion


	}
}
