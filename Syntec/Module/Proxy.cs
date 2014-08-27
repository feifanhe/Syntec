namespace Syntec.Module
{
	public class Proxy : ModuleInterface.IModule
	{
		// Main controller for AppDomain
		AppDomainCore appDomainController;

		// Main controller for Assembly
		AssemblyCore assemblyController;

		// Module interface definition
		ModuleInterface.IModule proxy;

		#region IModule Members

		public string Name {
			get {
				throw new Exception( "The method or operation is not implemented." );
			}
		}

		public string Description {
			get {
				throw new Exception( "The method or operation is not implemented." );
			}
		}

		public string Version {
			get {
				throw new Exception( "The method or operation is not implemented." );
			}
		}

		public System.Windows.Forms.UserControl MainInterface {
			get {
				throw new Exception( "The method or operation is not implemented." );
			}
		}

		public bool Initialize(string XMLPath) {
			throw new Exception( "The method or operation is not implemented." );
		}

		public void Open(string Name) {
			throw new Exception( "The method or operation is not implemented." );
		}

		public void Close( ) {
			throw new Exception( "The method or operation is not implemented." );
		}

		public void Save( ) {
			throw new Exception( "The method or operation is not implemented." );
		}

		public void SaveAs(string XMLPath) {
			throw new Exception( "The method or operation is not implemented." );
		}

		public void Cut( ) {
			throw new Exception( "The method or operation is not implemented." );
		}

		public void Copy( ) {
			throw new Exception( "The method or operation is not implemented." );
		}

		public void Paste( ) {
			throw new Exception( "The method or operation is not implemented." );
		}

		public void Delete( ) {
			throw new Exception( "The method or operation is not implemented." );
		}

		#endregion
	}
}
