using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Syntec.Windows
{
	public partial class NewItemInputPanel : UserControl
	{
		public string SelectedPath
		{
			get
			{
				return this.Location_Text.Text;
			}
		}

		public int SelectedSolutionIndex
		{
			get
			{
				return this.Solution_ComboBox.SelectedIndex;
			}
		}

		public NewItemInputPanel()
		{
			InitializeComponent();
			this.Solution_ComboBox.Items.AddRange( 
				new string[] {
					"Add to existing Res folder",
					"Create new Res folder"
				} );
			this.Solution_ComboBox.SelectedIndex = 0;
		}

		private void Browser_Button_Click( object sender, EventArgs e )
		{
			FolderBrowserDialog dialog = new FolderBrowserDialog();
			if( dialog.ShowDialog() == DialogResult.OK ) {
				this.Location_Text.Text = dialog.SelectedPath;
			}
		}
	}
}
