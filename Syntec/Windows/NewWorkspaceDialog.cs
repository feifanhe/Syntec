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

		private string _SelectedBaseRes = string.Empty;
		public string SelectedBaseRes
		{
			get
			{
				return this._SelectedBaseRes;
			}
		}

		#endregion

		#region Constructor

		public NewWorkspaceDialog()
		{
			InitializeComponent();
			this.SelectionPanel.PopulateCategory( "Workspace.xml" );
		}

		#endregion

		#region Button Click

		private void OK_Button_Click( object sender, EventArgs e )
		{
			if( this.SelectionPanel.SelectedCategory == null ) {
				MessageBox.Show( "Please select a product" );
				return;
			}
			if( !Directory.Exists( this.InputPanel.SelectedPath ) ) {
				MessageBox.Show( "Please select a path" );
				return;
			}

			string ProductPath =
					this.SelectionPanel.SelectedCategory.Replace( "\\", "\\_" ).Substring(
					this.SelectionPanel.SelectedCategory.IndexOf( "\\" ) );

			if( this.InputPanel.SelectedSolutionIndex == 0 ) {
				// Add to existing Res folder

				int index = this.InputPanel.SelectedPath.ToUpper().LastIndexOf( "RES" );
				if( index < 0 ) {
					// This section should never occur
					MessageBox.Show( "Designated path isn't located in Res.",
										"Wrong File Path",
										MessageBoxButtons.OK,
										MessageBoxIcon.Error );
					return;
				}
				this._SelectedBaseRes = this.InputPanel.SelectedPath.Substring( 0, index ) + @"Res\";
				Directory.CreateDirectory( this._SelectedBaseRes + ProductPath );
			}
			else {
				// Create new Res folder
				this._SelectedBaseRes = this.InputPanel.SelectedPath + @"\Res";
				Directory.CreateDirectory( this._SelectedBaseRes + ProductPath );
			
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