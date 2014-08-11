using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Fenubars
{
	public enum ButtonCounts { 
		[Description("5")]
		FIVE, 
		[Description("8")]
		EIGHT, 
		//[Description("10")]
		//TEN 
	};

	public partial class Fenu : UserControl
	{	
		// Currently a hidden feature
		[Browsable(false)]
		[Category("Designer")]
		[DefaultValue(ButtonCounts.EIGHT)]
		[NonSerialized()]
		private ButtonCounts _ButtonCounts = ButtonCounts.EIGHT;
		public ButtonCounts ButtonCounts {
			get {
				return _ButtonCounts;
			}
			set {
				_ButtonCounts = value;
			}
		}
		
		public Fenu( ) {
			InitializeComponent();
			PopulateButtons();

			Console.WriteLine( this.Size );
			Console.WriteLine( FenuButtonPanel.Size );
		}

		private Button[] ButtonsHolder;	// Container for fenubuttons
		private void PopulateButtons( ) {

			for( int i = 3; i <5 ; i++ )
			{
				PopulateButton<NormalButton>( i );
			}
		}

		private void PopulateButton<T>(int ButtonSequence) where T : NormalButton {
			//// Instantatiate new button
			//ButtonsHolder[ ButtonSequence ] = (NormalButton)(new Button());//Activator.CreateInstance<T>();

			//// Setup button visual look
			//ButtonsHolder[ ButtonSequence ].Location = new Point( 3 + 80 * ButtonSequence, 3 );
			//ButtonsHolder[ ButtonSequence ].Size = new Size( 80, 60 );

			//// Add button to panel
			//FenuButtonPanel.Controls.Add( ButtonsHolder[ ButtonSequence ] );

			T GeneratedButton = Activator.CreateInstance<T>();

			GeneratedButton.Location = new Point( 3 + 80 * ButtonSequence, 3 );
			GeneratedButton.Size = new Size( 80, 60 );

			FenuButtonPanel.Controls.Add( GeneratedButton );
		}
	}
}
