using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace Syntec.Windows
{
	public partial class StringManagerForm : DockContent
	{
		public StringManagerForm()
		{
			InitializeComponent();
		}

		// TODO: Modulize Language Manager
		public void ShowString( string Path )
		{
			this.String_TreeView.Nodes.Clear();

			//Language.Display.ObjectTree Tree = new Language.Display.ObjectTree();
			String_TreeView.Load( Path );

			// Copy tree nodes
			//TreeNode[] treeNodes = new TreeNode[ Tree.Nodes.Count ];
			//Tree.Nodes.CopyTo( treeNodes, 0 );

			//String_TreeView.Nodes.Add( Tree.Nodes[0] );

			//String_TreeView.PerformLayout();
		}

		public string FindString( string path, string id, string language )
		{
			return this.String_TreeView.FindString( path, id, language );
		}


	}
}

