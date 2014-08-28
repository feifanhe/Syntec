using System.IO;
using System.Windows.Forms;
using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Reflection;
using System;
using System.Configuration;
using System.Text;
using ModuleInterface;

namespace Syntec.Module
{
	public class ModuleManager
	{
		public static readonly string ModuleFolderPath = @"\Modules";

		// Available module states
		private static Modules moduleList = new Modules();

		public static void Refresh( ) {
			// Wipe storage
			moduleList.Clear();

			SearchFolder();
			//ReadConfig();
		}

		private static void SearchFolder( ) {
			//Go through all the files in the module directory
			foreach( string fileName in Directory.GetFiles( Application.StartupPath + ModuleFolderPath ) )
			{
				FileInfo file = new FileInfo( fileName );

				//Preliminary check, must be .dll
				if( file.Extension.ToUpper() == ".DLL" )
				{
					//Add the module
					AddModule( fileName );
				}
			}
		}

		private static void AddModule(string path) {
			// Create the assembly
			Assembly assembly = Assembly.LoadFrom( path );

			// Loop through all the types in the assembly
			foreach( Type moduleType in assembly.GetTypes() )
			{
				// Only look for public, non-abstract type
				if( moduleType.IsPublic && !moduleType.IsAbstract )
				{
					Type typeInterface = moduleType.GetInterface( "ModuleInterface.IModule", true );
					//foreach(Type t in moduleType.GetInterfaces())
					//Console.WriteLine( t.ToString() );

					// Check if the dll implements the interface
					if( typeInterface != null )
					{
						Module newModule = new Module();

						newModule.Assembly = assembly;
						newModule.EntryType = moduleType.ToString();
						// Since assembly was assigned, name can be read now
						newModule.Enabled = ReadConfig( newModule.Name );
						// Add the new module to collection here
						moduleList.Add( newModule );

						newModule = null;
					}
					typeInterface = null;
				}
			}
		}

		private static bool ReadConfig(string name) {
			string configFilePath = Application.StartupPath + ModuleFolderPath + @"\Modules.config";
			Configuration loadedConfigs = ConfigurationManager.OpenExeConfiguration( ConfigurationUserLevel.None );
			//loadedConfigs.AppSettings.File = configFilePath;

			// Create config file if configuration file doesn't exist
			if( !loadedConfigs.HasFile )
			{
				StringBuilder SB = new StringBuilder();
				SB.AppendLine( "<?xml version=\"1.0\" encoding=\"utf-8\" ?>" );
				SB.AppendLine( "<configuration>" );
				SB.AppendLine( "</configuration>" );

				File.WriteAllText( String.Concat( configFilePath ), SB.ToString() );
			}

			bool probeEnabled;

			// Find if key exist
			string[] keys = loadedConfigs.AppSettings.Settings.AllKeys;
			bool exist = false;
			foreach( string key in keys )
			{
				if( key == name )
				{
					exist = true;
					break;
				}
			}

			if( !exist )
			{
				probeEnabled = false;
				// Add new config entry
				loadedConfigs.AppSettings.Settings.Add( name, "false" );
				// Save config
				//loadedConfigs.AppSettings.Save();
			}
			else
			{
				string readout = loadedConfigs.AppSettings.Settings[ name ].Value;
				probeEnabled = Boolean.Parse( readout );
			}

			return probeEnabled;
		}

		// Try the XML file with every loaded module
		public static IModule FindProcessor(string XMLPath) {
			IModule instance;

			// Loop throuh all loaded modules
			foreach( Module parsedModule in moduleList )
			{
				Assembly parsedAssembly = parsedModule.Assembly;

				// Create instance to test
				string typeName = parsedModule.Name + ".Initialize";
				instance = Activator.CreateInstance( parsedAssembly.GetType( parsedModule.EntryType ) ) as IModule;
				// Try to know if this DLL can interpret the XML
				if( instance.Initialize( XMLPath ) && parsedModule.Enabled)
					return instance;

				// Wipe the instance
				instance = null;
			}

			return null;
		}

		public static Modules AvailableModules {
			get {
				return moduleList;
			}
		}
	}

	public class Modules : CollectionBase
	{
		public void Add(Module module) {
			this.List.Add( module );
		}

		public void Remove(Module module) {
			this.List.Remove( module );
		}

		public Module this[ int index ] {
			get {
				return this.List[ index ] as Module;
			}
			set {
				this.List[ index ] = value;
			}
		}
	}

	public class Module
	{
		private Assembly _Assembly;
		public Assembly Assembly {
			get {
				return _Assembly;
			}
			set {
				_Assembly = value;
			}
		}

		public string Name {
			get {
				// Get the namespace only
				Console.WriteLine( Assembly.GetName() );
				return _Assembly.FullName.Split( ',' )[ 0 ];
			}
		}

		private bool _Enabled = false;
		public bool Enabled {
			get {
				return _Enabled;
			}
			set {
				_Enabled = value;
			}
		}

		private string _EntryType;
		public string EntryType {
			get {
				return _EntryType;
			}
			set {
				_EntryType = value;
			}
		}
	}
}
