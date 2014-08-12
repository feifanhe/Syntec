using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Fenubars
{
	public enum ButtonCounts { 
		[Description("5")]
		FIVE, 
		[Description("8")]
		EIGHT, 
	};

	public partial class Fenu : UserControl
	{
		public Fenu() {
			// Initialize fenu layout
			InitializeComponent();

			//FenuName.Text = Properties.Name;

			//// Initialize all the buttons in the fenu
			//PopulateButtons();
		}

		private FenuProperties _Properties;
		public FenuProperties Properties {
			get {
				return _Properties;
			}
			set {
				_Properties = value;
				FenuName.Text = Properties.Name;
			}
		}

		public void PopulateButtons( ) {
			for( int i = 0; i <= 0; i ++ )
			{
				PopulateButton<NormalButton>( i );
			}
		}

		private void PopulateButton<T>(int ButtonSequence) where T : NormalButton {
			T GeneratedButton = Activator.CreateInstance<T>();

			GeneratedButton.BindProperty( Properties.NormalButton[ ButtonSequence ] );

			GeneratedButton.Location = new Point( 3 + 80 * ButtonSequence, 3 );
			GeneratedButton.Size = new Size( 80, 60 );
			
			FenuButtonPanel.Controls.Add( GeneratedButton );
		}
	}
}
