using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Syntec.Windows
{
	public partial class NewFileDialog : Form
	{
		public string SeletedFileType
		{
			get
			{
				return this.SelectionPanel.SelectedTreeNode;
			}
		}

		public NewFileDialog()
		{
			InitializeComponent();
			this.SelectionPanel.PopulateCategory( "File.xml" );
		}

		private void OK_Button_Click( object sender, EventArgs e )
		{
			this.DialogResult = DialogResult.OK;
		}

		private void Cancel_Button_Click( object sender, EventArgs e )
		{
			this.DialogResult = DialogResult.Cancel;
		}
	}
}