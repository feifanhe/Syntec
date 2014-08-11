using System;
using WeifenLuo.WinFormsUI.Docking;

using Syntec.Windows;
using System.Windows.Forms;

namespace Syntec
{
	public partial class MainForm : Form
	{
		public MainForm( ) {
			InitializeComponent();

			PropertiesWindowForm pwf = new PropertiesWindowForm();
			pwf.Show( DockPanel, DockState.DockRight );
		}
	}
}