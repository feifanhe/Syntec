using System.Windows.Forms;
using Fenubars.XML;
using System.Drawing;

namespace Fenubars.Buttons
{
	public partial class NormalButton : Button
	{
		public NormalButton(int Index ) {
			InitializeComponent();
			
			// Basic setup
			this.Name = "F" + Index.ToString();
			this.Text = this.Name;
			this.Size = new Size( 80, 60 );
			this.Location = new Point( 3 + 83 * Index, 3 );
		}

		public void SetState(FenuButtonState State) {
			// Bindings
			this.DataBindings.Add( "Name", State, "Name" );
			this.DataBindings.Add( "Text", State, "Title" );
			//this.DataBindings.Add( "Enabled", State, "ParseState" );

			//this.Enabled = true;
			//State.ParseState = true;
		}

		public void PaintComponent(System.Windows.Forms.Control.ControlCollection Canvas) {
			Canvas.Add( this );
		}
	}
}
