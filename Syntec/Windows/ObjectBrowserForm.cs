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
				(treeView as TreeView).NodeMouseDoubleClick += new TreeNodeMouseClickEventHandler(NodeMouseDoubleClick);
				this.Controls.Remove(ObjectBrowser_ToolStrip);
				this.Controls.Add( treeView );
				this.Controls.Add( ObjectBrowser_ToolStrip );
			}
		}

		private void NodeMouseDoubleClick( object sender, TreeNodeMouseClickEventArgs e )
		{
			string treeViewName = string.Empty;
			foreach( Control item in this.Controls ) {
				if( item is TreeView )
					treeViewName = item.Name;
			}

			foreach( Form form in Application.OpenForms ) {
				if( form is DocumentsForm ) {
					if( ( form as DocumentsForm ).TabText == treeViewName ) {
						( form as DocumentsForm ).Open( e.Node.Name );
						break;
					}
				}
			}
		}
	}
}