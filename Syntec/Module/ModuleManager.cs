using System;
using System.Collections;
using Syntec.Configurator;
using System.Reflection;
using System.IO;
using System.Windows.Forms;

using ModuleInterface;

namespace Syntec.Module
{
	public static class ModuleManager
	{
		public static readonly string ModuleFolderPath = @"\Modules";

		// Available module states
		private static Modules moduleList = new Modules();

		private static IniConfigurator configs = new IniConfigurator( Application.StartupPath + ModuleFolderPath + @"\Modules.ini" );

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
					AddModule( fileName );
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

					// Check if the dll implements the interface
					if( typeInterface != null )
					{
						Module newModule = new Module();

						newModule.Assembly = assembly;
						newModule.EntryType = moduleType.ToString();

						// Since assembly was assigned, name can be read now
						bool parsedState;
						if( Boolean.TryParse( configs.GetValue( "LoadOnStart", newModule.Name ), out parsedState ) )
							newModule.Enabled = parsedState;
						else
						{
							newModule.Enabled = false;
							configs.AddValue( "LoadOnStart", newModule.Name, "false" );
							configs.Save();
						}

						// Add the new module to collection here
						moduleList.Add( newModule );

						newModule = null;
					}
					typeInterface = null;
				}
			}
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
				if( instance.Initialize( XMLPath ) && parsedModule.Enabled )
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


		#region Module info

		public string Name {
			get {
				// Get the namespace only
				return _Assembly.FullName.Split( ',' )[ 0 ];
			}
		}

		public string Description {
			get {
				object descriptionObject = _Assembly.GetCustomAttributes( typeof( AssemblyDescriptionAttribute ), false )[ 0 ];
				return ( descriptionObject as AssemblyDescriptionAttribute ).Description;
			}
		}

		public string Version {
			get {
				return Assembly.GetEntryAssembly().GetName().Version.ToString();
			}
		}

		#endregion

		#region Module state

		private bool _Enabled = false;
		public bool Enabled {
			get {
				return _Enabled;
			}
			set {
				_Enabled = value;
			}
		}

		#endregion

		#region Instance info

		private Assembly _Assembly;
		public Assembly Assembly {
			get {
				return _Assembly;
			}
			set {
				_Assembly = value;
			}
		}

		// Entry type to indicate what type to instantiate
		private string _EntryType;
		public string EntryType {
			get {
				return _EntryType;
			}
			set {
				_EntryType = value;
			}
		}

		#endregion
	}
}
