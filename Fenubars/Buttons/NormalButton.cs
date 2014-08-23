using System.Windows.Forms;
using Fenubars.XML;
using System.Drawing;

namespace Fenubars.Buttons
{
	public partial class NormalButton : Button
	{
		public NormalButton(int Index ) {
			InitializeComponent();
			
			// Non-variable visual setup
			this.Size = new Size( 80, 60 );
			this.Location = new Point( 3 + 83 * Index, 3 );
		}

		private Binding bind;
		public void SetState(FenuButtonState State) {
			// Bindings
			this.DataBindings.Add( "Name", State, "Name" );
			this.DataBindings.Add( "Text", State, "Title" );

			bind = new Binding( "Enabled", State, "State" );
			bind.Format += new ConvertEventHandler( StateConverter.StateToBool );
			bind.Parse += new ConvertEventHandler( StateConverter.BoolToState );
			this.DataBindings.Add( bind );

			bind = new Binding("BackColor", State, "BackColor");
			bind.Format += new ConvertEventHandler( Fenubars.XML.ColorConverter.StringToColor );
			bind.Parse += new ConvertEventHandler( Fenubars.XML.ColorConverter.ColorToString );
			this.DataBindings.Add( bind );

			// Post-filled
			State.Name = State.Name ?? "F" + State.Position.ToString(); 
		}

		public void PaintComponent(System.Windows.Forms.Control.ControlCollection Canvas) {
			Canvas.Add( this );
		}
	}
}
