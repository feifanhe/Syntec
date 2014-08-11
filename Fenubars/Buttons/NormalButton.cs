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

		private int Sequence = -1;
		public void SetSequence(int Sequence) {
			if( Sequence < 1 || Sequence > 8 )
				throw new IndexOutOfRangeException( "Button ID sequence out of range!" );

			this.Sequence = Sequence;
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
