using System.Xml;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;
using Fenubars.XML;
using System.Collections.Generic;
using Fenubars.Display;
using System;
using Fenubars.Buttons;

namespace Fenubars
{
	public class Handler
	{
		// XML serializer fields
		private XmlSerializerNamespaces Namespace;
		private XmlSerializer Serializer;

		// File state holder
		private FenuState CurrentFenuState;
		public List<FenuContent> LoadedFenus {
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
		private PropertyGrid _PropertyViewer;
		public PropertyGrid PropertyViewer {
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
			Serializer = new XmlSerializer( typeof( FenuState ), "" );
		}

		#region Loader

		private void LoadXML(string XMLPath) {
			//Deserialize to object
			using( StreamReader Reader = new StreamReader( XMLPath ) )
			{
				CurrentFenuState = (FenuState)Serializer.Deserialize( Reader );
			}
		}

		public void LoadFenu(string FenuName) {
			foreach( FenuContent ParsedFenu in CurrentFenuState.IncludedFenus )
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
				PropertyViewer.SelectedObject = CurrentFenuState;
			else if( e.Type == typeof( EscapeButton ) )
				PropertyViewer.SelectedObject = e.Escape;
			else if( e.Type == typeof( NormalButton ) )
				PropertyViewer.SelectedObject = e.Normal;
			else if( e.Type == typeof( NextButton ) )
				PropertyViewer.SelectedObject = e.Next;
		}

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
