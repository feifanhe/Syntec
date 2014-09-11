using System.Windows.Forms;
using Fenubars.XML;
using System.Drawing;

namespace Fenubars.Buttons
{
	public partial class NextButton : Button
	{
		public NextButton()
		{
			InitializeComponent();

			// Non-variable visual setup
			this.Size = new Size( 80, 60 );
		}

		private Binding bind;
		public void SetState( FenuButtonState State )
		{
			SetState( State, false );
		}
		public void SetState( FenuButtonState State, bool isForeign )
		{
			// Wipe bindings
			this.DataBindings.Clear();
			this.ResetText();
			this.FlatStyle = FlatStyle.Popup;

			// Adjust button style to indicate configured or not
			if( State == null )
				return;
			if( !isForeign )
				this.FlatStyle = FlatStyle.Standard;

			// Basic setup
			this.Text = ">>";

			// Bindings
			this.DataBindings.Add( "Name", State, "Name" );

			bind = new Binding( "Enabled", State, "State" );
			bind.Format += new ConvertEventHandler( StateConverter.StateToBool );
			bind.Parse += new ConvertEventHandler( StateConverter.BoolToState );
			this.DataBindings.Add( bind );

			// Post-filled
			State.Name = State.Name ?? "NEXT_BTN";
		}

		public void PaintComponent( System.Windows.Forms.Control.ControlCollection Canvas,
									Point Location )
		{
			this.Location = Location;
			Canvas.Add( this );
		}
	}
}
