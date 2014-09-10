using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using System;
using System.Xml.Serialization;
using System.Xml;

namespace Fenubars.Editor
{
	public class ClipBoardManager<T> where T : class
	{
		public static bool Available()
		{
			using( StringReader reader = new StringReader( Clipboard.GetText( System.Windows.Forms.TextDataFormat.Text ) ) ) {
				try {
					XmlSerializer serializer = new XmlSerializer( typeof( T ) );
					XmlTextReader xreader = new XmlTextReader( reader );
					return serializer.CanDeserialize( xreader );
				}
				catch( Exception ) {
				    return false;
				}
			}
		}

		public static T GetFromClipboard()
		{
			using( StringReader reader = new StringReader( Clipboard.GetText( System.Windows.Forms.TextDataFormat.Text ) ) ) {
				try {
					XmlSerializer serializer = new XmlSerializer( typeof( T ) );
					object result = serializer.Deserialize( reader );
					return ( result as T );
				}
				catch( Exception ) {
					return null;
				}
			}
		}

		public static void CopyToClipboard( T objectToCopy )
		{
			using( StringWriter writer = new StringWriter() ) {
				XmlSerializer serializer = new XmlSerializer( typeof( T ) );
				serializer.Serialize( writer, objectToCopy );
				Clipboard.SetText( writer.ToString() );
			}
		}

		public static void Clear()
		{
			Clipboard.Clear();
		}

		#region Debug function

		public static bool IsSerializable( object obj )
		{
			MemoryStream mem = new MemoryStream();
			BinaryFormatter bin = new BinaryFormatter();
			try {
				bin.Serialize( mem, obj );
				return true;
			}
			catch( Exception ex ) {
				MessageBox.Show( "Object cannot be serialized." +
								 " The reason is: " + ex.ToString() );
				return false;
			}
		}

		#endregion
	}
}
