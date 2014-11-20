using System.Windows.Forms;
using Fenubars.XML;
using System.Drawing;

namespace Fenubars.Buttons
{
	public partial class NormalButton : Button
	{
		public delegate void ButtonModifiedHandler();
		public event ButtonModifiedHandler Modified;

		public delegate string GetResourceEventHandler( string ID );
		public event GetResourceEventHandler OnGetResource;

		public NormalButton( int Index )
		{
			InitializeComponent();

			// Non-variable visual setup
			this.Size = new Size( 80, 60 );
			this.Location = new Point( 3 + 80 * Index, 3 );
		}

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

			// Create binding source for this button
			Binding bind;
			BindingSource buttonBindingSource = new BindingSource();
			buttonBindingSource.DataSource = State;

			// Bindings
			this.DataBindings.Add( "Name", buttonBindingSource, "Name" );
			this.DataBindings.Add( "BackColor", buttonBindingSource, "BackColor" );
			this.DataBindings.Add( "ForeColor", buttonBindingSource, "ForeColor" );

			bind = new Binding( "Text", buttonBindingSource, "Title" );
			bind.Format += new ConvertEventHandler( IdToContent );
			this.DataBindings.Add( bind );

			bind = new Binding( "Enabled", buttonBindingSource, "State" );
			bind.Format += new ConvertEventHandler( StateConverter.StateToBool );
			bind.Parse += new ConvertEventHandler( StateConverter.BoolToState );
			this.DataBindings.Add( bind );

			BindingSource globalBindingSource = new BindingSource();
			globalBindingSource.DataSource = globalFenuState;
			this.DataBindings.Add( "TextAlign", globalBindingSource, "Alignment" );

			// Post-filled
			//State.Name = State.Name ?? "F" + State.Position.ToString();

			buttonBindingSource.CurrentItemChanged += new System.EventHandler( bindingSource_CurrentItemChanged );
			// Reset IsDirty
			//_IsDirty = false;
		}

		private void bindingSource_CurrentItemChanged( object sender, System.EventArgs e )
		{
			if( Modified != null ) {
				Modified();
			}
		}

		public void PaintComponent( System.Windows.Forms.Control.ControlCollection Canvas )
		{
			Canvas.Add( this );
		}

		public void IdToContent( object sender, ConvertEventArgs cevent )
		{
			if( cevent.Value != null ) {
				string id = (string)cevent.Value;
				if( id.ToUpper().StartsWith( "STR::" ) ) {
					string resource = this.OnGetResource( id.Substring( 5 ) );
					cevent.Value = ( resource == string.Empty ) ? id : resource;
				}
			}
		}
	}
}
