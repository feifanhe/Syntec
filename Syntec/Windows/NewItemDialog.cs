using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace Syntec.Windows
{
	public partial class NewItemDialog : Form
	{

		public NewItemDialog()
		{
			InitializeComponent();
			this.SelectionPanel.PopulateCategory( "Workspace.xml" );
		}

		public static void NewWorkspace()
		{
			NewItemDialog dialog = new NewItemDialog();
		}

		
	}
}