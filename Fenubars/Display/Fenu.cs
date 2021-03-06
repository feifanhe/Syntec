using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Fenubars.Buttons;
using Fenubars.XML;
using Fenubars.Editor;
using ModuleInterface;

namespace Fenubars.Display
{
	public partial class Fenu : UserControl
	{
		private XMLGlobalState globalFenuState;
		private FenuState _FenuContent;
		private Point CursorPosition;

		// Register the buttons this fenu owned
		private int normalButtonCount = -1;

		// Store the image of this fenu's predecessors
		private FenuButtonState[] originalState;
		private List<FenuButtonState> image;
		private byte[] status;

		public string TitleText
		{
			get
			{
				if( this.FenuTitle.Text == null ) {
					return string.Empty;
				}
				return this.FenuTitle.Text;
			}
			set
			{
				this.FenuTitle.Text = value;
			}
		}

		#region Event handlers

		public delegate void DataAvailableEventHandler( Type type, FenuButtonState data );
		public event DataAvailableEventHandler OnDataAvailable;

		public delegate Fenu LinkageEventHandler( string FenuName );
		public event LinkageEventHandler Linkage;

		public delegate void FenuModifiedHandler();
		public event FenuModifiedHandler Modified;

		public delegate string GetResourceEventHandler( string ID );
		public event GetResourceEventHandler OnGetResource;

		#endregion

		public Fenu( XMLGlobalState globalFenuState, FenuState AssignedFenuContent, int normalButtonCount )
		{
			InitializeComponent();

			this.globalFenuState = globalFenuState;
			this._FenuContent = AssignedFenuContent;
			this.normalButtonCount = normalButtonCount;

			// Overwrite title bar splitter distance
			TitleBarSplitterContainer.SplitterDistance = TitleBarSplitterContainer.Width - 25;

			// Set default docking position
			this.Dock = DockStyle.Top;

			// Write system name
			this.Name = AssignedFenuContent.Name;

			// Register context menu, for disabled buttons
			this.FormSplitContainer.Panel2.ContextMenuStrip = ButtonContextMenu;
		}

		public void PopulateButtons()
		{
			FormSplitContainer.Panel2.Controls.Clear();

			this.originalState = new FenuButtonState[ this.NormalButtonCount + 2 ];

			// TODO: Modify the title to call-pathway
			FenuTitle.Text = _FenuContent.Name;

			// Add EscapeButton and NextButton button
			EscapeButton EB = new EscapeButton();
			if( _FenuContent.EscapeButton == null ) {
				_FenuContent.EscapeButton = new FenuButtonState();
			}
			this.originalState[ 0 ] = _FenuContent.EscapeButton;
			EB.SetState( this.globalFenuState, _FenuContent.EscapeButton );
			EB.MouseDown += new MouseEventHandler( FenuButton_MouseDown );
			EB.Modified += new EscapeButton.ButtonModifiedHandler( SetFenuModified );
			EB.KeyDown += new KeyEventHandler( FenuButton_KeyDown );
			EB.PaintComponent( FormSplitContainer.Panel2.Controls, new Point( 3, 3 ) );

			NextButton NB = new NextButton();
			if( _FenuContent.NextButton == null ) {
				_FenuContent.NextButton = new FenuButtonState();
			}
			this.originalState[ this.originalState.Length - 1 ] = _FenuContent.NextButton;
			NB.SetState( this.globalFenuState, _FenuContent.NextButton );
			NB.MouseDown += new MouseEventHandler( FenuButton_MouseDown );
			NB.Modified += new NextButton.ButtonModifiedHandler( SetFenuModified );
			NB.KeyDown += new KeyEventHandler( FenuButton_KeyDown );
			NB.PaintComponent( FormSplitContainer.Panel2.Controls, new Point( 3 + 80 * ( normalButtonCount + 1 ), 3 ) );

			// Add normal buttons
			for( int i = 1; i <= normalButtonCount; i++ ) {
				NormalButton NRB = new NormalButton( i );
				NRB.MouseDown += new MouseEventHandler( FenuButton_MouseDown );
				NRB.Modified += new NormalButton.ButtonModifiedHandler( SetFenuModified );
				NRB.KeyDown += new KeyEventHandler( FenuButton_KeyDown );
				NRB.OnGetResource += new NormalButton.GetResourceEventHandler( GetResource );
				NRB.ContextMenuStrip = ButtonContextMenu;

				FenuButtonState FBS = _FenuContent.NormalButtonList.Find(
					delegate( FenuButtonState DummyState )
					{
						return DummyState.Position == i;
					} );

				this.originalState[ i ] = FBS;
				NRB.SetState( this.globalFenuState, FBS );
				NRB.PaintComponent( FormSplitContainer.Panel2.Controls );
			}
		}

		public void SaveImage( List<FenuButtonState> image, byte[] status )
		{
			this.image = image;
			this.status = status;

			// This should never occur
			if( this.image.Count != this.status.Length )
				throw new IndexOutOfRangeException( "Fenu images and their respective status mismatch." );
		}

		public void UpdateFromOriginalState()
		{
			// Cycle through all the buttons in original fenu
			foreach( Control control in FormSplitContainer.Panel2.Controls ) {
				// Filter for specific button
				if( control is EscapeButton ) {

				}
				else if( control is NormalButton ) {
					NormalButton button = control as NormalButton;

					bool binded = ( button.DataBindings.Count != 0 );
					int index = ButtonPosition( button.Location );

					// Button not occupied, then bind info to it
					//if( !binded ) {
					button.SetState( this.globalFenuState, originalState[ index ], false );
					//}

					// Set font
					button.Font = GenerateFontByStatus( 0x01, binded, button.Font );
				}
				else if( control is NextButton ) {

				}
			}
		}

		public void UpdateFromImage()
		{
			// Cycle through all the buttons in original fenu
			foreach( Control control in FormSplitContainer.Panel2.Controls ) {
				// Filter for specific button
				if( control is EscapeButton ) {

				}
				else if( control is NormalButton ) {
					NormalButton button = control as NormalButton;


					bool binded = ( button.DataBindings.Count != 0 );
					int index = ButtonPosition( button.Location );

					// Button not occupied, then bind info to it
					if( !binded ) {
						button.SetState( this.globalFenuState, this.image[ index ], true );
					}

					// Set font
					//button.Font = GenerateFontByStatus( status[ index ], binded, button.Font );
				}
				else if( control is NextButton ) {

				}
			}
		}

		#region Titlebar event

		private void DisplayMode_CheckBox_CheckedChanged( object sender, EventArgs e )
		{
			if( DisplayMode_CheckBox.Checked ) {
				UpdateFromImage();
			}
			else {
				PopulateButtons();
			}
		}

		private void CloseFenu_MouseEnter( object sender, EventArgs e )
		{
			this.CloseFenu.BackColor = SystemColors.Highlight;
		}

		private void CloseFenu_MouseLeave( object sender, EventArgs e )
		{
			this.CloseFenu.BackColor = SystemColors.ActiveCaption;
		}

		private void CloseFenu_Click( object sender, EventArgs e )
		{
			this.Dispose();
		}

		#endregion

		#region Button context menu item click event

		private void Create_ButtonContextMenuItem_Click( object sender, EventArgs e )
		{
			IdentifyButtonObject( FindChildOnScreen( CursorPosition ) );
		}

		private void GoTo_ButtonContextMenuItem_Click( object sender, EventArgs e )
		{
			GotoLink( FindChildOnScreen( CursorPosition ) );
		}

		private void Cut_ButtonContextMenuItem_Click( object sender, EventArgs e )
		{
			Cut( FindChildOnScreen( CursorPosition ) );
		}

		private void Copy_ButtonContextMenuItem_Click( object sender, EventArgs e )
		{
			Copy( FindChildOnScreen( CursorPosition ) );
		}

		private void Paste_ButtonContextMenuItem_Click( object sender, EventArgs e )
		{
			Paste( FindChildOnScreen( CursorPosition ) );
		}

		private void Delete_ButtonContextMenuItem_Click( object sender, EventArgs e )
		{
			Delete( FindChildOnScreen( CursorPosition ) );
		}

		#endregion

		#region Fenu context menu item click event

		private void Refresh_FenuContextMenuItem_Click( object sender, EventArgs e )
		{
			// TODO: Regenerate image
		}

		private void Close_FenuContextMenuItem_Click( object sender, EventArgs e )
		{
			// TODO: Need to refresh object tree
			this.CloseFenu_Click( null, null );
		}

		private void Delete_FenuContextMenuItem_Click( object sender, EventArgs e )
		{

		}

		#endregion

		#region Event that will pass to parent

		private void FenuButton_MouseDown( object sender, MouseEventArgs e )
		{
			if( Control.ModifierKeys == Keys.Shift ) {
				if( e.Button == MouseButtons.Left ) {
					GotoLink( sender );
				}
			}
			else {
				switch( e.Button ) {
					case MouseButtons.Left:
						IdentifyButtonObject( sender );
						break;
					case MouseButtons.Right:
						CursorPosition = this.PointToClient( Cursor.Position );
						Console.WriteLine( "REGISTER AT: " + CursorPosition );
						break;
				}
			}
		}

		private void FenuButton_KeyDown( object sender, KeyEventArgs e )
		{
			if( e.KeyCode == Keys.Space ) {
				GotoLink( sender );
			}
		}

		private void SetFenuModified()
		{
			if( Modified != null )
				Modified();
		}

		private string GetResource( string ID )
		{
			return this.OnGetResource( ID );
		}

		#endregion

		#region Local events

		private void FenuTitle_Click( object sender, EventArgs e )
		{
			OnDataAvailable( typeof( Fenu ), null );
		}

		// For disabled buttons, when button is enabled, event is catch by FenuButton_MouseDown
		private void FormSplitContainer_Panel2_MouseDown( object sender, MouseEventArgs e )
		{
			switch( e.Button ) {
				case MouseButtons.Left:
					Control Child = FindChildOnScreen();
					if( Child == null ) {
						OnDataAvailable( typeof( Fenu ), null );
						return;
					}
					IdentifyButtonObject( Child );
					break;
				case MouseButtons.Right:
					CursorPosition = this.PointToClient( Cursor.Position );
					Console.WriteLine( "REGISTER AT: " + CursorPosition );
					break;
			}
		}

		private void ButtonContextMenu_Opening( object sender, CancelEventArgs e )
		{
			ContextMenuStrip Menu = sender as ContextMenuStrip;

			// Restore all the visible state of the menu items
			foreach( ToolStripItem TSI in ( sender as ContextMenuStrip ).Items )
				TSI.Visible = true;
			Menu.Items[ "Paste_ButtonContextMenuItem" ].Enabled = true;

			// Get child under the cursor
			Control Child = FindChildOnScreen();
			if( Child == null ) {
				e.Cancel = true;
				return;
			}

			if( Child.GetType() == typeof( NormalButton ) ) {

				if( !ClipBoardManager<FenuButtonState>.Available() ) {
					Menu.Items[ "Paste_ButtonContextMenuItem" ].Enabled = false;
				}

				// Find out whether the child has bind to state or not
				if( ( Child as Button ).FlatStyle == FlatStyle.Standard ) {
					Menu.Items[ "Create_ButtonContextMenuItem" ].Visible = false;
				}
				else {
					// blank button
					Menu.Items[ "GoTo_ButtonContextMenuItem" ].Visible = false;
					Menu.Items[ "Cut_ButtonContextMenuItem" ].Visible = false;
					Menu.Items[ "Copy_ButtonContextMenuItem" ].Visible = false;
					Menu.Items[ "ButtonContextMenu_Separator_2" ].Visible = false;
					Menu.Items[ "Delete_ButtonContextMenuItem" ].Visible = false;
				}
			}
			else if( Child.GetType() == typeof( EscapeButton ) ) {
				Menu.Items[ "GoTo_ButtonContextMenuItem" ].Visible = false;
				Menu.Items[ "ButtonContextMenu_Separator_1" ].Visible = false;
				Menu.Items[ "Cut_ButtonContextMenuItem" ].Visible = false;
				Menu.Items[ "Copy_ButtonContextMenuItem" ].Visible = false;
				Menu.Items[ "Paste_ButtonContextMenuItem" ].Visible = false;
				Menu.Items[ "ButtonContextMenu_Separator_2" ].Visible = false;

				if( _FenuContent.EscapeButton != null ) {
					Menu.Items[ "Create_ButtonContextMenuItem" ].Visible = false;
				}
				else {
					Menu.Items[ "Delete_ButtonContextMenuItem" ].Visible = false;
				}
			}
			else if( Child.GetType() == typeof( NextButton ) ) {
				Menu.Items[ "ButtonContextMenu_Separator_1" ].Visible = false;
				Menu.Items[ "Cut_ButtonContextMenuItem" ].Visible = false;
				Menu.Items[ "Copy_ButtonContextMenuItem" ].Visible = false;
				Menu.Items[ "Paste_ButtonContextMenuItem" ].Visible = false;

				if( _FenuContent.NextButton != null ) {
					Menu.Items[ "Create_ButtonContextMenuItem" ].Visible = false;
				}
				else {
					Menu.Items[ "ButtonContextMenu_Separator_2" ].Visible = false;
					Menu.Items[ "Delete_ButtonContextMenuItem" ].Visible = false;
				}
			}
			else {
				e.Cancel = true;
			}

			e.Cancel = false;
		}

		#endregion

		#region Methods

		#region Cut, Copy, Paste and Delete

		internal void Cut( Control target )
		{
			Copy( target );
			Delete( target );
		}

		internal void Copy( Control target )
		{
			if( target == null )
				return;

			// Find the properties container of the target
			FenuButtonState FBS = _FenuContent.NormalButtonList.Find(
				delegate( FenuButtonState DummyState )
				{
					return ButtonPosition( ( target as NormalButton ).Location ) == DummyState.Position;
				} );
			// Copy the object to clipboard
			ClipBoardManager<FenuButtonState>.CopyToClipboard( FBS );

			//// Debug function, check if the button is serializable
			//ClipBoardManager<FenuButtonState>.IsSerializable( FBS );
		}

		internal void Paste( Control target )
		{
			// Check if the targeted control is applicable for clipboard data
			if( target == null )
				return;

			// Acquire deserialized data from clip board manager
			FenuButtonState FBS = ClipBoardManager<FenuButtonState>.GetFromClipboard();

			// Config the position
			FBS.Position = ButtonPosition( ( target as Button ).Location );
			//FBS.Name = "F" + FBS.Position.ToString();

			// Add the FenuButtonState to properties container, search before append
			int ListIndex = _FenuContent.NormalButtonList.FindIndex(
				delegate( FenuButtonState DummyState )
				{
					return DummyState.Position == FBS.Position;
				} );

			if( ListIndex == -1 )
				_FenuContent.NormalButtonList.Add( FBS );
			else
				_FenuContent.NormalButtonList[ ListIndex ] = FBS;

			// Assign the binding
			( target as NormalButton ).SetState( this.globalFenuState, FBS );

			this.SetFenuModified();
		}

		internal void Delete( Control target )
		{
			if( target == null )
				return;

			ObliterateState( target );

			if( DisplayMode_CheckBox.Checked ) {
				this.UpdateFromImage();
			}

			this.SetFenuModified();
		}

		#endregion

		// Overload for realtime cursor position (normal left click operation)
		private Control FindChildOnScreen()
		{
			Point CursorPos = this.PointToClient( Cursor.Position );
			return FindChildOnScreen( CursorPos );
		}

		private Control FindChildOnScreen( Point Position )
		{
			Point newPos = new Point( Position.X, Position.Y - 25 );
			return this.FormSplitContainer.Panel2.GetChildAtPoint( newPos );
		}

		private void IdentifyButtonObject( object target )
		{
			// Acquire button type
			Type type = target.GetType();

			// Ask to create new state or not
			if( ( (Button)target ).FlatStyle == FlatStyle.Popup )
				if( !InstantiateState( target ) )
					return; // Don't show property

			// Pass state of the button to event args
			FenuButtonState storage = null;
			if( type == typeof( EscapeButton ) )
				storage = _FenuContent.EscapeButton;
			else if( type == typeof( NextButton ) )
				storage = _FenuContent.NextButton;
			else if( type == typeof( NormalButton ) )
				storage = _FenuContent.NormalButtonList.Find(
					delegate( FenuButtonState DummyState )
					{
						return ButtonPosition( ( target as NormalButton ).Location ) == DummyState.Position;
					} );

			// Kick start the event 
			OnDataAvailable( type, storage );
		}

		private int ButtonPosition( Point location )
		{
			return ( location.X - 3 ) / 80;
		}

		private bool InstantiateState( object Target )
		{
			return InstantiateState( Target, true );
		}

		private bool InstantiateState( object Target, bool AskToCreate )
		{
			Type TargetType = Target.GetType();

			// Return false if declined to instantaiate the button
			if( MessageBox.Show( "Would you like to create a button here?",
									"Create",
									MessageBoxButtons.YesNo,
									MessageBoxIcon.Question ) == DialogResult.No | !AskToCreate )
				return false;

			FenuButtonState FBS = new FenuButtonState();

			if( TargetType == typeof( EscapeButton ) ) {
			}
			else if( TargetType == typeof( NextButton ) ) {
			}
			else if( TargetType == typeof( NormalButton ) ) {
				int Index = ButtonPosition( ( Target as Button ).Location );

				// Config the position
				FBS.Position = Index;

				_FenuContent.NormalButtonList.Add( FBS );

				// Set state to newly create FenuButtonState
				( Target as NormalButton ).SetState( this.globalFenuState, FBS );
			}

			this.SetFenuModified();

			return true;
		}

		private bool ObliterateState( object target )
		{
			Type TargetType = target.GetType();

			if( TargetType == typeof( EscapeButton ) ) {
			}
			else if( TargetType == typeof( NextButton ) ) {
			}
			else if( TargetType == typeof( NormalButton ) ) {
				// Find the target button
				int Index = _FenuContent.NormalButtonList.FindIndex(
					delegate( FenuButtonState DummyState )
					{
						return ButtonPosition( ( target as NormalButton ).Location ) == DummyState.Position;
					} );

				// Restore state to null
				( target as NormalButton ).SetState( null, null );

				// Remove state from list
				_FenuContent.NormalButtonList.RemoveAt( Index );
			}

			return true;
		}

		private void GotoLink( object Button )
		{
			Type ButtonType = Button.GetType();

			FenuButtonState FBS;

			if( ButtonType == typeof( EscapeButton ) )
				FBS = _FenuContent.EscapeButton;
			else if( ButtonType == typeof( NextButton ) )
				FBS = _FenuContent.NextButton;
			else if( ButtonType == typeof( NormalButton ) )
				FBS = _FenuContent.NormalButtonList.Find(
					delegate( FenuButtonState DummyState )
					{
						return ButtonPosition( ( Button as NormalButton ).Location ) == DummyState.Position;
					} );
			else {
				return;
			}

			// Open the link associated with this fenu
			if( FBS.Link == null ) {
				MessageBox.Show( "Linked fenu doesn't exist.",
									"Fenu not found",
									MessageBoxButtons.OK,
									MessageBoxIcon.Exclamation );
				return;
			}

			Fenu fenu = Linkage.Invoke( FBS.Link );
			// Show the information of Caller in title
			if( fenu == null )
				return;
			fenu.FenuTitle.Text = fenu._FenuContent.Name + " <- " + this._FenuContent.Name + " : F" + FBS.Position;

		}

		private Font GenerateFontByStatus( byte status, bool binded, Font original )
		{
			FontStyle style = FontStyle.Regular;

			// Bold: overwriteen
			// Italic: foreign button, not covered
			// Bold-Italic: covered foreign button
			// Normal: Original not covered

			bool bold = false;
			bool italic = false;

			if( ( status >> 1 ) != 0 )
				italic = true;

			if( ( status >> 2 ) != 0 )
				bold = true;

			if( binded & italic ) {
				italic = false;
				bold = true;
			}

			italic = false;

			// Boolean state to font style
			if( bold & italic )
				style = FontStyle.Bold | FontStyle.Italic;
			else if( bold & !italic )
				style = FontStyle.Bold;
			else if( !bold & italic )
				style = FontStyle.Italic;
			else
				style = FontStyle.Regular;

			return new Font( original, style );
		}

		public int NormalButtonCount
		{
			get
			{
				return normalButtonCount;
			}
		}

		#endregion


	}
}
