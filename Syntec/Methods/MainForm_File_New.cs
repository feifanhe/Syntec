using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Syntec.Windows
{
	public partial class MainForm
	{
		private void New_Workspace_ToolStripMenuItem_Click( object sender, EventArgs e )
		{
			NewWorkspaceDialog dialog = new NewWorkspaceDialog();
			if( dialog.ShowDialog() == DialogResult.OK ) {
				// TODO: new workspace
				RecentWorkspacesMenu.AddFile( dialog.SelectedBaseRes );
				WorkspaceExplorer.ShowWorkspace( dialog.SelectedBaseRes );
				StringViewer.ShowString( dialog.SelectedBaseRes );
			}
		}

		private void New_File_ToolStripMenuItem_Click( object sender, EventArgs e )
		{
			NewFileDialog dialog = new NewFileDialog();
			if( dialog.ShowDialog() == DialogResult.OK ) {
				// TODO: new file
			}
		}
	}
}
