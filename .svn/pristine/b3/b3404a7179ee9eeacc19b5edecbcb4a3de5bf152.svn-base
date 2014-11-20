using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data;

namespace Syntec.Configurator
{
	public sealed class IniConfigurator
	{
		// Main table
		private System.Data.DataTable settings;

		// File path for this configurator
		private string filePath = string.Empty;

		public IniConfigurator( string path )
		{
			InitializeDataTable();

			this.filePath = path;

			LoadFromFile();
			// Dummy save to create file on first run
			Save();
		}

		private void InitializeDataTable()
		{
			settings = new DataTable();

			settings.TableName = "Settings";

			settings.Columns.Add( "Category", typeof( string ) );
			settings.Columns.Add( "Key", typeof( string ) );
			settings.Columns.Add( "Value", typeof( string ) );
		}

		private void LoadFromFile()
		{
			if( !File.Exists( filePath ) )
				return;

			string currentCategory = string.Empty;

			StreamReader SR = new StreamReader( filePath );
			while( !SR.EndOfStream ) {
				string currentLine = SR.ReadLine(); //reads the current file

				// Check if the selected line is usable
				if( currentLine.Length < 3 )
					continue;

				// Check if there's a category marker
				if( currentLine.StartsWith( "[" ) && currentLine.EndsWith( "]" ) ) {
					currentCategory = currentLine.Substring( 1, currentLine.Length - 2 );
					continue;
				}

				// Check if it's a setting
				if( !currentLine.Contains( "=" ) )
					continue;

				string currentKey = currentLine.Substring( 0, currentLine.IndexOf( "=", StringComparison.Ordinal ) );
				string currentValue = currentLine.Substring( currentLine.IndexOf( "=", StringComparison.Ordinal ) + 1 );

				AddValue( currentCategory, currentKey, currentValue );
			}

			SR.Close();
		}

		public void Reload()
		{
			settings.Rows.Clear();

			LoadFromFile();
		}

		public void AddValue( string category, string key, string value )
		{
			foreach( DataRow row in settings.Rows ) {
				if( row[ 0 ] as string == category && row[ 1 ] as string == key ) {
					row[ 2 ] = value;
					return;
				}
			}

			settings.Rows.Add( category, key, value );
		}

		public string GetValue( string category, string key ) //gets a value or returns a default value
		{
			foreach( DataRow row in settings.Rows ) {
				if( row[ 0 ] as string == category && row[ 1 ] as string == key )
					return row[ 2 ] as string;
			}

			return null;
		}

		public void Save()
		{
			FileInfo file = new FileInfo( filePath );
			FileStream FS;

			// Create the file if it doesn't exist
			if( file.Exists )
				FS = file.Create();
			else
				FS = file.OpenWrite();

			// Sort data table
			DataView dv = settings.DefaultView;
			dv.Sort = "Category asc";
			DataTable sortedDT = dv.ToTable();

			StreamWriter SW = new StreamWriter( FS );

			string lastCategory = "";
			foreach( DataRow row in sortedDT.Rows ) {
				if( (string)row[ 0 ] != lastCategory ) {
					lastCategory = (string)row[ 0 ];
					SW.WriteLine( "[" + lastCategory + "]" );
				}

				SW.WriteLine( (string)row[ 1 ] + "=" + (string)row[ 2 ] );
			}

			SW.Close();
		}
	}
}
