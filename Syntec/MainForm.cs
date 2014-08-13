using System;
using WeifenLuo.WinFormsUI.Docking;

using Syntec.Windows;
using System.Windows.Forms;

namespace Syntec
{
	public partial class MainForm : Form
	{
		DocumentsForm df;
		public MainForm( ) {
			InitializeComponent();

			PropertiesWindowForm pwf = new PropertiesWindowForm();
			pwf.Show( DockPanel, DockState.DockRight );

			df = new DocumentsForm();
			df.Show( DockPanel, DockState.Document );

			
		}

		private void Help_MenuItem_Click(object sender, EventArgs e) {
			MessageBox.Show( "START CHANGING" );

			df.fenuloader.Properties.Fenus[ 0 ].NormalButton[ 1 ].Title = "CHANGED";

			MessageBox.Show( "CHANGE COMPLETE" );
		}
	}
}