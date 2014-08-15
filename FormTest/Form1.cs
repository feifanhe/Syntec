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
using Fenubars;

namespace FormTest
{
	public partial class MainForm : Form
	{
		Handler loader;

		public MainForm( ) {
			InitializeComponent();

			try
			{
				loader = new Handler( "root.xml" );
				loader.Canvas = this.splitContainer1.Panel1.Controls;
				loader.PropertyViewer = propertyGrid1;
				loader.LoadFenu( "fenu1" );
			}
			catch( FileLoadException )
			{
				MessageBox.Show( "Cannot load file." );
			}
		}

		private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			loader.Save( "output.xml" );
		}
	}
}