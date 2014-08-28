using System;

namespace Syntec.Module
{
	internal class AppDomainCore
	{
		public AppDomainCore(string appDomainName) {
			_DefaultAppDomainName = appDomainName;
			LoadAppDomain();
		}

		// Currently active AppDomain
		private AppDomain _DefaultAppDomain;
		public AppDomain DefaultAppDomain {
			get {
				return _DefaultAppDomain;
			}
		}
		private string _DefaultAppDomainName;
		public string DefaultAppDomainName {
			get {
				return _DefaultAppDomainName;
			}
		}

		// Create a new AppDomain instance
		private bool LoadAppDomain( ) {
			// An expensive solution, need other method
			GC.Collect();

			// Construct and initialize settings for a second AppDomain.
			AppDomainSetup ADS = new AppDomainSetup();

			// Configure the assembly to copy the dll, in order to release the file lock
			ADS.ShadowCopyFiles = "true";
			//ADS.ShadowCopyDirectories = System.IO.Path.GetTempPath();

			// Create the second AppDomain.
			_DefaultAppDomain = AppDomain.CreateDomain( _DefaultAppDomainName, null, ADS );

			return true;
		}

		~AppDomainCore( ) {
			WipeAppDomain();
		}
		
		private bool WipeAppDomain( ) {
			try
			{
				AppDomain.Unload( _DefaultAppDomain );
				_DefaultAppDomain = null;
				return true;
			}
			catch
			{
				return false;
			}
		}
	}
}
