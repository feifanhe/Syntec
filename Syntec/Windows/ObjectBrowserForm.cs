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
	public partial class ObjectBrowserForm : DockContent
	{
		public ObjectBrowserForm()
		{
			InitializeComponent();
		}

		public void SetContents( Control treeView )
		{
			if( treeView is TreeView ) {
				this.Controls.Clear();

				this.Controls.Add( treeView );
				treeView.Dock = DockStyle.Fill;
			}
		}
	}
}