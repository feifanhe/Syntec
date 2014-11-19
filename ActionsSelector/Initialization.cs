using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ActionsSelector
{
	class Initialization
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			// Setup thread localize contents here
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault( false );
			Application.Run( new ActionsSelector.ActionsSelectDialog() );
		}
	}
}
