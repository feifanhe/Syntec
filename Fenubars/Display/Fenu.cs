using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Fenubars.Buttons;
using Fenubars.XML;

namespace Fenubars.Display
{
	[TypeConverter( typeof( ExpandableObjectConverter ) )]
	public partial class Fenu : UserControl
	{
		public Fenu( ) {
			InitializeComponent();

			// Overwrite title bar splitter distance
			TitleBarSplitterContainer.SplitterDistance = TitleBarSplitterContainer.Width - 25;
		}

		private FenuContent _FenuContent;
		public void AssignFenuContent(FenuContent FenuContent) {
			this._FenuContent = FenuContent;
		}

		public void PopulateButtons( ) {
			// Modify the title to call-pathway
			FenuTitle.Text = _FenuContent.Name;

			int buttons = 8;
			Button DummyButton;

			// Add Escape and Next button
			DummyButton = new Button();
			DummyButton.Name = "ESCAPE_BTN";
			DummyButton.Text = DummyButton.Name;
			DummyButton.Size = new Size( 80, 60 );
			DummyButton.Location = new Point( 3, 3 );
			DummyButton.DataBindings.Add( "Text", _FenuContent.EscapeButton, "Title" );
			DummyButton.DataBindings.Add( "Enabled", _FenuContent.EscapeButton, "ParseState" );
			FormSplitContainer.Panel2.Controls.Add( DummyButton );

			DummyButton = new Button();
			DummyButton.Name = "NEXT_BTN";
			DummyButton.Text = DummyButton.Name;
			DummyButton.Size = new Size( 80, 60 );
			DummyButton.Location = new Point( 3 + 83 * ( buttons + 1 ), 3 );
			DummyButton.DataBindings.Add( "Text", _FenuContent.NextButton, "Title" );
			DummyButton.DataBindings.Add( "Enabled", _FenuContent.NextButton, "ParseState" );
			FormSplitContainer.Panel2.Controls.Add( DummyButton );


			// Add normal buttons
			// TODO: Button amounts should varies
			for( int i = 1; i <= buttons; i++ )
			{
				DummyButton = new Button();
				DummyButton.Name = "NORMAL_BTN_" + i.ToString();
				DummyButton.Text = DummyButton.Name;
				DummyButton.Size = new Size( 80, 60 );
				DummyButton.Location = new Point( 3 + 83 * i, 3 );
				DummyButton.Enabled = false;
				DummyButton.Click += new EventHandler( FenuButton_Click );

				//    // Bind properties to buttons
				//    DummyButton.DataBindings.Add( "Text", _FenuContent.NormalButtonList[ i ], "Title" );
				//    DummyButton.DataBindings.Add( "Enabled", _FenuContent.NormalButtonList[ i ], "ParseState" );
				//    //DummyButton.DataBindings.Add( "BackColor", DataSource, "ParseBackColor" );

				//    Console.WriteLine( _FenuContent.NormalButtonList[ i ].Title );

				FormSplitContainer.Panel2.Controls.Add( DummyButton );
			}

			foreach( NormalButtonState nbs in _FenuContent.NormalButtonList )
			{
				string TargetName = "NORMAL_BTN_" + nbs.Position.ToString();
				Control[] ctrl = this.FormSplitContainer.Panel2.Controls.Find( TargetName, false );
				try
				{
					if( ctrl.Length == 0 )
					{
						throw new Exception( "Cannot find control named [" + TargetName + "]" );
					}
					Button btn = ctrl[ 0 ] as Button;
					btn.DataBindings.Add( "Text", nbs, "Title" );
					btn.DataBindings.Add( "Enabled", nbs, "ParseState" );
				}
				catch( Exception e )
				{
					MessageBox.Show( e.Message );
				}
			}
		}

		#region Titlebar close event

		private void CloseFenu_MouseEnter(object sender, EventArgs e) {
			CloseFenu.BackColor = SystemColors.Highlight;
		}

		private void CloseFenu_MouseLeave(object sender, EventArgs e) {
			CloseFenu.BackColor = SystemColors.ActiveCaption;
		}

		private void CloseFenu_Click(object sender, EventArgs e) {
			// TODO: Save any possible modification to data source
			this.Dispose();
		}

		//private void CloseFenu_Paint(object sender, PaintEventArgs e) {
		//    base.OnPaint( e );

		//    // Override border 3d into raised border
		//    ControlPaint.DrawBorder3D( e.Graphics, CloseFenu.ClientRectangle,
		//                                    Border3DStyle.Raised, Border3DSide.All );

		//    CloseFenu.ForeColor = SystemColors.ActiveCaption;
		//}

		#endregion

		#region Event passing

		public event EventHandler DataAvailable;
		protected virtual void OnDataAvailable(EventArgs e) {
			EventHandler eh = DataAvailable;
			if( eh != null )
			{
				eh( this, e );
			}
		}

		private object _FocusedObject;
		[TypeConverter( typeof( ExpandableObjectConverter ) )]
		public object FocusedObject {
			get {
				return _FocusedObject;
			}
			set {
				_FocusedObject = value;
			}
		}

		private void FenuButton_Click(object sender, EventArgs e) {
			MessageBox.Show( ( sender as Button ).Name );
			FocusedObject = sender;
			OnDataAvailable( null );
		}

		#endregion
	}
}
