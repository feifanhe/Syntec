using System.Windows.Forms;
using Fenubars.XML;
using System.Drawing;

namespace Fenubars.Buttons
{
	public partial class EscapeButton : Button
	{
		public delegate void ButtonModifiedHandler();
		public event ButtonModifiedHandler Modified;

		public EscapeButton()
		{
			InitializeComponent();

			// Non-variable visual setup
			this.Size = new Size( 80, 60 );
		}

		private Binding bind;
		public void SetState( XMLGlobalState globalFenuState, FenuButtonState State )
		{
			SetState( globalFenuState, State, false );
		}

		public void SetState( XMLGlobalState globalFenuState, FenuButtonState State, bool isForeign )
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
			this.Text = "<<";

			// Create binding source for this button
			BindingSource bindingSource = new BindingSource();
			bindingSource.DataSource = State;

			// Bindings
			this.DataBindings.Add( "Name", bindingSource, "Name" );

			bind = new Binding( "Enabled", bindingSource, "State" );
			bind.Format += new ConvertEventHandler( StateConverter.StateToBool );
			bind.Parse += new ConvertEventHandler( StateConverter.BoolToState );
			this.DataBindings.Add( bind );

			BindingSource globalBindingSource = new BindingSource();
			globalBindingSource.DataSource = globalFenuState;
			this.DataBindings.Add( "TextAlign", globalBindingSource, "Alignment" );

			// Post-filled
			State.Name = State.Name ?? "ESC_BTN";

			bindingSource.CurrentItemChanged += new System.EventHandler( bindingSource_CurrentItemChanged );
		}

		private void bindingSource_CurrentItemChanged( object sender, System.EventArgs e )
		{
			if( Modified != null ) {
				Modified();

			}
		}

		public void PaintComponent( System.Windows.Forms.Control.ControlCollection Canvas,
									Point Location )
		{
			this.Location = Location;
			Canvas.Add( this );
		}
	}
}
