using System;
using System.ComponentModel;

using WeifenLuo.WinFormsUI.Docking;

namespace Syntec.Windows
{
	public partial class PropertiesWindowForm : DockContent
	{
		public PropertiesWindowForm()
		{
			InitializeComponent();
		}

		public void SetSelectedObject( object Content )
		{
			PropertiesViewer.SelectedObject = Content;
			PropertiesViewer.Refresh();
		}

		public void SetHiddenAttributes( AttributeCollection hidden )
		{
			PropertiesViewer.HiddenAttributes = hidden;
		}

		public void SetBrowsableProperties( string[] browsable )
		{
			PropertiesViewer.BrowsableProperties = browsable;
		}
	}
}