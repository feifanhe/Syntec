using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

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
			if( e.Node.Tag.GetType() != typeof( ListViewGroupCollection ) )
				return;

			Template_ListView.Groups.Clear();
			Template_ListView.Groups.AddRange( e.Node.Tag as ListViewGroupCollection);
		}

		private void Template_ListView_ItemChecked( object sender, ItemCheckedEventArgs e )
		{
			if( e.Item.Tag == null )
				return;
			if( e.Item.Tag.GetType() != typeof( string ) )
				return;

			Description_TextBox.Text = e.Item.Tag as string;
		}
	}
}
