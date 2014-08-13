using System;
using System.Collections.Generic;
using System.Text;

using WeifenLuo.WinFormsUI.Docking;
using System.Xml.Serialization;
using System.IO;
using System.Windows.Forms;

using Fenubars.XMLProcessing;
using System.ComponentModel;

namespace Fenubars
{
	public class Loader : INotifyPropertyChanged
	{
		private FenusProperties _Properties;
		public FenusProperties Properties {
			get {
				return _Properties;
			}
			set {
				_Properties = value;
				RaisePropertyChanged( "Properties" );
			}
		}

		public Loader(DockContent Canvas) {

			//Properties = ObjectXMLSerializer<FenusProperties>.Load( "TestFenu.xml" );

			#region Deserialize Test
			XmlRootAttribute xRoot = new XmlRootAttribute();
			xRoot.ElementName = "root";
			xRoot.Namespace = "Fenubars";
			xRoot.IsNullable = false;

			// Deserialize
			XmlSerializer serializer = new XmlSerializer( typeof( FenusProperties ), xRoot );
			using( StreamReader reader = new StreamReader( "TestFenu.xml" ) )
			{
				Properties = serializer.Deserialize( reader ) as FenusProperties;
			}
			#endregion

			#region Serialize Test
			//using( StreamWriter writer = new StreamWriter( "root2.xml" ) )
			//{
			//    serializer.Serialize( writer, GlobalProperties );
			//}
			#endregion

			// EXP: Load all the fenu at this moment
			for( int i = 0; i < Properties.Fenus.Count; i++ )
			{
				Fenu fenu = new Fenu( Properties.Fenus[ i ] );

				fenu.Dock = DockStyle.Top;

				fenu.PopulateButtons();

				Canvas.Controls.Add( fenu );
			}

			
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
