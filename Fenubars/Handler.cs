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
using PluginInterface;

namespace Fenubars
{
	public class Handler : IPlugin
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

		private string XMLPath = string.Empty;

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

		// Plugin fields
		private readonly string PluginName = "Fenubar";
		private string PluginDescription = "Use this plugin to support fenubar edit function."; 
		private IPluginHost PluginHost = null;
		private UserControl _MainInterface;// = new ctlMain();


		#region Acquire focus object by event

		private void FocusedObjectAvailable(object sender,
											Fenubars.Display.ObjectDetailEventArgs e) {
			if( e.Type == typeof( Fenu ) )
			{
				PropertyViewer.HiddenAttributes = null;
				PropertyViewer.BrowsableProperties = null;

				PropertyViewer.SelectedObject = CurrentFenuState;	
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
			}
			PropertyViewer.Refresh();
		}

		private string[] SelectedProperties(Type DesiredType) {
			List<string> Properties = new List<string>();

			// Load the button type of selected button
			ButtonTypes Template = (ButtonTypes)Enum.Parse(typeof(ButtonTypes), DesiredType.Name);
			// Parse all the properties in the target object
			foreach( PropertyInfo PI in typeof( FenuButtonState ).GetProperties() )
			{
				// Identified if the cycled property has defined ButtonTypeAttribute
				if( PI.IsDefined( typeof( ButtonTypeAttribute ), false ) )
				{
					ButtonTypes Value = ( PI.GetCustomAttributes( typeof( ButtonTypeAttribute ), false )[ 0 ] as ButtonTypeAttribute ).Type;
					// Using bitwise operation to varify whether the selected property is the wanted one or not
					if( ( Value & Template ) == Template )
						Properties.Add( PI.Name );
				}
			}

			Console.WriteLine( "* SELECTED PROPERTIES: " );
			foreach( string str in Properties )
				Console.WriteLine( str );
			Console.WriteLine( "*" );

			return Properties.ToArray();
		}

		#endregion

		#region IPlugin Members

		public IPluginHost Host {
			get {
				throw new Exception( "The method or operation is not implemented." );
			}
			set {
				throw new Exception( "The method or operation is not implemented." );
			}
		}

		public string Name {
			get {
				return this.PluginName;
			}
		}

		public string Description {
			get {
				return this.PluginDescription;
			}
		}

		public string Version {
			get {
				return Assembly.GetEntryAssembly().GetName().Version.ToString();
			}
		}

		public UserControl MainInterface {
			get {
				return _MainInterface;
			}
		}

		#region Loader

		public bool Initialize(string XMLPath) {

			this.XMLPath = XMLPath;

			// Using XmlReader to probe for root node
			using( XmlReader reader = XmlReader.Create( XMLPath ) )
			{
				while( reader.Read() )
				{
					if( reader.NodeType == XmlNodeType.Element )
					{
						// Check if first element is named "root"
						if( reader.Name != "root" )
							return false;
						else
							break;
					}
				}
			}

			InitiateSerializer();
			LoadXML( XMLPath );

			return true;
		}

		private void InitiateSerializer( ) {
			// Configure serializer namespaces, remove the xml:ns definition
			Namespace = new XmlSerializerNamespaces();
			Namespace.Add( "", "" );

			// Initiate serializer
			Serializer = new XmlSerializer( typeof( XMLGlobalState ), "" );
		}

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

		public void Dispose( ) {
		}

		#region Saver

		public void Save() {
			SaveAs( this.XMLPath );
		}

		public void SaveAs(string XMLPath) {
			using( StreamWriter Writer = new StreamWriter( XMLPath ) )
			{
				Serializer.Serialize( Writer, CurrentFenuState, Namespace );
			}
		}

		#endregion

		public void Cut( ) {
			throw new Exception( "The method or operation is not implemented." );
		}

		public void Copy( ) {
			throw new Exception( "The method or operation is not implemented." );
		}

		public void Paste( ) {
			throw new Exception( "The method or operation is not implemented." );
		}

		public void Delete( ) {
			throw new Exception( "The method or operation is not implemented." );
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
