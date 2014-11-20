using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Fenubars
{
	public enum ButtonCounts { 
		[Description("5")]
		FIVE, 
		[Description("8")]
		EIGHT, 
	};

	public partial class Fenu : UserControl, INotifyPropertyChanged
	{
		public Fenu(FenuProperties Properties) {
			this.Properties = Properties;
			// Initialize fenu layout
			InitializeComponent();

			//FenuPropertiesBindingSource.DataSource = _Properties;
			//this.DataBindings.Add( "Name", _Properties, "Name" );

			//FenuName.Text = _Properties.Name;

			//// Initialize all the buttons in the fenu
			//PopulateButtons();
		}


		private FenuProperties _Properties;
		public FenuProperties Properties {
			get {
				return _Properties;
			}
			set {
				_Properties = value;
				RaisePropertyChanged( "Properties" );
			}
		}

		public void PopulateButtons( ) {
			for( int i = 0; i < _Properties.NormalButton.Count; i++ )
			{
				PopulateButton<NormalButton>( i );
			}
		}

		private void PopulateButton<T>(int ButtonSequence) where T : NormalButton {
			T GeneratedButton = Activator.CreateInstance(typeof(T) , new object[] { (object)Properties.NormalButton[ ButtonSequence ] } ) as T;

			//GeneratedButton.BindProperty( Properties.NormalButton[ ButtonSequence ] );

			GeneratedButton.Location = new Point( 3 + 80 * ButtonSequence, 3 );
			GeneratedButton.Size = new Size( 80, 60 );
			
			FenuButtonPanel.Controls.Add( GeneratedButton );
		}

		#region INotifyPropertyChanged Members

		public event PropertyChangedEventHandler PropertyChanged;
		public void RaisePropertyChanged(string propertyName) {
			if( PropertyChanged != null )
				PropertyChanged.Invoke( this, new PropertyChangedEventArgs( propertyName ) );
		}

		#endregion
	}
}
