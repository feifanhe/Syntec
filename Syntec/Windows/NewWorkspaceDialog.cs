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
		#region Properties

		public string SelectedProduct
		{
			get
			{
				return this.SelectionPanel.SelectedCategory;
			}
		}

		public string SelectedPath
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
		#endregion

		#region Constructor

		public NewWorkspaceDialog()
		{
			InitializeComponent();
			this.SelectionPanel.PopulateCategory( Application.StartupPath + Global.DefinitonFolderPath + "Workspace.xml" );
		}

		#endregion

		#region Button Click

		private void OK_Button_Click( object sender, EventArgs e )
		{
			if( this.SelectedProduct == null ) {
				MessageBox.Show( "Please select a product" );
				return;
			}
			if( !Directory.Exists( this.SelectedPath ) ) {
				return;
			}

			this.DialogResult = DialogResult.OK;
		}

		private void Cancel_Button_Click( object sender, EventArgs e )
		{
			this.DialogResult = DialogResult.Cancel;
		}

		#endregion
	}
}