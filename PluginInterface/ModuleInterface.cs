using System.ComponentModel;
using System.Windows.Forms;

namespace ModuleInterface
{
	public interface IModule
	{
		#region Host adapter

		/// <summary>
		/// The adapter for module to communicate with host.
		/// </summary>
		IModuleHost Host
		{
			get;
			set;
		}

		#endregion

		#region Basic operations

		/// <summary>
		/// This method call the initialization method of an module.
		/// </summary>
		/// <param name="XMLPath">The XML file path.</param>
		/// <returns>Return false if the module can't initialize from designated XML 
		/// path.</returns>
		bool Initialize( string XMLPath );

		/// <summary>
		/// This method acts as the default open action for the module.
		/// </summary>
		void Open();

		/// <summary>
		/// This method acts as the advance open action for the module.
		/// </summary>
		/// <param name="Name"></param>
		void Open( string Name );

		/// <summary>
		/// This method act as the default close operation for the module.
		/// </summary>
		void Close();

		#endregion

		#region File processing

		/// <summary>
		/// This method tells the module to save it's modification to the original file.
		/// </summary>
		void Save();

		/// <summary>
		/// This method tells the module to save it's modification to a designated file.
		/// </summary>
		/// <param name="XMLPath">The new file location to save upon.</param>
		void SaveAs( string XMLPath );

		#endregion

		#region Edit operations

		/// <summary>
		/// This method tells the module to do cut operation.
		/// </summary>
		void Cut();

		/// <summary>
		/// This method tells the module to do copy operation.
		/// </summary>
		void Copy();

		/// <summary>
		/// This method tells the module to do paste operation.
		/// </summary>
		void Paste();

		/// <summary>
		/// This method tells the module to do delete operation.
		/// </summary>
		void Delete();

		#endregion
	}

	public interface IModuleHost
	{
		/// <summary>
		/// This method populate the assigned control to the binded host.
		/// </summary>
		/// <param name="control">A form control.</param>
		void DrawOnCanvas( System.Windows.Forms.Control control );

		/// <summary>
		/// This method finds the control by the name on the designated host.
		/// </summary>
		/// <returns>The specified control in the host, return <c>null</c> if none found.</returns>
		Control FindControlByName( string name );

		/// <summary>
		/// This method finds the focused control on the designated host.
		/// </summary>
		/// <returns>Focused control in the host, return <c>null</c> if none found.</returns>
		Control FindFocusedControl();

		/// <summary>
		/// This method associate the assigned control with property grid; hence show
		/// the properties of it. Use <see cref="IModuleHost.SetPropertyGrid"/> to 
		/// configure the detail.
		/// </summary>
		/// <param name="control">The control to display its properties.</param>
		void ShowProperties( object control );

		/// <summary>
		/// This method configured visibility of attributes and properties in the 
		/// property grid.
		/// </summary>
		/// <param name="hidden">The attributes to hide.</param>
		/// <param name="browsable">The properties to show.</param>
		void SetPropertyGrid( AttributeCollection hidden, string[] browsable );

		/// <summary>
		/// This method populate the objects tree a module compiled.
		/// </summary>
		/// <param name="treeView">The compiled tree that shows all the object the
		/// opened file contains.</param>
		void ShowObjects( Control treeView );

		/// <summary>
		/// This method setup the label and progress bar in the status strip.
		/// </summary>
		/// <param name="text">Text to dispaly. Use <c>null</c> to maintain the data.</param>
		/// <param name="progress">Progress bar value, <c>-1</c> to hide it.</param>
		/// <param name="marquee">Set the progress bar to marquess mode, progress value must 
		/// set to a non-negative and less-than-100 integer.</param>
		void ShowStatusInfo( string text, int progress, bool marquee );

		/// <summary>
		/// This method tells the host whether the documents it handled is modified or not.
		/// </summary>
		/// <param name="modified">True if it's modified.</param>
		void Modified( bool modified );
	}
}
