using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Fenubars.Display;
using Fenubars.XML;

namespace FormTest
{
	public partial class MainForm : Form
	{
		public MainForm( ) {
			InitializeComponent();

			FenuContent fc1 = new FenuContent();
			fc1.Name = "FENU1";
			Fenu fenu1 = new Fenu();
			fenu1.fc = fc1;
			fenu1.PopulateButtons();

			FenuContent fc2 = new FenuContent();
			fc2.Name = "FENU2";
			Fenu fenu2 = new Fenu();
			fenu2.fc = fc2;
			fenu2.PopulateButtons();

			//fenu1.Dock = DockStyle.Top;
			this.Controls.Add( fenu1 );
			this.Controls.Add( fenu2 );
		}
	}
}