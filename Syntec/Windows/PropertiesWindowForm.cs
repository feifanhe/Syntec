using WeifenLuo.WinFormsUI.Docking;

namespace Syntec.Windows
{
	public partial class PropertiesWindowForm : DockContent
	{
		public PropertiesWindowForm( ) {
			InitializeComponent();
		}

		public void SetSelectedObject(object Content) {
			PropertiesViewer.SelectedObject = Content;
		}
	}
}