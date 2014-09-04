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

		public DocumentsForm( string XMLPath )
		{
			InitializeComponent();

			this.SuspendLayout();

			if( ( instance = ModuleManager.FindProcessor( XMLPath ) ) == null ) {
				this.Dispose(); // Destroy this form if nothing applicable
				MessageBox.Show( "No adequate module to load this XML file.",
									"Unable to load",
									MessageBoxButtons.OK,
									MessageBoxIcon.Exclamation);
			}
			else {
				//// Already activated (when testing)
				//instance.Initialize( XMLPath );

				// Set target host
				instance.Host = this;

				instance.Open();

				//// Execute
				//instance.Open( "main" );
				//instance.Open( "About" );

				//this.Controls.Add( instance.Open( "main" ) as Control );

				this.ResumeLayout();
			}
		}

		public void Open( string name )
		{
			instance.Open( name );
		}

		#region IModuleHost Members

		public void DrawOnCanvas( Control control )
		{
			this.Controls.Add( control );

			// Maintain last in append instead of insert
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

		public void PopulateObjects( Control treeView )
		{
			MainForm.ObjectBrowser.SetContents( treeView );
		}

		#endregion
	}
}