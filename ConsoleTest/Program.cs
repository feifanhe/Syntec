using System;
using System.Collections.Generic;
using System.Text;
using Fenubars.XML;
using System.Xml.Serialization;
using System.IO;
using Fenubars.Display;
using System.Drawing;

namespace ConsoleTest
{
	class Program
	{
		static void Main(string[] args) {

			// Generate state object
			FenuState fs = new FenuState();

			//// Add dummy fenu
			FenuContent fc = new FenuContent();
			fc.Name = "TEST FENU CONTENT";
			fs.IncludedFenus.Add( fc );

			//fc.NB.ParseBackColor = SystemColors.Control;
			//fc.NB.VisibleSpecified = false;

			Fenu fenu = new Fenu();
			fenu.fc = fs.IncludedFenus[0];

			fenu.PopulateButtons();

			// Configure serializer namespaces, remove the xml:ns definition
			XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
			ns.Add("", "" );

			// Initiate serializer
			XmlSerializer ser = new XmlSerializer( typeof( FenuState ), "" );
			using( StreamWriter writer = new StreamWriter( "test.xml" ) )
			{
				ser.Serialize( writer, fs, ns );
			}

		}
	}
}
