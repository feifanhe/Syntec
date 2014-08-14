using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Fenubars.XML;

namespace Fenubars.Buttons
{
	public partial class NormalButton : System.Windows.Forms.Button
	{
		public NormalButton( ) {
			InitializeComponent();
		}

		public NormalButton(IContainer container) {
			container.Add( this );

			InitializeComponent();
		}
	}
}
