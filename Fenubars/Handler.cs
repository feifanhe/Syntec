using System.Xml;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;
using Fenubars.XML;
using System.Collections.Generic;
using Fenubars.Display;
using System;
using Fenubars.Buttons;
using Azuria.Common.Controls;
using System.Reflection;
using System.ComponentModel;

namespace Fenubars
{
	public class Handler
	{
		// XML serializer fields
		private XmlSerializerNamespaces Namespace;
		private XmlSerializer Serializer;

		// File state holder
		private XMLGlobalState CurrentFenuState;
		public List<FenuState> LoadedFenus {
			get {
				return CurrentFenuState.IncludedFenus;
			}
			set {
				CurrentFenuState.IncludedFenus = value;
			}
		}

		// Parent container
		private System.Windows.Forms.Control.ControlCollection _Canvas;
		public System.Windows.Forms.Control.ControlCollection Canvas {
			get {
				return _Canvas;
			}
			set {
				_Canvas = value;
			}
		}
		private FilteredPropertyGrid _PropertyViewer;
		public FilteredPropertyGrid PropertyViewer {
			get {
				return _PropertyViewer;
			}
			set {
				_PropertyViewer = value;
			}
		}

		public Handler(string XMLPath) {

			// Using XmlReader to probe for root node
			using( XmlReader reader = XmlReader.Create( XMLPath ) )
			{
				while( reader.Read() )
				{
					if( reader.NodeType == XmlNodeType.Element )
					{
						// Check if first element is named "root"
						if( reader.Name != "root" )
							throw new FileLoadException( "Invalid fenu XML format." );
						else
							break;
					}
				}
			}

			InitiateSerializer();
			LoadXML( XMLPath );

		}

		private void InitiateSerializer( ) {
			// Configure serializer namespaces, remove the xml:ns definition
			Namespace = new XmlSerializerNamespaces();
			Namespace.Add( "", "" );

			// Initiate serializer
			Serializer = new XmlSerializer( typeof( XMLGlobalState ), "" );
		}

		#region Loader

		private void LoadXML(string XMLPath) {
			//Deserialize to object
			using( StreamReader Reader = new StreamReader( XMLPath ) )
			{
				CurrentFenuState = (XMLGlobalState)Serializer.Deserialize( Reader );
			}
		}

		public void LoadFenu(string FenuName) {
			foreach( FenuState ParsedFenu in CurrentFenuState.IncludedFenus )
			{
				if( ParsedFenu.Name == FenuName )
				{
					Fenu DummyFenu = new Fenu( ParsedFenu );
					DummyFenu.DataAvailable += new EventHandler<Fenubars.Display.ObjectDetailEventArgs>( FocusedObjectAvailable );
					DummyFenu.PopulateButtons();
					Canvas.Add( DummyFenu );
				}
			}
		}

		#endregion

		#region Saver

		public void Save(string XMLPath) {
			using( StreamWriter Writer = new StreamWriter(XMLPath) )
			{
				Serializer.Serialize( Writer, CurrentFenuState, Namespace );
			}
		}

		#endregion

		#region Acquire focus object by event

		private void FocusedObjectAvailable(object sender,
											Fenubars.Display.ObjectDetailEventArgs e) {
			if( e.Type == typeof( Fenu ) )
			{
				PropertyViewer.SelectedObject = CurrentFenuState;
				PropertyViewer.HiddenAttributes = new AttributeCollection( new Attribute[] { } );
				PropertyViewer.BrowsableProperties = new string[] { };
				PropertyViewer.Refresh();
			}
			else
			{
				if( e.Type == typeof( EscapeButton ) )
					PropertyViewer.SelectedObject = e.Escape;
				else if( e.Type == typeof( NormalButton ) )
					PropertyViewer.SelectedObject = e.Normal;
				else if( e.Type == typeof( NextButton ) )
					PropertyViewer.SelectedObject = e.Next;

				PropertyViewer.HiddenAttributes = new AttributeCollection( new Attribute[] { new CategoryAttribute( "Fenu Button" ) } );
				PropertyViewer.BrowsableProperties = SelectedProperties( e.Type );
				PropertyViewer.Refresh();
			}
			//PropertyViewer.Refresh();
			//Console.WriteLine( typeof( NormalButton ).Name );
			//Console.WriteLine(ButtonTypes.NormalButton.ToString());
		}

		private string[] SelectedProperties(Type DesiredType) {
			List<string> Properties = new List<string>();

			ButtonTypes Template = (ButtonTypes)Enum.Parse(typeof(ButtonTypes), DesiredType.Name);
			foreach( PropertyInfo PI in typeof( FenuButtonState ).GetProperties() )
			{
				if( PI.IsDefined( typeof( ButtonTypeAttribute ), false ) )
				{
					ButtonTypes Value =( PI.GetCustomAttributes(typeof(ButtonTypeAttribute), false)[0] as ButtonTypeAttribute).Type;
					if( ( Value & Template)== Template  )
					{
						//MessageBox.Show( Value + " IS " + DesiredType.Name , PI.Name);
						Properties.Add( PI.Name );
					}
					else
					{
						//MessageBox.Show( Value + " IS NOT " + DesiredType.Name, PI.Name );
					}
				}
			}

			Console.WriteLine( "* SELECTED PROPERTIES: " );
			foreach( string str in Properties )
				Console.WriteLine( str );
			Console.WriteLine( "*" );

			return Properties.ToArray();
		}

		//private string[] SelectedProperties(){
   //         foreach( PropertyInfo PI in typeof(T).GetProperties() ){
   //             if(PI.IsDefined(typeof(ButtonTypeAttribute), false)
   //             {
   //                 ButtonTypeAttribute BTA = PI.GetCustomAttributes(typeof(ButtonTypeAttribute, false)[0] as ButtonTypeAttribute;
   //                 if(BTA.Type & 

   //             var attribute =
   //(MethodTestingAttibute)
   //typeof (Vehicles)
   //   .GetMethod("m1")
   //   .GetCustomAttributes(typeof (MethodTestingAttibute), false).First();
		//}

		#endregion

	}

	#region Object type for property grid

	public enum ObjectType
	{
		FENU,
		ESCAPE,
		NORMAL,
		NEXT
	};

	#endregion
}
