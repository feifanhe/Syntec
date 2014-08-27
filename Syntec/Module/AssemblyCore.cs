using System;
using System.IO;
using System.Windows.Forms;

namespace Syntec.Module
{
	internal class AssemblyCore
	{
		const string OriginalAssemblyFileName = "DefaultAssembly.dll";

		// Gets currently active assembly
		private string _ActiveAssemblyFileName;
		public string ActiveAssemblyFileName {
			get {
				return _ActiveAssemblyFileName;
			}
		}

		// Gets the currently used type
		private string _CurrentType;
		public string CurrentType {
			get {
				return _CurrentType;
			}
			set {
				_CurrentType = value;
			}
		}

		// Gets currently active assembly (shadow copied)
		public string DefaultAssemblyFileName {
			get {
				return OriginalAssemblyFileName;
			}
		}

		// Returns currently active assembly's file info
		private FileInfo _DefaultAssemblyFile;
		public FileInfo DefaultAssemblyFile {
			get {
				return _DefaultAssemblyFile;
			}
		}

		public AssemblyCore(string assemblyFileName, string typeName) {
			_CurrentType = typeName;
			SetDefaultAssemblyFile( assemblyFileName );
		}

		// Refrence to the specified assembly file
		public bool SetDefaultAssemblyFile(string assemblyFileName) {
			try
			{
				// Save the original file name.
				_ActiveAssemblyFileName = assemblyFileName;

				// Acquire temporary file location
				string destPath = Path.GetTempPath() + Guid.NewGuid().ToString() + ".dll";

				File.Copy( assemblyFileName, destPath, true );
				_DefaultAssemblyFile = new FileInfo( OriginalAssemblyFileName );
				return true;
			}
			catch( Exception Err )
			{
				MessageBox.Show( Err.Message,
									"Versioning Failed",
									MessageBoxButtons.OK, 
									MessageBoxIcon.Error);
				return false;
			}
		}
	}
}
