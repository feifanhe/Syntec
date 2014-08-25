using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using System;
using System.Xml.Serialization;

namespace Fenubars.Editor
{
	public class ClipBoardManager<T> where T : class
	{
		private XmlSerializer Serializer;
		
		/// <summary>
		/// Gets object from clipboard.
		/// </summary>
		/// <returns>the retrieved object</returns>
		public static T GetFromClipboard( ) {
			//T retrievedObj = null;
			//IDataObject dataObj = Clipboard.GetDataObject();
			//string format = typeof( T ).FullName;
			//if( dataObj.GetDataPresent( format ) )
			//{
			//    retrievedObj = dataObj.GetData( format ) as T;
			//}
			//return retrievedObj;

			using( StringReader reader = new StringReader( Clipboard.GetText( System.Windows.Forms.TextDataFormat.Text ) ) )
			{
				XmlSerializer serializer = new XmlSerializer( typeof( T ) );
				object result = serializer.Deserialize( reader );
				return (result as T);
			}

			return null;
		}

		/// <summary>
		/// Copies the suite object to clipboard.
		/// </summary>
		public static void CopyToClipboard(T objectToCopy) {
			//// register my custom data format with Windows or get it if it's already registered
			//DataFormats.Format format = DataFormats.GetFormat( typeof( T ).FullName );

			using( StringWriter writer = new StringWriter() )
			{
				XmlSerializer serializer = new XmlSerializer( typeof( T ) );
				serializer.Serialize( writer, objectToCopy );
				Clipboard.SetText(writer.ToString());
			}

			//// now copy to clipboard
			//IDataObject dataObj = new DataObject();
			//dataObj.SetData( format.Name, false, objectToCopy );
			//Clipboard.SetDataObject( dataObj, false );
		}

		/// <summary>
		/// Clears this instance.
		/// </summary>
		public static void Clear( ) {
			Clipboard.Clear();
		}
		public static bool IsSerializable(object obj) {
			MemoryStream mem = new MemoryStream();
			BinaryFormatter bin = new BinaryFormatter();
			try
			{
				bin.Serialize( mem, obj );
				return true;
			}
			catch( Exception ex )
			{
				MessageBox.Show( "Your object cannot be serialized." +
								 " The reason is: " + ex.ToString() );
				return false;
			}
		}

	}
}
