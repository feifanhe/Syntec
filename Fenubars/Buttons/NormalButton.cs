using System.Windows.Forms;
using Fenubars.XML;
using System.Drawing;

namespace Fenubars.Buttons
{
	public partial class NormalButton : Button
	{
		public NormalButton( int Index )
		{
			InitializeComponent();

			// Non-variable visual setup
			this.Size = new Size( 80, 60 );
			this.Location = new Point( 3 + 83 * Index, 3 );
		}

		private bool _IsDirty = false;
		public bool IsDirty
		{
			get
			{
				return _IsDirty;
			}
			set
			{
				_IsDirty = value;
			}
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

			// Create binding source for this button
			BindingSource bindingSource = new BindingSource();
			bindingSource.DataSource = State;
			bindingSource.CurrentItemChanged += new System.EventHandler( bindingSource_CurrentItemChanged );

			// Bindings
			this.DataBindings.Add( "Name", bindingSource, "Name" );
			this.DataBindings.Add( "Text", bindingSource, "Title" );

			bind = new Binding( "Enabled", bindingSource, "State" );
			bind.Format += new ConvertEventHandler( StateConverter.StateToBool );
			bind.Parse += new ConvertEventHandler( StateConverter.BoolToState );
			this.DataBindings.Add( bind );

			bind = new Binding( "BackColor", bindingSource, "BackColor" );
			bind.Format += new ConvertEventHandler( Fenubars.XML.ColorConverter.StringToColor );
			bind.Parse += new ConvertEventHandler( Fenubars.XML.ColorConverter.ColorToString );
			this.DataBindings.Add( bind );

			bind = new Binding( "ForeColor", bindingSource, "ForeColor" );
			bind.Format += new ConvertEventHandler( Fenubars.XML.ColorConverter.StringToColor );
			bind.Parse += new ConvertEventHandler( Fenubars.XML.ColorConverter.ColorToString );
			this.DataBindings.Add( bind );

			// Post-filled
			State.Name = State.Name ?? "F" + State.Position.ToString();

			// Reset IsDirty
			_IsDirty = false;
		}

		private void bindingSource_CurrentItemChanged( object sender, System.EventArgs e )
		{
			_IsDirty = true;
		}

		public void PaintComponent( System.Windows.Forms.Control.ControlCollection Canvas )
		{
			Canvas.Add( this );
		}
	}
}
