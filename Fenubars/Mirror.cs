using System.Collections.Generic;
using Fenubars.XML;
using Fenubars.Display;
using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Windows.Forms;
using Fenubars.Buttons;
using System.Collections;
using System.Drawing;

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

		private void GenerateFenuImage( Fenu fenu )
		{
			string originalPathBackup = XMLPath;
			Fenu mirroredFenu = fenu;

			// Byte array to store button covering status
			byte[] coveringStatus = new byte[ fenu.NormalButtonCount + 2 ];
			// Image-fenu list for later-impose
			List<FenuButtonState> image = new List<FenuButtonState>( fenu.NormalButtonCount + 2 );

			for( int i = 0; i < fenu.NormalButtonCount + 2; i++ ) {
				// Set default state
				coveringStatus[ i ] = 0x01;

				// Generate dummy FBS
				image.Add( new FenuButtonState() );
			}

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

				try {
					document.Load( XMLPath );
				}
				catch( FileNotFoundException ) {
					// File doesn't exist under this folder, skip
					continue;
				}

				// Skip this document if it doesn't contain <root> tag
				if( document.SelectSingleNode( "/root" ) == null )
					continue;

				XmlNode selectedFenuNode = document.SelectSingleNode( "//fenu[@name='" + fenu.Name + "']" );

				// Fenu doesn't exist in this file, skip
				if( selectedFenuNode == null )
					continue;

				// Normal buttons
				foreach( XmlNode buttonNode in selectedFenuNode.ChildNodes ) {
					FenuButtonState partialDeserialized = DeserializeButtonNode<FenuButtonState>( buttonNode );

					int coveredButton = -1;
					switch( buttonNode.Name ) {
						case "escape":
							coveredButton = 0;
							break;
						case "button":
							coveredButton = partialDeserialized.Position;
							break;
						case "next":
							coveredButton = coveringStatus.Length - 1;
							break;
					}

					// Write covering status, 0x01 for default, every exponent of 2 means one overwrite occurred
					coveringStatus[ coveredButton ] = (byte)( coveringStatus[ coveredButton ] << 1 );

					// Write the latest button to image list, visual purpose
					image[ coveredButton ] = partialDeserialized;
				}
			}
#if GENERIC_SEARCH
				}
#endif

			fenu.SaveImage( image, coveringStatus );

			// Restore original path
			XMLPath = originalPathBackup;
		}

		private T DeserializeButtonNode<T>( XmlNode node ) where T : class
		{
			T output = default( T );

			XmlSerializer serializer = new XmlSerializer( typeof( T ), new XmlRootAttribute( node.Name ) );
			using( XmlNodeReader reader = new XmlNodeReader( node ) ) {
				output = serializer.Deserialize( reader ) as T;
			}

			return output;
		}
	}
}
