using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Fenubars
{
	[ToolboxItem( true )]
	public partial class NormalButton : Button
	{
		public NormalButton( ) {
			InitializeComponent();	
		}

		BindingSource dataBindingSource;

		public void BindProperty(NormalButtonProperties Properties) {
			Console.WriteLine( "*BIND: " + Properties.Title );

			dataBindingSource = new BindingSource();
			dataBindingSource.DataSource = Properties;

			this.DataBindings.Add( "Text", dataBindingSource, "Title" );
			this.Refresh();
		}

		protected override void OnEnabledChanged(EventArgs e) {
			//Properties.state = ( this.Enabled ) ? State.enable : State.disable;
		}
	}
}
