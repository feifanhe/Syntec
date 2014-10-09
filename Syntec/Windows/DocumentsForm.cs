using System.Collections.Generic;
using WeifenLuo.WinFormsUI.Docking;

using System.Xml.Serialization;
using System;
using System.Windows.Forms;

using Syntec.Module;
using System.Reflection;
using ModuleInterface;
using System.ComponentModel;
using System.Drawing;
using System.Diagnostics;

namespace Syntec.Windows
{
	public partial class DocumentsForm : DockContent, IModuleHost
	{
		private IModule instance;

		// Temporary store the tree view, for document switching
		private TreeView currentTreeView = null;

		public string XMLPath;

		#region Event handlers

		public delegate void ShowPropertiesEventHandler( object control );
		public event ShowPropertiesEventHandler OnShowProperties;

		public delegate void SetPropertyGridEventHandler( AttributeCollection hidden, string[] browsable );
		public event SetPropertyGridEventHandler OnSetPropertyGrid;

		public delegate void ShowObjectsEventHandler( Control treeView );
		public event ShowObjectsEventHandler OnShowObjects;

		public delegate void ShowStatusInfoEventHandler( string text, int progress, bool marquee );
		public event ShowStatusInfoEventHandler OnShowStatusInfo;

		public delegate string GetResourceEventHandler( string Path, string ID, string Language );
		public event GetResourceEventHandler OnGetResource;

		public delegate void FindResultsEventHandler( DocumentsForm host, SearchResult[] results );
		public event FindResultsEventHandler OnFindResults;

		#endregion

		public DocumentsForm( string XMLPath, ShowPropertiesEventHandler OnShowProperties,
												SetPropertyGridEventHandler OnSetPropertyGrid,
												ShowObjectsEventHandler OnShowObjects,
												ShowStatusInfoEventHandler OnShowStatusInfo,
												GetResourceEventHandler OnGetResource,
												FindResultsEventHandler OnFindResults )
		{
			InitializeComponent();

			this.SuspendLayout();

			this.XMLPath = XMLPath;

			// Bind events for instance
			this.OnShowProperties += OnShowProperties;
			this.OnSetPropertyGrid += OnSetPropertyGrid;
			this.OnShowObjects += OnShowObjects;
			this.OnShowStatusInfo += OnShowStatusInfo;
			this.OnGetResource += OnGetResource;
			this.OnFindResults += OnFindResults;

			if( ( instance = ModuleManager.FindProcessor( XMLPath ) ) == null ) {
				// Destroy this form if nothing applicable
				this.Dispose();
				MessageBox.Show( "No adequate module to load this XML file.",
									"Unable to load",
									MessageBoxButtons.OK,
									MessageBoxIcon.Exclamation );
			}
			else {
				//// Called when testing whether this module can process the XML or not
				//instance.Initialize( XMLPath );

				// Set target host
				instance.Host = this;
				instance.Open();

				this.ResumeLayout();
			}
		}

		#region Methods for IDE to call

		#region File

		public void Open( string name )
		{
			instance.Open( name );
		}

		public void Save()
		{
			instance.Save();
		}

		#endregion

		#region Edit

		public void Cut()
		{
			instance.Cut();
		}

		public void Copy()
		{
			instance.Copy();
		}

		public void Paste()
		{
			instance.Paste();
		}

		public void Delete()
		{
			instance.Delete();
		}

		public void SearchForIDUsers( string[] IDs )
		{
			SearchResult[] sr = instance.SearchForIDUsers( IDs );
			OnFindResults( this, sr );
		}

		#endregion

		#region Object Tree

		public void RefreshObject()
		{
			instance.RefreshObjects();
		}

		#endregion

		#endregion

		#region IModuleHost Members

		public void DrawOnCanvas( Control control )
		{
			this.SuspendLayout();

			this.Controls.Add( control );

			// Maintain last-in append instead of insert
			control.BringToFront();

			this.ResumeLayout();
		}

		public Control FindControlByName( string name )
		{
			return this.Controls[ name ];
		}

		public Control FindFocusedControl()
		{
			return FindFocusedControl( this );
		}

		private Control FindFocusedControl( Control control )
		{
			ContainerControl container = control as ContainerControl;
			return ( null != container
				? FindFocusedControl( container.ActiveControl )
				: control );
		}

		public void ShowProperties( object control )
		{
			this.OnShowProperties( control );
		}

		public void SetPropertyGrid( AttributeCollection hidden, string[] browsable )
		{
			this.OnSetPropertyGrid( hidden, browsable );
		}

		//public void ShowObjects( Control treeView )
		public void ShowObjects( Control treeView )
		{
			currentTreeView = treeView as TreeView;
			this.OnShowObjects( currentTreeView );
		}

		public void ShowStatusInfo( string text, int progress, bool marquee )
		{
			this.OnShowStatusInfo( text, progress, marquee );
		}

		public void Modified( bool modified )
		{
			if( modified ) {
				if( !this.TabText.EndsWith( "*" ) ) {
					this.TabText = this.TabText + "*";
				}
			}
			else {
				if( this.TabText.EndsWith( "*" ) ) {
					this.TabText = this.TabText.Substring( 0, this.TabText.Length - 1 );
				}
			}
		}

		public string GetResource( string Path, string ID, string Language )
		{
			if( this.OnGetResource != null ) {
				return this.OnGetResource( Path, ID, Language );
			}
			else {
				return string.Empty;
			}
		}

		#endregion

		#region Form events

		private void DocumentsForm_FormClosing( object sender, FormClosingEventArgs e )
		{
			DialogResult result;
			// TODO: Check if modification was made by tab
			if( this.TabText.Contains( "*" ) ) { // | true ) {
				result = MessageBox.Show( "Would you like to save the modifications?",
											"Save before close",
											MessageBoxButtons.YesNoCancel,
											MessageBoxIcon.Question );
				if( result == DialogResult.Yes )
					instance.Save();
				else if( result == DialogResult.No ) {
					instance.Close();

					// Discard object browser
					this.ShowProperties( null );
					this.SetPropertyGrid( null, null );
					this.ShowObjects( null );
				}
				else {
					// Cancel close operation
					e.Cancel = true;
				}
			}

		}

		#endregion

		#region Context Menu Strip

		private void Save_ToolStripMenuItem_Click( object sender, EventArgs e )
		{
			instance.Save();
		}

		private void OpenFolder_ToolStripMenuItem_Click( object sender, EventArgs e )
		{
			Process.Start( "explorer.exe", string.Concat( "/Select, ", this.XMLPath ) );
		}

		private void CopyFullPath_ToolStripMenuItem_Click( object sender, EventArgs e )
		{
			Clipboard.SetText( this.XMLPath );
		}

		private void Close_ToolStripMenuItem_Click( object sender, EventArgs e )
		{
			this.Close();
		}

		#endregion

		private void DocumentsForm_Activated( object sender, EventArgs e )
		{
			this.ShowObjects( currentTreeView );
		}


	}
}