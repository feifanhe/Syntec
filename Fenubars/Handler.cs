#define CONSTANT_KEY_COUNT

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
using Fenubars.Editor;


namespace Fenubars
{
	public partial class Handler : IModule
	{
		// XML serializer fields
		private XmlSerializerNamespaces Namespace;
		private XmlSerializer Serializer;

		// File state holder
		private XMLGlobalState globalFenuState;

		private ObjectTree CompiledTree;
		private string XMLPath = string.Empty;

		#region Acquire focus object by event

		private void FocusedObjectAvailable( Type type, FenuButtonState data )
		{
			if( type == typeof( Fenu ) ) {
				// Set to null first, since fenu state don't have some attributes
				_Host.SetPropertyGrid( null, null );
				_Host.ShowProperties( globalFenuState );
			}
			else {
				// Set object first, and then filter the attributes
				_Host.ShowProperties( data );
				_Host.SetPropertyGrid(
					new AttributeCollection(
						new Attribute[] { 
							new CategoryAttribute( "Fenu Button" ),
							new CategoryAttribute( "Behavior" ),
							new CategoryAttribute( "Appearance" )
						} ),
					SelectedProperties( type ) );
				// Reset object
				_Host.ShowProperties( data );
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

		public void NewFile( string XMLPath )
		{
			this.XMLPath = XMLPath;
			InitiateSerializer();
			this.globalFenuState = new XMLGlobalState();
		}

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

					if( line.Contains( "<Action" ) )
						line = line.Replace( "<Action", "<action" );

					if( line.Contains( "</Action" ) )
						line = line.Replace( "</Action", "</action" );

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
				globalFenuState = Serializer.Deserialize( Reader ) as XMLGlobalState;
			}
		}

		public void Open()
		{
			this.CompiledTree = new ObjectTree( XMLPath, globalFenuState.IncludedFenus );
			this.CompiledTree.NewFenu += new ObjectTree.IndefiniteFenuOperationEventHandler( NewFenu );
			this.CompiledTree.PasteFenu += new ObjectTree.IndefiniteFenuOperationEventHandler( PasteFenu );
			this.CompiledTree.CutFenu += new ObjectTree.DefiniteFenuOperationEventHandler( CutFenu );
			this.CompiledTree.CopyFenu += new ObjectTree.DefiniteFenuOperationEventHandler( CopyFenu );
			this.CompiledTree.DeleteFenu += new ObjectTree.DefiniteFenuOperationEventHandler( DeleteFenu );
			this.CompiledTree.RenameFenu += new ObjectTree.RenameFenuOperationEventHandler( RenameFenu );
			this._Host.ShowObjects( CompiledTree );
		}

		// Figure out 5 or 8 key by filename
		private int NormalButtonCount()
		{
			const int defaultButtonCount = 8;

#if CONSTANT_KEY_COUNT
			return defaultButtonCount;
#else
			string fileName = Path.GetFileNameWithoutExtension( XMLPath );
			string digit = fileName.Substring( fileName.Length - 1 );

			int result = -1;
			if( int.TryParse( digit, out result ) )
				return result;
			else
				return defaultButtonCount;
#endif
		}

		public void Open( string fenuName )
		{
			OpenFenu( fenuName );
			return;
		}

		public Fenu OpenFenu( string fenuName )
		{
			if( fenuName == String.Empty ) {
				return null;
			}

			if( _Host.FindControlByName( fenuName ) != null ) {
				_Host.FindControlByName( fenuName ).Focus();
				return _Host.FindControlByName( fenuName ) as Fenu;
			}

			_Host.ShowStatusInfo( "Loading " + fenuName + "...", 100, true );

			// TODO: Imporve search method
			foreach( FenuState parsedFenu in globalFenuState.IncludedFenus ) {
				if( parsedFenu.Name == fenuName ) {
					Fenu newFenuPanel = new Fenu( this.globalFenuState, parsedFenu, NormalButtonCount() );
					newFenuPanel.OnDataAvailable += new Fenu.DataAvailableEventHandler( FocusedObjectAvailable );
					newFenuPanel.Linkage += new Fenu.LinkageEventHandler( OpenFenu );
					newFenuPanel.Modified += new Fenu.FenuModifiedHandler( FenuModified );
					newFenuPanel.OnGetResource += new Fenu.GetResourceEventHandler( GetResource );

					newFenuPanel.PopulateButtons();

					// TODO: Move to background worker
					GenerateFenuImage( newFenuPanel );
					//newFenuPanel.UpdateFromImage();

					_Host.DrawOnCanvas( newFenuPanel );
					_Host.ShowStatusInfo( "Ready", -1, false );

					return newFenuPanel;
				}
			}
			_Host.ShowStatusInfo( "Ready", -1, false );

			return null;
		}

		public void Close()
		{
			// Default close operation
		}

		private void FenuModified()
		{
			_Host.Modified( true );
		}

		private string GetResource( string ID )
		{
			return _Host.GetResource( this.XMLPath, ID );
		}

		#endregion

		#region File processing

		public void Save()
		{
			SaveAs( this.XMLPath );
			_Host.Modified( false );
		}

		public void SaveAs( string XMLPath )
		{
			try {
				StreamWriter writer = new StreamWriter( XMLPath );
				XmlWriterSettings settings = new XmlWriterSettings();
				settings.Indent = true;
				settings.IndentChars = "\t";
				using( XmlWriter xmlWriter = XmlWriter.Create( writer, settings ) ) {
					Serializer.Serialize( xmlWriter, globalFenuState, Namespace );
				}
			}
			catch( IOException e ) {
				MessageBox.Show( "The file is busy!" );
			}
		}

		#endregion

		#region Edit operations

		private Fenu FindWhichFenu( out Control focused )
		{
			focused = _Host.FindFocusedControl();

			Control ctrlParent = focused;
			while( ( ctrlParent = ctrlParent.Parent ) != null ) {
				if( ctrlParent.GetType() == typeof( Fenu ) ) {
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

		public SearchResult[] SearchForIDUsers( string[] IDs )
		{
			List<SearchResult> results = new List<SearchResult>();

			foreach( FenuState fenu in this.globalFenuState.IncludedFenus ) {
				foreach( FenuButtonState button in fenu.NormalButtonList ) {
					foreach( string id in IDs ) {
						if( button.Title != null && button.Title.Contains( id ) ) {
							SearchResult result = new SearchResult();
							result.ObjectName = fenu.Name;
							result.ItemName = "F" + button.Position.ToString();
							result.ItemValue = GetResource( id );
							result.ShowResult += new SearchResult.ShowResultHandler( Open );
							results.Add( result );
							break;
						}
					}
				}
			}

			return results.ToArray();
		}

		#endregion

		#region Fenu operations

		public void NewFenu()
		{
			FenuState newFenuState = new FenuState();
			newFenuState.Name = "New Fenu";
			this.globalFenuState.IncludedFenus.Add( newFenuState );
			this.RefreshObjects();
		}

		public void PasteFenu()
		{
			FenuState fenuState = ClipBoardManager<FenuState>.GetFromClipboard();

			if( fenuState == null ) {
				return;
			}

			string fenuName = fenuState.Name + " - Copy ";
			int length = fenuName.Length;
			int copies = 1;
			bool terminal;
			do {
				terminal = true;
				foreach( FenuState parsedFenu in this.globalFenuState.IncludedFenus ) {
					if( parsedFenu.Name == fenuName ) {
						copies++;
						fenuName.Remove( length );
						fenuName += copies.ToString();
						terminal = false;
						break;
					}
				}
			} while( !terminal );
			fenuState.Name = fenuName;
			this.globalFenuState.IncludedFenus.Add( fenuState );
			this.FenuModified();
			this.RefreshObjects();
		}

		public void CutFenu( string fenuName )
		{
			this.CopyFenu( fenuName );
			this.DeleteFenu( fenuName );
		}

		public void CopyFenu( string fenuName )
		{
			foreach( FenuState parsedFenu in this.globalFenuState.IncludedFenus ) {
				if( parsedFenu.Name == fenuName ) {
					ClipBoardManager<FenuState>.CopyToClipboard( parsedFenu );
					break;
				}
			}
		}

		public void DeleteFenu( string fenuName )
		{
			foreach( FenuState parsedFenu in this.globalFenuState.IncludedFenus ) {
				if( parsedFenu.Name == fenuName ) {
					this.globalFenuState.IncludedFenus.Remove( parsedFenu );
					break;
				}
			}
			this.FenuModified();
			this.RefreshObjects();
		}

		public bool RenameFenu( string oldName, string newName )
		{
			foreach( FenuState parsedOldFenu in this.globalFenuState.IncludedFenus ) {
				if( parsedOldFenu.Name == oldName ) {
					foreach( FenuState parsedNewFenu in this.globalFenuState.IncludedFenus ) {
						if( parsedNewFenu.Name == newName ) {
							return false;	// fail
						}
					}
					parsedOldFenu.Name = newName;
					if( _Host.FindControlByName( oldName ) != null ) {
						Fenu openedFenu = ( _Host.FindControlByName( oldName ) as Fenu );
						openedFenu.Name = newName;
						openedFenu.TitleText = newName;
					}
					this.FenuModified();
					return true;	// success
				}
			}
			return false;	// fail, impossible to reach here
		}

		#endregion

		#region Owning object operations

		public void RefreshObjects()
		{
			Open();
		}

		#endregion

		#endregion
	}
}
