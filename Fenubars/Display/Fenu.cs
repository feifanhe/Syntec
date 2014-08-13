using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Fenubars.Buttons;
using Fenubars.XML;

namespace Fenubars.Display
{
	public partial class Fenu : UserControl
	{
		public FenuContent fc;
		public Fenu( ) {
			InitializeComponent();

			// Overwrite title bar splitter distance
			TitleBarSplitterContainer.SplitterDistance = TitleBarSplitterContainer.Width - 25;
		}

		public void PopulateButtons( ) {
			FenuTitle.Text = fc.Name;

			//// Initiate fenu property class
			//fc = new FenuContent();

			// Add normal buttons
			for( int i = 1; i <= 8; i++ )
			{
				Button DummyButton = new Button();
				DummyButton.Name = "NORMAL_BTN_" + i.ToString();
				DummyButton.Text = DummyButton.Name;
				DummyButton.Size = new Size( 80, 60 );
				DummyButton.Location = new Point( 3 + 83 * i, 3 );

				DummyButton.DataBindings.Add( "Text", fc.NB, "Title" );
				DummyButton.DataBindings.Add( "Enabled", fc.NB, "ParseState" );
				DummyButton.DataBindings.Add( "BackColor", fc.NB, "ParseBackColor" );

				FormSplitContainer.Panel2.Controls.Add( DummyButton );
			}

			// Bind properties to buttons

			//NormalButton nb = new NormalButton();
			//this.Controls.Add( nb );
		}

		private void CloseFenu_MouseEnter(object sender, EventArgs e) {
			CloseFenu.BackColor = SystemColors.Highlight;
		}

		private void CloseFenu_MouseLeave(object sender, EventArgs e) {
			CloseFenu.BackColor = SystemColors.ActiveCaption;
		}
	}
}
