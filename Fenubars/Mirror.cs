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

		private Fenu ReflectOnFenu( Fenu fenu )
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

			string state = string.Empty;
			foreach( byte status in coveringStatus )
				state += status.ToString() + ", ";
			MessageBox.Show( state, XMLPath );

			// Cycle through all the buttons in original fenu
			foreach( Control control in GetAllControls( fenu.Controls ) ) {
				// Filter for specific button
				if( control is EscapeButton ) {

				}
				else if( control is NormalButton ) {
					NormalButton button = control as NormalButton;

					bool binded = ( button.DataBindings.Count != 0 );
					int index = ButtonPosition( button.Location.X );

					// Button not occupied, then bind info to it
					if( !binded )
						button.SetState( image[ index ] );

					// Set font
					button.Font = GenerateFontByStatus( coveringStatus[ index ], binded, button.Font );
				}
				else if( control is NextButton ) {
				}
			}

			// Restore original path
			XMLPath = originalPathBackup;

			return mirroredFenu;
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

		private int ButtonPosition( int xPos )
		{
			return ( xPos - 3 ) / 83;
		}

		private List<Control> GetAllControls( IList controls )
		{
			List<Control> result = new List<Control>();
			foreach( Control control in controls ) {
				if( control is Button )
					result.Add( control );
				List<Control> SubControls = GetAllControls( control.Controls );
				result.AddRange( SubControls );
			}
			return result;
		}

		private Font GenerateFontByStatus( byte status, bool binded, Font original )
		{
			FontStyle style = FontStyle.Regular; 

			// Bold: overwriteen
			// Italic: foreign button, not covered
			// Bold-Italic: covered foreign button
			// Normal: Original not covered

			bool bold = false;
			bool italic = false;

			if(( status >> 1 ) != 0 )
				italic = true;

			if( ( status >> 2 ) != 0 )
				bold = true;

			if( binded & italic ) {
				italic = false;
				bold = true;
			}

			// Boolean state to font style
			if(bold & italic)
				style = FontStyle.Bold | FontStyle.Italic;
			else if(bold & !italic)
				style = FontStyle.Bold;
			else if(!bold & italic)
				style = FontStyle.Italic;
			else
				style = FontStyle.Regular;

			return new Font( original, style );
		}
	}
}
