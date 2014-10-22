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
	public partial class FindResultsForm : DockContent
	{
		public FindResultsForm()
		{
			InitializeComponent();
			AddColumnHeader();
		}

		public void AddColumnHeader()
		{
			ColumnHeader header = new ColumnHeader();
			header.Text = "Fenu";
			header.Name = "Fenu";
			header.Width = this.FindResults_ListView.Width;
			this.FindResults_ListView.Columns.Add( header );
		}

		public void AddItem( DocumentsForm host, ModuleInterface.SearchResult searchResult )
		{
			string displayName = host.XMLPath + " : " + searchResult.ObjectName;
			ListViewItem newItem = new ListViewItem( displayName, 0 );
			newItem.Tag = searchResult;
			this.FindResults_ListView.Items.Add( newItem );
		}

		public void ClearItem()
		{
			this.FindResults_ListView.Items.Clear();
		}

		private void FindResults_MouseDoubleClick( object sender, MouseEventArgs e )
		{
			ListViewItem item = FindResults_ListView.GetItemAt( e.X, e.Y );
			ModuleInterface.SearchResult searchResult = item.Tag as ModuleInterface.SearchResult;
			searchResult.ShowResult( searchResult.ObjectName );
		}
	}
}