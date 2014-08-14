using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Fenubars.Display;
using Fenubars.XML;
using System.Xml.Serialization;
using System.IO;

namespace FormTest
{
	public partial class MainForm : Form
	{
		FenuState fs;

		public MainForm( ) {
			InitializeComponent();

			// Configure serializer namespaces, remove the xml:ns definition
			XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
			ns.Add( "", "" );

			// Initiate serializer
			XmlSerializer ser = new XmlSerializer( typeof( FenuState ), "" );

#if DIRECT
			// Generate state object
			fs = new FenuState();

			// Generate fenu contents
			FenuContent fc1 = new FenuContent();
			fc1.Name = "FENU1";
			fs.IncludedFenus.Add( fc1 );
			FenuContent fc2 = new FenuContent();
			fc2.Name = "FENU2";
			fs.IncludedFenus.Add( fc2 );

			// Apply to fenu
			Fenu fenu1 = new Fenu();
			fenu1.AssignFenuContent( fs.IncludedFenus[ 0 ] );
			fenu1.PopulateButtons();
			fenu1.Dock = DockStyle.Top;
			Fenu fenu2 = new Fenu();
			fenu2.AssignFenuContent( fs.IncludedFenus[ 1 ] );
			fenu2.PopulateButtons();
			//fenu2.Location = new Point( 0, 150 );
			fenu2.Dock = DockStyle.Top;

			//fc.NB.ParseBackColor = SystemColors.Control;
			//fc.NB.VisibleSpecified = false;

			// Add controls
			this.Controls.Add( fenu1 );
			this.Controls.Add( fenu2 );
#else
			//Deserialize to object
			using( StreamReader reader = new StreamReader( "CncFenu.xml" ) )
			{
				fs = (FenuState)ser.Deserialize( reader );
			}

			foreach( FenuContent fc in fs.IncludedFenus )
			{
				Console.WriteLine( fc.Name );
				Fenu DummyFenu = new Fenu();
				DummyFenu.AssignFenuContent( fc );
				DummyFenu.PopulateButtons();
				DummyFenu.Dock = DockStyle.Top;
				DummyFenu.DataAvailable += new EventHandler( FocusedObjectAvailable );

				this.splitContainer1.Panel1.Controls.Add( DummyFenu );
			}
#endif

			//using( StreamWriter writer = new StreamWriter( "test.xml" ) )
			//{
			//    ser.Serialize( writer, fs, ns );
			//}
		}

		private void FocusedObjectAvailable(object sender, EventArgs e) {
			propertyGrid1.SelectedObject = sender;
		}
	}
}