using System.ComponentModel;
using System.Windows.Forms;

namespace ModuleInterface
{
	public interface IModule
	{
		#region Host adapter

		IModuleHost Host
		{
			get;
			set;
		}

		#endregion

		#region Basic operations

		// Return false if the plugin can't initialize from designated XMLPath
		bool Initialize( string XMLPath );
		void Open();
		void Open( string Name );
		void Close();

		#endregion

		#region File processing

		void Save();
		void SaveAs( string XMLPath );

		#endregion

		#region Edit operations

		void Cut();
		void Copy();
		void Paste();
		void Delete();

		#endregion
	}

	public interface IModuleHost
	{
		void DrawOnCanvas( System.Windows.Forms.Control control );
		Control FindFocusedControl();
		void ShowProperties( object control );
		void SetPropertyGrid( AttributeCollection hidden, string[] browsable );
		void ShowObjects( Control treeView );
		void ShowStatusInfo( string text, int progress );
	}
}
