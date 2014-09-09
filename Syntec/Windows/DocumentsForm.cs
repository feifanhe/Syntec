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

		#region Events

		public delegate void ShowObjectsEventHandler( Control treeView );
		public event ShowObjectsEventHandler ShowOnObjectsBrowser;

		public delegate void ShowPropertiesEventHandler( object control );
		public event ShowPropertiesEventHandler ShowOnPropertiesWindow;

		#endregion

		public DocumentsForm( string XMLPath )
		{
			InitializeComponent();

			this.SuspendLayout();

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

		public void Open( string name )
		{
			instance.Open( name );
		}

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

		#region IModuleHost Members

		public void DrawOnCanvas( Control control )
		{
			this.Controls.Add( control );

			// Maintain last-in append instead of insert
			control.BringToFront();
		}

		public void ShowProperties( object control )
		{
			MainForm.PropertiesWindow.SetSelectedObject( control );
		}

		public void SetPropertyGrid( AttributeCollection hidden, string[] browsable )
		{
			MainForm.PropertiesWindow.SetHiddenAttributes( hidden );
			MainForm.PropertiesWindow.SetBrowsableProperties( browsable );
		}

		public void ShowObjects( Control treeView )
		{
			//MainForm.ObjectBrowser.SetContents( treeView );
			this.ShowOnObjectsBrowser( treeView );
		}

		#endregion

		
	}
}