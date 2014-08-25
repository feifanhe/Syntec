using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
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

			// Add EscapeButton and NextButton button
			EscapeButton EB = new EscapeButton( _FenuContent.EscapeButton );
			EB.PaintComponent( FormSplitContainer.Panel2.Controls, new Point( 3, 3 ) );
			EB.Click += new EventHandler( FenuButton_Click );

			NextButton NB = new NextButton( _FenuContent.NextButton );
			NB.PaintComponent( FormSplitContainer.Panel2.Controls, new Point( 3 + 83 * ( buttons + 1 ), 3 ) );
			NB.Click += new EventHandler( FenuButton_Click );


			// Add normal buttons
			// TODO: Button amounts should varies
			for( int i = 1; i <= buttons; i++ )
			{
				// TODO: Add double click
				NormalButton NRB = new NormalButton( i );
				NRB.Click += new EventHandler( FenuButton_Click );
				try
				{
					FenuButtonState FBS = _FenuContent.NormalButtonList.Find( delegate(FenuButtonState DummyState)
																				{
																					return DummyState.Position == i;
																				} );
					NRB.SetState( FBS );
				}
				catch( ArgumentNullException )
				{
				}
				finally
				{
					NRB.PaintComponent( FormSplitContainer.Panel2.Controls );
				}
			}

			//foreach( FenuButtonState nbs in _FenuContent.NormalButtonList )
			//{
			//    string TargetName = "F" + nbs.Position.ToString();
			//    Control[] ctrlS = this.FormSplitContainer.Panel2.Controls.Find( TargetName, false );
			//    try
			//    {
			//        if( ctrlS.Length == 0 )
			//        {
			//            throw new Exception( "Cannot find control named [" + TargetName + "]" );
			//        }
			//        NormalButton btn = ctrlS[ 0 ] as NormalButton;
			//        btn.SetState( nbs );
			//    }
			//    catch( Exception e )
			//    {
			//        MessageBox.Show( e.Message );
			//    }
			//}
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

		#region Event that is passed to parent

		public event EventHandler<ObjectDetailEventArgs> DataAvailable;
		protected virtual void OnDataAvailable(ObjectDetailEventArgs e) {
			EventHandler<ObjectDetailEventArgs> eh = DataAvailable;
			if( eh != null )
			{
				eh( this, e );
			}
		}
		
		private void FenuButton_Click(object sender, EventArgs e) {
			IdentifyObject( sender );
		}
		
		#endregion

		#region Local events

		private void FenuTitle_Click(object sender, EventArgs e) {
			ObjectDetailEventArgs args = new ObjectDetailEventArgs();
			args.Type = typeof( Fenu );
			OnDataAvailable( args );
		}

		private void FormSplitContainer_Panel2_Click(object sender, EventArgs e) {
			Point CursorPos = this.PointToClient( Cursor.Position );
			Control Child = this.FormSplitContainer.Panel2.GetChildAtPoint( CursorPos );
			if( Child == null )
				return;

			IdentifyObject( Child );
		}

		#endregion

		#region Methods

		private void IdentifyObject(object target){
			ObjectDetailEventArgs args = new ObjectDetailEventArgs();
			args.Type = target.GetType();

			if( args.Type == typeof( EscapeButton ) )
				args.Escape = _FenuContent.EscapeButton;
			else if( args.Type == typeof( NextButton ) )
				args.Next = _FenuContent.NextButton;
			else if( args.Type == typeof( NormalButton ) )
				args.Normal = _FenuContent.NormalButtonList.Find( delegate(FenuButtonState DummyState)
																	{
																		return ( target as NormalButton ).Name == DummyState.Name;
																	} );
			OnDataAvailable( args );
		}

		#endregion
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

		private FenuButtonState _Escape;
		public FenuButtonState Escape {
			get {
				return _Escape;
			}
			set {
				_Escape = value;
			}
		}

		private FenuButtonState _Normal;
		public FenuButtonState Normal {
			get {
				return _Normal;
			}
			set {
				_Normal = value;
			}
		}

		private FenuButtonState _Next;
		public FenuButtonState Next {
			get {
				return _Next;
			}
			set {
				_Next = value;
			}
		}

	}
}
