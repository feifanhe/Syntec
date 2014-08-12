using System;
using System.Collections.Generic;
using System.Text;

using WeifenLuo.WinFormsUI.Docking;
using System.Xml.Serialization;
using System.IO;
using System.Windows.Forms;

using Fenubars.XMLProcessing;

namespace Fenubars
{
	public class Loader
	{
		private FenusProperties GlobalProperties;

		private BindingSource DataContainer = new BindingSource();

		public Loader(DockContent Canvas) {

			GlobalProperties = ObjectXMLSerializer<FenusProperties>.Load( "root.xml" );

			//XmlRootAttribute xRoot = new XmlRootAttribute();
			//xRoot.ElementName = "root";
			//xRoot.Namespace = "Fenubars";
			//xRoot.IsNullable = false;


			//// Deserialize
			//XmlSerializer serializer = new XmlSerializer( typeof( FenusProperties ), xRoot );
			//using( StreamReader reader = new StreamReader( "root.xml" ) )
			//{
			//    GlobalProperties = serializer.Deserialize( reader ) as FenusProperties;
			//}

			//GlobalProperties.Alignment = 123;

			//using( StreamWriter writer = new StreamWriter( "root2.xml" ) )
			//{
			//    serializer.Serialize( writer, GlobalProperties );
			//}

			// EXP: Load all the fenu at this moment
			foreach( FenuProperties ParsedFenu in GlobalProperties.Fenus )
			{
				Fenu fenu = new Fenu();

				fenu.Properties = ParsedFenu;

				fenu.Dock = DockStyle.Top;

				fenu.PopulateButtons();

				Canvas.Controls.Add( fenu );
			}
		}
	}
}
