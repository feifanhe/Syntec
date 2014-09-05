using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;

namespace Syntec.Windows
{
	public partial class NewWorkspaceDialog : Form
	{
		public string SeletedProduct
		{
			get
			{
				return this.SelectionPanel.SelectedTreeNode;
			}
		}

		public string SeletedPath
		{
			get
			{
				return this.InputPanel.SelectedPath;
			}
		}

		public int SelectedSolutionIndex
		{
			get
			{
				return this.InputPanel.SelectedSolutionIndex;
			}
		}

		public NewWorkspaceDialog()
		{
			InitializeComponent();
			this.SelectionPanel.PopulateCategory( "Workspace.xml" );
		}

		private void OK_Button_Click( object sender, EventArgs e )
		{
			if( SeletedProduct == null ) {
				MessageBox.Show( "Please select a product" );
				return;
			}
			if( !Directory.Exists( SeletedPath ) ) {
				return;
			}

			this.DialogResult = DialogResult.OK;
		}

		private void Cancel_Button_Click( object sender, EventArgs e )
		{
			this.DialogResult = DialogResult.Cancel;
		}
		
	}
}