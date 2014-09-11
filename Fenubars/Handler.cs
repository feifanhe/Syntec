using System;
using System.IO;
using System.ComponentModel;
using System.Reflection;
using System.Xml;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Windows.Forms;

using Fenubars.Display;
using Fenubars.Buttons;
using Fenubars.XML;

using ModuleInterface;

namespace Fenubars
{
	public partial class Handler : IModule
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

			if( !ContainRootNode() )
				return false;

			InitiateSerializer();

			RELOAD_XML:

			try {
				LoadXML( XMLPath );
			}
			catch( InvalidOperationException ) {
				RectifyXmlFormat();
				goto RELOAD_XML;
			}

			return true;
		}

		private bool ContainRootNode()
		{
			try {
				// Using XmlReader to probe for root node
				using( XmlReader reader = XmlReader.Create( XMLPath ) ) {
					while( reader.Read() ) {
						if( reader.NodeType == XmlNodeType.Element ) {
							// Check if first element is named "root"
							return ( reader.Name == "root" );
						}
					}
				}
			}
			catch( XmlException ) {
			}
			catch( FileNotFoundException ) {
			}

			return false;
		}

		private void InitiateSerializer()
		{
			// Configure serializer namespaces, remove the xml:ns definition
			Namespace = new XmlSerializerNamespaces();
			Namespace.Add( "", "" );

			// Initiate serializer
			Serializer = new XmlSerializer( typeof( XMLGlobalState ), "" );
		}

		private void RectifyXmlFormat()
		{
			// Temporary solution for patch
			List<string> output = new List<string>();
			using( StreamReader file = new StreamReader( XMLPath ) ) {
				while( !file.EndOfStream ) {
					string line = file.ReadLine();

					if( line.Contains( "<state><" ) )
						continue;

					if( line.Contains( "<state>false" ) )
						line = line.Replace( "false", "disable" );

					if( line.Contains( "<state>true" ) )
						line = line.Replace( "true", "enable" );

					if( line.Contains( "False" ) )
						line = line.Replace( "False", "false" );

					if( line.Contains( "True" ) )
						line = line.Replace( "True", "true" );

					output.Add( line );
				}
			}

			using( StreamWriter file = new StreamWriter( XMLPath ) ) {
				foreach( string line in output )
					file.WriteLine( line );
			}
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

		// Figure out 5 or 8 key by filename
		private int NormalButtonCount()
		{
			const int defaultButtonCount = 8;

#if CONSTANT_KEY_COUNT
			return defaultButtonCount;
#else
			string fileName = Path.GetFileNameWithoutExtension( XMLPath );
			string digit = fileName.Substring(fileName.Length-1);

			int result = -1;
			if( int.TryParse( digit, out result ) )
				return result;
			else
				return defaultButtonCount;
#endif
		}

		public void Open( string fenuName )
		{
			foreach( FenuState parsedFenu in CurrentFenuState.IncludedFenus ) {
				if( parsedFenu.Name == fenuName ) {
					Fenu newFenuPanel = new Fenu( parsedFenu, NormalButtonCount() );
					newFenuPanel.OnDataAvailable += new Fenu.DataAvailableEventHandler( FocusedObjectAvailable );
					newFenuPanel.Linkage += new Fenu.LinkageEventHandler( Open );

					newFenuPanel.PopulateButtons();

					_Host.ShowStatusInfo( "Loading " + fenuName + "...", 100, true );
					// TODO: Move to background worker
					newFenuPanel = ReflectOnFenu( newFenuPanel );

					_Host.DrawOnCanvas( newFenuPanel );
					_Host.ShowStatusInfo( "Ready", -1, false );

					return;
				}
			}
		}

		public void Close()
		{
			// Default close operation
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

		private Fenu FindWhichFenu( out Control focused )
		{
			focused = _Host.FindFocusedControl();

			Control ctrlParent = focused;
			while( ( ctrlParent = ctrlParent.Parent ) != null ) {
				if( ctrlParent.GetType() == typeof(Fenu) ) {
					return ctrlParent as Fenu;
				}
			}

			return null;
		}

		public void Cut()
		{
			Control focused = null;
			Fenu fenu = FindWhichFenu( out focused );
			if( fenu != null )
				fenu.Cut( focused );
		}

		public void Copy()
		{
			Control focused = null;
			Fenu fenu = FindWhichFenu( out focused );
			if( fenu != null )
				fenu.Copy( focused );
		}

		public void Paste()
		{
			Control focused = null;
			Fenu fenu = FindWhichFenu( out focused );
			if( fenu != null )
				fenu.Paste( focused );
		}

		public void Delete()
		{
			Control focused = null;
			Fenu fenu = FindWhichFenu( out focused );
			if( fenu != null )
				fenu.Delete( focused );
		}

		#endregion

		#endregion
	}
}
