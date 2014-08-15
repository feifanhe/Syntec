using System.Windows.Forms;
using Fenubars.XML;
using System.Drawing;

namespace Fenubars.Buttons
{
	public partial class EscapeButton : Button
	{
		public EscapeButton(EscapeButtonState EState) {
			InitializeComponent();

			// Basic setup
			this.Name = "ESCAPE_BTN";
			this.Text = this.Name;
			this.Size = new Size( 80, 60 );

			NormalButtonState State = new NormalButtonState();

			// Bindings
			this.DataBindings.Add( "Name", State, "Name" );
			this.DataBindings.Add( "Text", State, "Title" );
			//this.DataBindings.Add( "FlatStyle", State, "ParseStyle" );

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
