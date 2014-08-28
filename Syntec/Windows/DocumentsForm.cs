using System.Collections.Generic;
using WeifenLuo.WinFormsUI.Docking;

using System.Xml.Serialization;
using System;
using System.Windows.Forms;

using Syntec.Module;
using System.Reflection;
using ModuleInterface;

namespace Syntec.Windows
{
	public partial class DocumentsForm : DockContent
	{
		private IModule instance;

		public DocumentsForm(string XMLPath) {
			InitializeComponent();


			this.SuspendLayout();

			if( ( instance = ModuleManager.FindProcessor( XMLPath ) ) == null )
			{
				this.Dispose(); // Destroy this form if nothing applicable
				MessageBox.Show( "UNABLE TO LOAD" );
			}

			//// Already activated (when testing)
			//instance.Initialize( XMLPath );

			this.Controls.Add( instance.Open( "main" ) as Control );

			this.ResumeLayout();
		}
	}
}