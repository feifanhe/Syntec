using WeifenLuo.WinFormsUI.Docking;

using Fenubars;

namespace Syntec.Windows
{
	public partial class DocumentsForm : DockContent
	{
		public DocumentsForm( ) {
			InitializeComponent();

			Fenu fenu1 = new Fenu();
			fenu1.Name = "fenu1";
			fenu1.Dock = System.Windows.Forms.DockStyle.Top;
			this.Controls.Add( fenu1 );

			Fenu fenu2 = new Fenu();
			fenu2.Name = "fenu2";
			fenu2.Dock = System.Windows.Forms.DockStyle.Top;
			this.Controls.Add( fenu2 );
		}
	}
}