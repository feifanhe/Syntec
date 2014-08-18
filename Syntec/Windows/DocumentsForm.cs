using System.Collections.Generic;
using WeifenLuo.WinFormsUI.Docking;

using Fenubars;
using System.Xml.Serialization;
using System;
using System.Windows.Forms;

namespace Syntec.Windows
{
	public partial class DocumentsForm : DockContent
	{
		public Handler fenuloader;
		
		public DocumentsForm( ) {
			InitializeComponent();

			//fenuloader = new Handler( "root.xml" );

			//List<Fenu> fenulist = new List<Fenu>();

			//FenusProperties fp = new FenusProperties();

			//fp.Alignment = 1;
			//fp.AlignmentSpecified = true;
			//fp.NoLR = true;
			//fp.NoLRSpecified = true;

			//Fenu fenu1 = new Fenu();
			//fenu1.Name = "FENU1";
			//Fenu fenu2 = new Fenu();
			//fenu2.Name = "FENU2";

			//fenulist.Add( fenu1 );
			//fenulist.Add( fenu2 );

			//Console.WriteLine( fenulist.Count );

			//fp.Fenus = fenulist;

			////Fenu fenu1 = new Fenu();
			////fenu1.Name = "fenu1";
			////fenu1.Dock = System.Windows.Forms.DockStyle.Top;
			////this.Controls.Add( fenu1 );

			////Fenu fenu2 = new Fenu();
			////fenu2.Name = "fenu2";
			////fenu2.Dock = System.Windows.Forms.DockStyle.Top;
			////this.Controls.Add( fenu2 );

			////fenulist.Add( fenu1 );
			////fenulist.Add( fenu2 );

			//XmlSerializer xs = new XmlSerializer( typeof( FenusProperties ) );

			//using( System.IO.StreamWriter sw = new System.IO.StreamWriter( "test.xml" ) )
			//{
			//    xs.Serialize( sw, fp );
			//    sw.Flush();
			//}
		}

		

		//public void Save(string FileName) {
		//    using( var writer = new System.IO.StreamWriter( FileName ) )
		//    {
		//        var serializer = new XmlSerializer( this.GetType() );
		//        serializer.Serialize( writer, this );
		//        writer.Flush();
		//    }
		//}
	}
}