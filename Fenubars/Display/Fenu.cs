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
		private Point CursorPosition;

		public Fenu(FenuState AssignedFenuContent) {
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
			EB.MouseDown += new MouseEventHandler( FenuButton_MouseDown );

			NextButton NB = new NextButton( _FenuContent.NextButton );
			NB.PaintComponent( FormSplitContainer.Panel2.Controls, new Point( 3 + 83 * ( buttons + 1 ), 3 ) );
			NB.MouseDown += new MouseEventHandler( FenuButton_MouseDown );


			// Add normal buttons
			// TODO: Button amounts should varies
			for( int i = 1; i <= buttons; i++ )
			{
				// TODO: Add double click
				NormalButton NRB = new NormalButton( i );
				NRB.MouseDown += new MouseEventHandler( FenuButton_MouseDown );
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

		#endregion

		#region Context menu item click event

		private void Create_ButtonContextMenuItem_Click(object sender, EventArgs e) {
			IdentifyButtonObject( FindChildOnScreen( CursorPosition ) );
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
			ObliterateState( FindChildOnScreen( CursorPosition ) );
		}

		#endregion

		#region Event that will pass to parent

		public event EventHandler<ObjectDetailEventArgs> DataAvailable;
		protected virtual void OnDataAvailable(ObjectDetailEventArgs e) {
			EventHandler<ObjectDetailEventArgs> eh = DataAvailable;
			if( eh != null )
			{
				eh( this, e );
			}
		}

		private void FenuButton_MouseDown(object sender, MouseEventArgs e) {

			switch( e.Button )
			{
				case MouseButtons.Left:
					IdentifyButtonObject( sender );
					break;
				case MouseButtons.Right:
					CursorPosition = this.PointToClient( Cursor.Position );
					Console.WriteLine( "REGISTER AT: " + CursorPosition );
					break;
			}
		}

		#endregion

		#region Local events

		private void FenuTitle_Click(object sender, EventArgs e) {
			ObjectDetailEventArgs args = new ObjectDetailEventArgs();
			args.Type = typeof( Fenu );
			OnDataAvailable( args );
		}

		// For disabled buttons, when button is enabled, event is catch by FenuButton_MouseDown
		private void FormSplitContainer_Panel2_MouseDown(object sender, MouseEventArgs e) {
			switch( e.Button )
			{
				case MouseButtons.Left:
					Control Child = FindChildOnScreen();
					if( Child == null )
						return;
					IdentifyButtonObject( Child );
					break;
				case MouseButtons.Right:
					CursorPosition = this.PointToClient( Cursor.Position );
					Console.WriteLine( "REGISTER AT: " + CursorPosition );
					break;
			}
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
				// Find out whether the child has bind to state or not
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

		// Overload for realtime cursor position (normal left click operation)
		private Control FindChildOnScreen( ) {
			Point CursorPos = this.PointToClient( Cursor.Position );
			return FindChildOnScreen( CursorPos );
		}

		private Control FindChildOnScreen(Point Position) {
			return this.FormSplitContainer.Panel2.GetChildAtPoint( Position );
		}

		private void IdentifyButtonObject(object target) {
			// Acquire button type and instantiate event args
			ObjectDetailEventArgs args = new ObjectDetailEventArgs();
			args.Type = target.GetType();

			// Ask to create new state or not
			if( ( (Button)target ).FlatStyle == FlatStyle.Popup )
				InstantiateState( target );

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

		private bool InstantiateState(object Target) {
			Type TargetType = Target.GetType();

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

		private bool ObliterateState(object Target) {
			Type TargetType = Target.GetType();

			// Return false if declined to instantaiate the button
			if( MessageBox.Show( "Are you sure you want to remove the button?",
									"Delete",
									MessageBoxButtons.YesNo,
									MessageBoxIcon.Question ) == DialogResult.No )
				return false;

			if( TargetType == typeof( EscapeButton ) )
			{

			}
			else if( TargetType == typeof( NextButton ) )
			{
			}
			else if( TargetType == typeof( NormalButton ) )
			{
				// Find the target button
				int Index = _FenuContent.NormalButtonList.FindIndex( delegate(FenuButtonState DummyState)
																		{
																			return ( Target as Button ).Name == DummyState.Name;
																		} );

				// Restore state to null
				( Target as NormalButton ).SetState( null );

				// Remove state from list
				_FenuContent.NormalButtonList.RemoveAt( Index );

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
