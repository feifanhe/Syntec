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
				// Remove the tree view
				foreach( Control item in this.Controls ) {
					if( item is TreeView )
						this.Controls.Remove( item );
				}

				// Add the assigned tree view
				// Remove tool strip first to maintain visibility of tree view
				treeView.Dock = DockStyle.Fill;
				this.Controls.Remove(ObjectBrowser_ToolStrip);
				this.Controls.Add( treeView );
				this.Controls.Add( ObjectBrowser_ToolStrip );
			}
		}
	}
}