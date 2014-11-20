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
		}

		public void AddItem( DocumentsForm host, ModuleInterface.SearchResult searchResult )
		{
			string displayName = host.XMLPath + " : " + searchResult.ObjectName;
			ListViewItem newItem = new ListViewItem( displayName, 0 );
			newItem.Tag = searchResult;
			this.listView1.Items.Add( newItem );
		}

		public void ClearItem()
		{
			this.listView1.Items.Clear();
		}

		private void listView1_MouseDoubleClick( object sender, MouseEventArgs e )
		{
			ListViewItem item = listView1.GetItemAt( e.X, e.Y );
			ModuleInterface.SearchResult searchResult = item.Tag as ModuleInterface.SearchResult;
			searchResult.ShowResult( searchResult.ObjectName );
		}
	}
}