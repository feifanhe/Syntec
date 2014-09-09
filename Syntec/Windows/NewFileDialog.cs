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
		#region Properties

		public string SelectedFileType
		{
			get
			{
				return this.SelectionPanel.SelectedCategory;
			}
		}

		#endregion

		#region Constructor

		public NewFileDialog()
		{
			InitializeComponent();
			this.SelectionPanel.PopulateCategory( Application.StartupPath + Global.DefinitonFolderPath + "File.xml" );
		}

		#endregion

		#region Button Click

		private void OK_Button_Click( object sender, EventArgs e )
		{
			this.DialogResult = DialogResult.OK;
		}

		private void Cancel_Button_Click( object sender, EventArgs e )
		{
			this.DialogResult = DialogResult.Cancel;
		}

		#endregion
	}
}