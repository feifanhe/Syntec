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
	public partial class NormalButton : Button, INotifyPropertyChanged
	{
		public NormalButton(NormalButtonProperties Properties) {
			this.Properties = Properties;

			InitializeComponent();

			this.PropertyChanged += new PropertyChangedEventHandler( button_PropertyChanged );
		}

		private NormalButtonProperties _Properties;
		public NormalButtonProperties Properties {
			get {
				return _Properties;
			}
			set {
				_Properties = value;
				RaisePropertyChanged( "Properties" );
			}
		}

		//protected override void OnEnabledChanged(EventArgs e) {
		//    Properties.state = ( this.Enabled ) ? State.enable : State.disable;
		//}

		public override string Text {
			get {
				return Properties.Title;
			}
			set {
				Properties.Title = value;
				RaisePropertyChanged( "Text" );
			}
		}

		#region INotifyPropertyChanged Members

		public event PropertyChangedEventHandler PropertyChanged;
		public void RaisePropertyChanged(string propertyName) {
			if( PropertyChanged != null )
				PropertyChanged.Invoke( this, new PropertyChangedEventArgs( propertyName ) );
		}

		private void button_PropertyChanged(object sender, PropertyChangedEventArgs e) {
			Console.WriteLine( "SOMETHING CHANGED" );
			this.Refresh();
		}

		#endregion
	}
}
