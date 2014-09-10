using System.Collections.Generic;
using WeifenLuo.WinFormsUI.Docking;

using System.Xml.Serialization;
using System;
using System.Windows.Forms;

using Syntec.Module;
using System.Reflection;
using ModuleInterface;
using System.ComponentModel;

namespace Syntec.Windows
{
	public partial class DocumentsForm : DockContent, IModuleHost
	{
		private IModule instance;

		#region Event handlers

		public delegate void ShowPropertiesEventHandler( object control );
		public event ShowPropertiesEventHandler OnShowProperties;

		public delegate void SetPropertyGridEventHandler( AttributeCollection hidden, string[] browsable );
		public event SetPropertyGridEventHandler OnSetPropertyGrid;

		public delegate void ShowObjectsEventHandler( Control treeView );
		public event ShowObjectsEventHandler OnShowObjects;

		public delegate void ShowStatusInfoEventHandler( string text, int progress, bool marquee );
		public event ShowStatusInfoEventHandler OnShowStatusInfo;

		#endregion

		public DocumentsForm( string XMLPath, ShowPropertiesEventHandler OnShowProperties,
												SetPropertyGridEventHandler OnSetPropertyGrid,
												ShowObjectsEventHandler OnShowObjects,
												ShowStatusInfoEventHandler OnShowStatusInfo)
		{
			InitializeComponent();

			this.SuspendLayout();

			// Bind events for instance
			this.OnShowProperties += OnShowProperties;
			this.OnSetPropertyGrid += OnSetPropertyGrid;
			this.OnShowObjects += OnShowObjects;
			this.OnShowStatusInfo += OnShowStatusInfo;

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

		#endregion

		#endregion

		#region IModuleHost Members

		public void DrawOnCanvas( Control control )
		{
			this.Controls.Add( control );

			// Maintain last-in append instead of insert
			control.BringToFront();
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

		public void ShowObjects( Control treeView )
		{
			this.OnShowObjects( treeView );
		}

		public void ShowStatusInfo( string text, int progress, bool marquee )
		{
			this.OnShowStatusInfo( text, progress, marquee );
		}

		#endregion

		#region Form events

		private void DocumentsForm_FormClosing( object sender, FormClosingEventArgs e )
		{
			// TODO: Check if modification was made by tab
			if( this.TabText.Contains( "*" ) | true ) {
				DialogResult result = MessageBox.Show( "Would you like to save the modifications?",
														"Save before close",
														MessageBoxButtons.YesNo,
														MessageBoxIcon.Question );
				if( result == DialogResult.Yes )
					instance.Save();
			}

			instance.Close();

			// Disacard object browser
			this.ShowObjects( null );
		}

		#endregion
	}
}