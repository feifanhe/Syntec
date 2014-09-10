using System.Collections.Generic;
using Fenubars.XML;
using Fenubars.Display;
using System;
using System.IO;

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

		private Dictionary<string, FenuState> FindFenuImages( string fenuName )
		{
			string originalPathBackup = XMLPath;
			Dictionary<string, FenuState> images = new Dictionary<string, FenuState>();

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
				XMLGlobalState temporaryFenuStates = null;
				if( ContainRootNode() ) {
				RE_PARSE:

					try {
						// Parse this XML
						using( StreamReader Reader = new StreamReader( XMLPath ) ) {
							Console.WriteLine( "SCANNING: " + XMLPath );

							temporaryFenuStates = Serializer.Deserialize( Reader ) as XMLGlobalState;

							// Find targeted fenu (if exist)
							foreach( FenuState parsedFenu in temporaryFenuStates.IncludedFenus ) {
								Console.Write( " +- " + parsedFenu.Name );

								if( parsedFenu.Name == fenuName ) {
									images.Add( XMLPath, parsedFenu );
									Console.WriteLine( "... ADD" );
								}
								else
									Console.WriteLine();
							}
						}
					}
					catch( InvalidOperationException e ) {
						Console.WriteLine( " = ERR: " + e.Message );
						RectifyXmlFormat();
						goto RE_PARSE;
					}
				}
#if GENERIC_SEARCH
				}
#endif
			}

			// Restore original path
			XMLPath = originalPathBackup;

			// Lower priority image, closer to the head
			//images.Reverse();

			return images;
		}

		private Fenu ReflectOnFenu( Fenu vanilla, Dictionary<string, FenuState> images )
		{
			//vanilla
			Console.WriteLine( "==IMAGE FENUS==" );
			foreach( KeyValuePair<string, FenuState> image in images )
				Console.WriteLine( image.Key + " @ " + image.Value.Name );
			Console.WriteLine( "===============" );

			return null;
		}
	}
}
