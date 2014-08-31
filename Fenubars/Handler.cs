using System;
using System.IO;
using System.ComponentModel;
using System.Reflection;
using System.Xml;
using System.Xml.Serialization;
using System.Collections.Generic;

using Fenubars.Display;
using Fenubars.Buttons;
using Fenubars.XML;

using ModuleInterface;

namespace Fenubars
{
	public class Handler : IModule
	{
		// XML serializer fields
		private XmlSerializerNamespaces Namespace;
		private XmlSerializer Serializer;

		// File state holder
		private XMLGlobalState CurrentFenuState;
		public List<FenuState> LoadedFenus
		{
			get
			{
				return CurrentFenuState.IncludedFenus;
			}
			set
			{
				CurrentFenuState.IncludedFenus = value;
			}
		}

		private string XMLPath = string.Empty;

		#region Acquire focus object by event

		private void FocusedObjectAvailable( object sender,
											Fenubars.Display.ObjectDetailEventArgs e )
		{
			if( e.Type == typeof( Fenu ) ) {
				//PropertyViewer.HiddenAttributes = null;
				//PropertyViewer.BrowsableProperties = null;
				_Host.SetPropertyGrid( null, null );

				_Host.ShowProperties( CurrentFenuState );
			}
			else {
				if( e.Type == typeof( EscapeButton ) )
					_Host.ShowProperties( e.Escape );
				else if( e.Type == typeof( NormalButton ) )
					_Host.ShowProperties( e.Normal );
				else if( e.Type == typeof( NextButton ) )
					_Host.ShowProperties( e.Next );

				//PropertyViewer.HiddenAttributes = new AttributeCollection( new Attribute[] { new CategoryAttribute( "Fenu Button" ) } );
				//PropertyViewer.BrowsableProperties = SelectedProperties( e.Type );
				_Host.SetPropertyGrid( new AttributeCollection( new Attribute[] { new CategoryAttribute( "Fenu Button" ) } ),
										SelectedProperties( e.Type ) );
			}
		}

		private string[] SelectedProperties( Type DesiredType )
		{
			List<string> Properties = new List<string>();

			// Load the button type of selected button
			ButtonTypes Template = (ButtonTypes)Enum.Parse( typeof( ButtonTypes ), DesiredType.Name );
			// Parse all the properties in the target object
			foreach( PropertyInfo PI in typeof( FenuButtonState ).GetProperties() ) {
				// Identified if the cycled property has defined ButtonTypeAttribute
				if( PI.IsDefined( typeof( ButtonTypeAttribute ), false ) ) {
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

		#region IModule Members

		#region Module info

		public string Name
		{
			get
			{
				return "Fenubar";
			}
		}

		public string Description
		{
			get
			{
				return "Use this plugin to support fenubar edit function.";
			}
		}

		public string Version
		{
			get
			{
				return Assembly.GetEntryAssembly().GetName().Version.ToString();
			}
		}

		#endregion

		#region Host adapter

		private IModuleHost _Host;
		public IModuleHost Host
		{
			get
			{
				return _Host;
			}
			set
			{
				_Host = value;
			}
		}

		#endregion

		#region Basic operations

		public bool Initialize( string XMLPath )
		{

			this.XMLPath = XMLPath;

			// Using XmlReader to probe for root node
			using( XmlReader reader = XmlReader.Create( XMLPath ) ) {
				while( reader.Read() ) {
					if( reader.NodeType == XmlNodeType.Element ) {
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

		private void InitiateSerializer()
		{
			// Configure serializer namespaces, remove the xml:ns definition
			Namespace = new XmlSerializerNamespaces();
			Namespace.Add( "", "" );

			// Initiate serializer
			Serializer = new XmlSerializer( typeof( XMLGlobalState ), "" );
		}

		private void LoadXML( string XMLPath )
		{
			//Deserialize to object
			using( StreamReader Reader = new StreamReader( XMLPath ) ) {
				CurrentFenuState = (XMLGlobalState)Serializer.Deserialize( Reader );
			}

			ObjectTree OT = new ObjectTree( CurrentFenuState.IncludedFenus );
			OT.Dock = System.Windows.Forms.DockStyle.Fill;
			_Host.DrawOnCanvas( OT );
		}

		public void Open( string FenuName )
		{
			foreach( FenuState ParsedFenu in CurrentFenuState.IncludedFenus ) {
				if( ParsedFenu.Name == FenuName ) {
					Fenu newFenuPanel = new Fenu( ParsedFenu );
					newFenuPanel.DataAvailable += new EventHandler<Fenubars.Display.ObjectDetailEventArgs>( FocusedObjectAvailable );
					newFenuPanel.PopulateButtons();

					_Host.DrawOnCanvas( newFenuPanel );
					return;
				}
			}
		}

		public void Close()
		{
		}

		#endregion

		#region File processing

		public void Save()
		{
			SaveAs( this.XMLPath );
		}

		public void SaveAs( string XMLPath )
		{
			using( StreamWriter Writer = new StreamWriter( XMLPath ) ) {
				Serializer.Serialize( Writer, CurrentFenuState, Namespace );
			}
		}

		#endregion

		#region Edit operations

		public void Cut()
		{
			throw new Exception( "The method or operation is not implemented." );
		}

		public void Copy()
		{
			throw new Exception( "The method or operation is not implemented." );
		}

		public void Paste()
		{
			throw new Exception( "The method or operation is not implemented." );
		}

		public void Delete()
		{
			throw new Exception( "The method or operation is not implemented." );
		}

		#endregion

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
