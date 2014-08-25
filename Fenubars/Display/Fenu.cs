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

			// Register context menu, for disabled buttons
			this.FormSplitContainer.Panel2.ContextMenuStrip = ButtonContextMenu;
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
				NRB.ContextMenuStrip = ButtonContextMenu;
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

		#region Context menu item click event

		private void Create_ButtonContextMenuItem_Click(object sender, EventArgs e) {
			Control Child = FindChildOnScreen();
			IdentifyButtonObject( Child );
		}

		private void GoTo_ButtonContextMenuItem_Click(object sender, EventArgs e) {

		}

		private void Cut_ButtonContextMenuItem_Click(object sender, EventArgs e) {

		}

		private void Copy_ButtonContextMenuItem_Click(object sender, EventArgs e) {

		}

		private void Paste_ButtonContextMenuItem_Click(object sender, EventArgs e) {

		}

		private void Delete_ButtonContextMenuItem_Click(object sender, EventArgs e) {

		}

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
			IdentifyButtonObject( sender );
		}
		
		#endregion

		#region Local events

		private void FenuTitle_Click(object sender, EventArgs e) {
			ObjectDetailEventArgs args = new ObjectDetailEventArgs();
			args.Type = typeof( Fenu );
			OnDataAvailable( args );
		}

		private void FormSplitContainer_Panel2_Click(object sender, EventArgs e) {
			Control Child = FindChildOnScreen();
			if( Child == null )
				return;

			IdentifyButtonObject( Child );
		}

		private void ButtonContextMenu_Opening(object sender, CancelEventArgs e) {
			// Restore all the visible state of the menu items
			foreach( ToolStripItem TSI in ( sender as ContextMenuStrip ).Items )
				TSI.Visible = true;

			// Get child under the cursor
			Control Child = FindChildOnScreen();
			if( Child == null )
				return;

			if( Child.GetType() == typeof( NormalButton ) )
			{
				// Find out whether the child is has bind to state or not
				if( ( Child as Button ).FlatStyle == FlatStyle.Standard )
				{
					( sender as ContextMenuStrip ).Items[ "Create_ButtonContextMenuItem" ].Visible = false;
					( sender as ContextMenuStrip ).Items[ "GoTo_ButtonContextMenuItem" ].Visible = true;
				}
				else
				{
					( sender as ContextMenuStrip ).Items[ "Create_ButtonContextMenuItem" ].Visible = true;
					( sender as ContextMenuStrip ).Items[ "GoTo_ButtonContextMenuItem" ].Visible = false;
				}
			}

			e.Cancel = false;
		}

		#endregion

		#region Methods

		private Control FindChildOnScreen( ) {
			Point CursorPos = this.PointToClient( Cursor.Position );
			Control Child = this.FormSplitContainer.Panel2.GetChildAtPoint( CursorPos );
			return Child;
		}

		private void IdentifyButtonObject(object target){
			// Acquire button type and instantiate event args
			ObjectDetailEventArgs args = new ObjectDetailEventArgs();
			args.Type = target.GetType();

			// Ask to create new state or not
			if( ( (Button)target ).FlatStyle == FlatStyle.Popup )
				InstantiateState( args.Type, target );
			
			// Pass state of the button to event args
			if( args.Type == typeof( EscapeButton ) )
				args.Escape = _FenuContent.EscapeButton;
			else if( args.Type == typeof( NextButton ) )
				args.Next = _FenuContent.NextButton;
			else if( args.Type == typeof( NormalButton ) )
				args.Normal = _FenuContent.NormalButtonList.Find( delegate(FenuButtonState DummyState)
																	{
																		return ( target as NormalButton ).Name == DummyState.Name;
																	} );
			
			// Kick start the event 
			OnDataAvailable( args );
		}

		private bool InstantiateState(Type TargetType, object Target) { 

			// Return false if declined to instantaiate the button
			if( MessageBox.Show( "Would you like to create a button here?",
									"Create",
									MessageBoxButtons.YesNo,
									MessageBoxIcon.Question ) == DialogResult.No )
				return false;

			FenuButtonState FBS = new FenuButtonState();

			if( TargetType == typeof( EscapeButton ) )
			{
				
			}
			else if( TargetType == typeof( NextButton ) )
			{
			}
			else if( TargetType == typeof( NormalButton ) )
			{
				int Xpos = ( Target as Button ).Location.X;
				int Index = ( Xpos - 3 ) / 83;

				// Config the position
				FBS.Position = Index;

				// Add the FenuButtonState to properties container
				_FenuContent.NormalButtonList.Add( FBS );

				// Set state to newly create FenuButtonState
				( Target as NormalButton ).SetState( FBS );
			}

			return true;
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
