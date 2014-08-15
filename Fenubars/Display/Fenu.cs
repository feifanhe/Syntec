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
	public partial class Fenu : UserControl
	{
		private FenuState _FenuContent;

		public Fenu( FenuState AssignedFenuContent) {
			InitializeComponent();

			this._FenuContent = AssignedFenuContent;

			// Overwrite title bar splitter distance
			TitleBarSplitterContainer.SplitterDistance = TitleBarSplitterContainer.Width - 25;

			// Set default docking position
			this.Dock = DockStyle.Top;
		}

		public void PopulateButtons( ) {
			// TODO: Modify the title to call-pathway
			FenuTitle.Text = _FenuContent.Name;

			int buttons = 8;
			Button DummyButton;

			// Add Escape and Next button
			//DummyButton = new Button();
			//DummyButton.Name = "ESCAPE_BTN";
			//DummyButton.Text = DummyButton.Name;
			//DummyButton.Size = new Size( 80, 60 );
			//DummyButton.Location = new Point( 3, 3 );
			//DummyButton.DataBindings.Add( "Name", _FenuContent.EscapeButton, "Name" );
			//DummyButton.DataBindings.Add( "Text", _FenuContent.EscapeButton, "Title" );
			//DummyButton.DataBindings.Add( "Enabled", _FenuContent.EscapeButton, "ParseState" );
			//FormSplitContainer.Panel2.Controls.Add( DummyButton );
			EscapeButton EB = new EscapeButton( _FenuContent.EscapeButton );
			EB.PaintComponent( FormSplitContainer.Panel2.Controls, new Point( 3, 3 ) );
			EB.Click += new EventHandler( FenuButton_Click );

			//DummyButton = new Button();
			//DummyButton.Name = "NEXT_BTN";
			//DummyButton.Text = DummyButton.Name;
			//DummyButton.Size = new Size( 80, 60 );
			//DummyButton.Location = new Point( 3 + 83 * ( buttons + 1 ), 3 );
			//DummyButton.DataBindings.Add( "Name", _FenuContent.NextButton, "Name" );
			//DummyButton.DataBindings.Add( "Text", _FenuContent.NextButton, "Title" );
			//DummyButton.DataBindings.Add( "Enabled", _FenuContent.NextButton, "ParseState" );
			//FormSplitContainer.Panel2.Controls.Add( DummyButton );
			NextButton NB = new NextButton( _FenuContent.NextButton );
			NB.PaintComponent( FormSplitContainer.Panel2.Controls, new Point( 3 + 83 * ( buttons + 1 ), 3 ) );
			NB.Click += new EventHandler( FenuButton_Click );


			// Add normal buttons
			// TODO: Button amounts should varies
			for( int i = 1; i <= buttons; i++ )
			{
				//DummyButton = new Button();
				//DummyButton.Name = "F" + i.ToString();
				//DummyButton.Size = new Size( 80, 60 );
				//DummyButton.Location = new Point( 3 + 83 * i, 3 );
				//DummyButton.Enabled = false;
				//DummyButton.Click += new EventHandler( FenuButton_Click );
				// TODO: Add double click

				NormalButton NRB = new NormalButton(i);
				NRB.Click += new EventHandler( FenuButton_Click );
				NRB.PaintComponent( FormSplitContainer.Panel2.Controls );


				//FormSplitContainer.Panel2.Controls.Add( DummyButton );
			}

			foreach( NormalButtonState nbs in _FenuContent.NormalButtonList )
			{
				string TargetName = "F" + nbs.Position.ToString();
				Control[] ctrlS = this.FormSplitContainer.Panel2.Controls.Find( TargetName, false );
				try
				{
					if( ctrlS.Length == 0 )
					{
						throw new Exception( "Cannot find control named [" + TargetName + "]" );
					}
					NormalButton btn = ctrlS[ 0 ] as NormalButton;
					btn.SetState( nbs );
					//btn.DataBindings.Add( "Name", nbs, "Name" );
					//btn.DataBindings.Add( "Text", nbs, "Title" );
					//btn.DataBindings.Add( "Enabled", nbs, "ParseState" );
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

		public event EventHandler<ObjectDetailEventArgs> DataAvailable;
		protected virtual void OnDataAvailable(ObjectDetailEventArgs e) {
			EventHandler<ObjectDetailEventArgs> eh = DataAvailable;
			if( eh != null )
			{
				eh( this, e );
			}
		}

		private void FenuButton_Click(object sender, EventArgs e) {

			ObjectDetailEventArgs args = new ObjectDetailEventArgs();
			args.Type = sender.GetType();

			if( args.Type == typeof( EscapeButton ) )
				args.Escape = _FenuContent.EscapeButton;
			else if( args.Type == typeof( NextButton ) )
				args.Next = _FenuContent.NextButton;
				
			//MessageBox.Show( ( sender as Button ).Name );
			Console.WriteLine( sender.GetType() );
			
			OnDataAvailable( args );
		}

		#endregion

		private void FenuTitle_Click(object sender, EventArgs e) {
			ObjectDetailEventArgs args = new ObjectDetailEventArgs();
			args.Type = typeof( Fenu );
			OnDataAvailable( args );
		}
	}

	public class ObjectDetailEventArgs : EventArgs
	{
		private Type _Type;
		public Type Type {
			get {
				return _Type;
			}
			set {
				_Type = value;
			}
		}

		private EscapeButtonState _Escape;
		public EscapeButtonState Escape {
			get {
				return _Escape;
			}
			set {
				_Escape = value;
			}
		}

		private NormalButtonState _Normal;
		public NormalButtonState Normal {
			get {
				return _Normal;
			}
			set {
				_Normal = value;
			}
		}

		private NextButtonState _Next;
		public NextButtonState Next {
			get {
				return _Next;
			}
			set {
				_Next = value;
			}
		}

	}
}
