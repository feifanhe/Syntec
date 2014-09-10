using System.Collections.Generic;
using Fenubars.XML;
using Fenubars.Display;
using System;
using System.IO;
using System.Xml;

namespace Fenubars
{
	public partial class Handler
	{
		private List<string> GetProductHierarchy( string filePath )
		{
			bool inWorkspace = false;
			string combinedPath = string.Empty;
			List<string> result = new List<string>();

			string[] dissectedXmlPath = XMLPath.Split( '\\' );

			foreach( string segments in dissectedXmlPath ) {
				// Merge segments
				combinedPath += segments + "\\";

				// Check if it's the beginning of workspace zone
				if( segments == "Res" ) {
					inWorkspace = true;
					result.Add( combinedPath );
				}

				if( inWorkspace && segments.Contains( "_" ) )
					result.Add( combinedPath );
			}

			return result;
		}

		private Fenu ReflectOnFenu( Fenu fenu )
		{
			string originalPathBackup = XMLPath;
			Fenu mirroredFenu = fenu;

			// Scan in hierarchy folders
			List<string> dirToSearch = GetProductHierarchy( XMLPath );
			for( int i = 0; i < dirToSearch.Count - 1; i++ ) {
				Console.WriteLine( dirToSearch[ i ] );

				string targetDir = dirToSearch[ i ] + @"Common\";

#if GENERIC_SEARCH
				foreach( string file in Directory.GetFiles( targetDir ) ) {
					XMLPath = file;

					// Test for XML only
					if( Path.GetExtension( XMLPath ).ToUpper() != ".XML" )
						continue;
#else
				XMLPath = targetDir + Path.GetFileName( originalPathBackup );
#endif
				XmlDocument document = new XmlDocument();
				document.LoadXml( XMLPath );
				// Skip this document if it doesn't contain <root> tag
				if( document.SelectSingleNode( "/root" ) == null )
					continue;

				XmlNode selectedFenuNode = document.SelectSingleNode( "/fenu[@name='" + fenu.Name + "']" );

				XmlNode selectedButtonNode;

				// Escape button
				selectedButtonNode = selectedFenuNode.SelectSingleNode( "/escape" );
				if( selectedFenuNode != null ) {

				}

				// Next button
				selectedButtonNode = selectedFenuNode.SelectSingleNode( "/next" );
				if( selectedFenuNode != null ) {
				}

				// Normal buttons
				foreach( XmlNode normalButtonNode in selectedFenuNode.SelectNodes( "/button" ) ) {

				}

			}
#if GENERIC_SEARCH
				}
#endif

			// Restore original path
			XMLPath = originalPathBackup;

			return mirroredFenu;
		}

		private Fenu ReflectOnFenu( Fenu objectFenu, Fenu imageFenu, string path )
		{

		}
	}
}
