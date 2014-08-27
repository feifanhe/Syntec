namespace ModuleInterface
{
	public interface IModule
	{
		string Name {
			get;
		}
		string Description {
			get;
		}
		string Version {
			get;
		}

		System.Windows.Forms.UserControl MainInterface {
			get;
		}

		#region Basic operations

		// Return false if the plugin can't initialize from designated XMLPath
		bool Initialize(string XMLPath);
		void Open(string Name);
		void Close( );

		#endregion

		#region File processing

		void Save( );
		void SaveAs(string XMLPath);

		#endregion

		#region Edit operations

		void Cut( );
		void Copy( );
		void Paste( );
		void Delete( );

		#endregion
	}
}
