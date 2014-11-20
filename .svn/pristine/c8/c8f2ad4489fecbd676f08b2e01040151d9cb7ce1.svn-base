using System;
using System.Collections;
using Syntec.Configurator;
using System.Reflection;
using System.IO;
using System.Windows.Forms;

using ModuleInterface;
using System.Collections.Generic;

namespace Syntec.Module
{
	public static class ModuleManager
	{
		private static readonly string CategoryString = "LoadOnStart";

		// Available module states
		private static Modules moduleList = new Modules();

		// Start up configurator
		private static IniConfigurator configs = new IniConfigurator( Application.StartupPath + Global.ModuleFolderPath + @"\Modules.ini" );

		public static void Refresh()
		{
			// Wipe storage
			moduleList.Clear();

			SearchFolder();
			//ReadConfig();
		}

		private static void SearchFolder()
		{
			try {
				//Go through all the files in the module directory
				foreach( string fileName in Directory.GetFiles( Application.StartupPath + Global.ModuleFolderPath ) ) {
					FileInfo file = new FileInfo( fileName );

					//Preliminary check, must be .dll
					if( file.Extension.ToUpper() == ".DLL" )
						AddModule( fileName );
				}
			}
			catch( DirectoryNotFoundException e ) {
				MessageBox.Show( e.Message );
			}
		}

		private static void AddModule( string path )
		{
			// Create the assembly
			Assembly assembly = Assembly.LoadFrom( path );

			// Loop through all the types in the assembly
			foreach( Type moduleType in assembly.GetTypes() ) {
				// Only look for public, non-abstract type
				if( moduleType.IsPublic && !moduleType.IsAbstract ) {
					Type typeInterface = moduleType.GetInterface( "ModuleInterface.IModule", true );

					// Check if the dll implements the interface
					if( typeInterface != null ) {
						Module newModule = new Module();

						newModule.Assembly = assembly;
						newModule.EntryType = moduleType.ToString();

						// Since assembly was assigned, name can be read now
						bool parsedState;
						if( Boolean.TryParse( configs.GetValue( CategoryString, newModule.Name ), out parsedState ) )
							newModule.Enabled = parsedState;
						else {
							newModule.Enabled = false;
							configs.AddValue( CategoryString, newModule.Name, false.ToString() );
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
		public static IModule FindProcessor( string XMLPath )
		{
			IModule instance;

			// Loop throuh all loaded modules
			foreach( Module parsedModule in moduleList ) {
				Assembly parsedAssembly = parsedModule.Assembly;

				// Create instance to test
				instance = Activator.CreateInstance( parsedAssembly.GetType( parsedModule.EntryType ) ) as IModule;
				// Try to know if this DLL can interpret the XML
				if( instance.Initialize( XMLPath ) && parsedModule.Enabled )
					return instance;

				// Wipe the instance
				instance = null;
			}

			return null;
		}

		public static IModule GetModuleByName( string ModuleName )
		{
			IModule instance;

			// Loop throuh all loaded modules
			foreach( Module parsedModule in moduleList ) {
				if( parsedModule.Name.CompareTo( ModuleName ) == 0 ) {
					Assembly parsedAssembly = parsedModule.Assembly;

					// Create instance
					instance = Activator.CreateInstance( parsedAssembly.GetType( parsedModule.EntryType ) ) as IModule;
					if( parsedModule.Enabled )
						return instance;
				}
			}

			return null;
		}

		public static Modules AvailableModules
		{
			get
			{
				return moduleList;
			}
		}

		public static void RewriteConfigs( Dictionary<string, bool> stateList )
		{
			if( File.Exists( Application.StartupPath + Global.ModuleFolderPath + @"\Modules.ini" ) ) {
				File.Delete( Application.StartupPath + Global.ModuleFolderPath + @"\Modules.ini" );
			}

			// Dump all loaded modules' settings into .tmp file
			IniConfigurator tempIni = new IniConfigurator( Application.StartupPath + Global.ModuleFolderPath + @"\Modules.ini" );
			foreach( KeyValuePair<string, bool> pair in stateList )
				tempIni.AddValue( CategoryString, pair.Key, pair.Value.ToString() );

			tempIni.Save();

			// Reload the configurator using overwritten file
			configs.Reload();
		}
	}

	public class Modules : CollectionBase
	{
		public void Add( Module module )
		{
			this.List.Add( module );
		}

		public void Remove( Module module )
		{
			this.List.Remove( module );
		}

		public Module this[ int index ]
		{
			get
			{
				return this.List[ index ] as Module;
			}
			set
			{
				this.List[ index ] = value;
			}
		}
	}

	public class Module
	{
		#region Module info

		public string Name
		{
			get
			{
				// Get the namespace only
				return _Assembly.FullName.Split( ',' )[ 0 ];
			}
		}

		public string Description
		{
			get
			{
				// Object must exist, so no need for exception handling
				object descriptionObject = _Assembly.GetCustomAttributes( typeof( AssemblyDescriptionAttribute ), false )[ 0 ];
				return ( descriptionObject as AssemblyDescriptionAttribute ).Description;
			}
		}

		public string Version
		{
			get
			{
				return Assembly.GetEntryAssembly().GetName().Version.ToString();
			}
		}

		#endregion

		#region Module state

		private bool _Enabled = false;
		public bool Enabled
		{
			get
			{
				return _Enabled;
			}
			set
			{
				_Enabled = value;
			}
		}

		#endregion

		#region Instance info

		private Assembly _Assembly;
		public Assembly Assembly
		{
			get
			{
				return _Assembly;
			}
			set
			{
				_Assembly = value;
			}
		}

		// Entry type to indicate what type to instantiate
		private string _EntryType;
		public string EntryType
		{
			get
			{
				return _EntryType;
			}
			set
			{
				_EntryType = value;
			}
		}

		#endregion
	}
}
