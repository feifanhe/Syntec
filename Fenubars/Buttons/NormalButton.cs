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

		public override string Text {
			get {
				return this.titleField;
			}
			set {
				this.titleField = value;
			}
		}

		
	}
}
