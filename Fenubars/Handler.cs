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

		private ObjectTree CompiledTree;
		private string XMLPath = string.Empty;

		#region Acquire focus object by event

		private void FocusedObjectAvailable( Type type, FenuButtonState data )
		{
			if( type == typeof( Fenu ) ) {
				// Set to null first, since fenu state don't have some attributes
				_Host.SetPropertyGrid( null, null );
				_Host.ShowProperties( CurrentFenuState );
			}
			else {
				// Set object first, and then filter the attributes
				_Host.ShowProperties( data );
				_Host.SetPropertyGrid( new AttributeCollection( new Attribute[] { new CategoryAttribute( "Fenu Button" ) } ),
										SelectedProperties( type ) );
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
		}

		public void Open()
		{
			CompiledTree = new ObjectTree( Path.GetFileNameWithoutExtension( XMLPath ), 
											CurrentFenuState.IncludedFenus );
			_Host.ShowObjects( CompiledTree );
		}

		public void Open( string fenuName )
		{
			foreach( FenuState parsedFenu in CurrentFenuState.IncludedFenus ) {
				if( parsedFenu.Name == fenuName ) {
					Fenu newFenuPanel = new Fenu( parsedFenu );
					newFenuPanel.OnDataAvailable += new Fenu.DataAvailableEventHandler(FocusedObjectAvailable);
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
}
