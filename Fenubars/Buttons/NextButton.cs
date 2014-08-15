using System.Windows.Forms;
using Fenubars.XML;
using System.Drawing;

namespace Fenubars.Buttons
{
	public partial class NextButton : Button
	{
		public NextButton(NextButtonState State) {
			InitializeComponent();

			// Basic setup
			this.Name = "NEXT_BTN";
			this.Text = this.Name;
			this.Size = new Size( 80, 60 );

			// Bindings
			this.DataBindings.Add( "Name", State, "Name" );
			this.DataBindings.Add( "Text", State, "Title" );
			this.DataBindings.Add( "Enabled", State, "ParseState" );

			this.Enabled = true;
			State.ParseState = true;
		}

		public void PaintComponent(System.Windows.Forms.Control.ControlCollection Canvas,
									Point Location) {
			this.Location = Location;
			Canvas.Add( this );
		}
	}
}
