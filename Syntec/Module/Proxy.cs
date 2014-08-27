using ModuleInterface;

namespace Syntec.Module
{
	public class Proxy : IModule
	{
		// Main controller for AppDomain
		AppDomainCore appDomainController;

		// Main controller for Assembly
		AssemblyCore assemblyController;

		// Module interface definition
		IModule proxy;

		// Gets the currently active AppDomain name
		public string DefaultAppDomainName {
			get {
				return appDomainController.DefaultAppDomainName;
			}
		}

		// Gets the default assembly's file name
		public string DefaultAssemblyFileName {
			get {
				return assemblyController.ActiveAssemblyFileName;
			}
		}

		public Proxy(string assemblyFileName, string appDomainName) {
			InitProxy( assemblyFileName, appDomainName, "ClassLibrary" );
		}

		public Proxy(string assemblyFileName, string appDomainName, string currentType) {
			InitProxy( assemblyFileName, appDomainName, currentType );
		}

		private bool InitProxy(string assemblyFileName, string appDomainName, string currentType) {
			// Creates an instance of assembly controller and AppDomain controller
			this.assemblyController = new AssemblyCore( assemblyFileName, currentType );
			this.appDomainController = new AppDomainCore( appDomainName );

			// 1. Create an instance of the assembly in the second AppDomain
			// 2. Unwrap the remote object of the specific type
			proxy = (IModule)appDomainController.
								DefaultAppDomain.
								CreateInstanceFromAndUnwrap( assemblyController.DefaultAssemblyFileName,
																assemblyController.CurrentType );

			return true;
		}

		#region IModule Members

		#region Module info

		public string Name {
			get {
				if( proxy != null )
					return proxy.Name;
				return null;
			}
		}

		public string Description {
			get {
				if( proxy != null )
					return proxy.Description;
				return null;
			}
		}

		public string Version {
			get {
				if( proxy != null )
					return proxy.Version;
				return null;
			}
		}

		#endregion

		#region Basic operations

		public bool Initialize(string XMLPath) {
			if( proxy != null )
				return proxy.Initialize( XMLPath );
			return false;
		}

		public void Open(string Name) {
			if( proxy != null )
				proxy.Open( Name );
			return;
		}

		public void Close( ) {
			if( proxy != null )
				proxy.Close();
			return;
		}

		#endregion

		#region File processing

		public void Save( ) {
			throw new Exception( "The method or operation is not implemented." );
		}

		public void SaveAs(string XMLPath) {
			throw new Exception( "The method or operation is not implemented." );
		}

		#endregion

		#region Edit operations

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

		#endregion
	}
}
