using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Language.XML;
using System.Xml.Serialization;

namespace Language.Display
{
	public partial class ObjectTree : TreeView
	{
		private enum ObjectImage
		{
			Root,
			Product,
			Collector,
			Language,
			ID
		}

		class MessageCollector : Dictionary<string, XmlMessageState>
		{
		}
		class LanguageCollector : Dictionary<string, MessageCollector>
		{
		}

		private XmlSerializer Serializer;
		private List<XmlResmapState> ResmapStateList;

		private string WorkspacePath = string.Empty;
		private TreeNode TreeRoot;

		#region Contructor

		public ObjectTree()
		{
			InitializeComponent();
			Serializer = new XmlSerializer( typeof( XmlResmapState ), "" );
			ResmapStateList = new List<XmlResmapState>();
		}

		#endregion

		#region Basic Opreation

		public void Reset()
		{
			this.WorkspacePath = string.Empty;
			this.Nodes.Clear();
		}

		public void Load( string Path )
		{
			Reset();
			if( TestPath( Path ) ) {
				CompileTree();
				this.Nodes.Add( this.TreeRoot );
			}
		}

		#endregion

		#region Search

		public string FindString( string Path, string ID, string Language )
		{
			if( Path.StartsWith( WorkspacePath ) ) {
				Path = Path.Remove( 0, WorkspacePath.Length + 1 );
				string[] pathStage = Path.Split( '\\' );
				TreeNode temp = this.TreeRoot;
				if( temp == null ) {
					return string.Empty;
				}
				// trace into deepmost product
				for( int i = 0; i < pathStage.Length; i++ ) {
					if( temp.Nodes[ pathStage[ i ] ] != null ) {
						temp = temp.Nodes[ pathStage[ i ] ];
					}
					else {
						break;
					}
				}

				// search for resource bottom up
				while( temp != null ) {
					if( temp.Nodes[ "String" ] != null ) {
						LanguageCollector Languages = temp.Nodes[ "String" ].Tag as LanguageCollector;
						if( Languages.ContainsKey( Language ) && Languages[ Language ].ContainsKey( ID ) ) {
							return Languages[ Language ][ ID ].Content;
						}
					}
					temp = temp.Parent;
				}
			}
			return string.Empty;
		}

		public string[] FindIDsByContent( string content )
		{
			string CONTENT = content.ToUpper();
			List<string> IDList = new List<string>();
			foreach( XmlResmapState Resmap in ResmapStateList ) {
				foreach( XmlMessageState Message in Resmap.IncludedMessages ) {
					if( Message.Content != null && Message.Content.ToUpper().Contains( CONTENT ) ) {
						IDList.Add( Message.ID );
					} 
				}
			}
			return IDList.ToArray();
		}

		#endregion

		#region Helper Functions

		private bool TestPath( string Path )
		{
			if( Path == null || !Directory.Exists( Path ) ) {
				return false;
			}
			this.WorkspacePath = Path;
			return true;
		}


		private bool IsLanguageFolder( string path )
		{
			string[] subdirs = Directory.GetDirectories( path );
			foreach( string subdir in subdirs ) {
				if( Path.GetFileName( subdir ).ToUpper().CompareTo( "STRING" ) == 0 ) {
					return true;
				}
			}
			return false;
		}

		#endregion

		#region Tree Compiling

		#region Tree Construct

		private void CompileTree()
		{
			this.TreeRoot = new TreeNode( this.WorkspacePath, (int)ObjectImage.Root, (int)ObjectImage.Root );
			ConstructProductNode( this.TreeRoot, this.WorkspacePath );
		}

		private void ConstructProductNode( TreeNode node, string path )
		{
			// Clear dummy node if exists
			node.Nodes.Clear();

			try {
				string[] subdirs = Directory.GetDirectories( path );

				foreach( string subdir in subdirs ) {
					string dirname = Path.GetFileName( subdir );

					// Set string/product folder image
					if( IsLanguageFolder( subdir ) ) {
						ContructStringNode( node, subdir );
					}
					else if( dirname.IndexOf( '_' ) == 0 ) {
						node.Nodes.Add( dirname, dirname.Substring( 1 ), (int)ObjectImage.Product, (int)ObjectImage.Product );
						TreeNode ProductNode = node.Nodes[ dirname ];
						ProductNode.Tag = subdir;
						ConstructProductNode( ProductNode, subdir );
					}
				}

				TreeNode StringNode = node.Nodes[ "String" ];

				if( StringNode != null ) {
					LanguageCollector Languages = StringNode.Tag as LanguageCollector;
					foreach( string Key in Languages.Keys ) {
						TreeNode LanguageNode = new TreeNode( Key, (int)ObjectImage.Language, (int)ObjectImage.Language );
						StringNode.Nodes.Add( LanguageNode );
						foreach( string Subkey in Languages[ Key ].Keys ) {
							TreeNode MessageNode = new TreeNode( Subkey, (int)ObjectImage.ID, (int)ObjectImage.ID );
							LanguageNode.Nodes.Add( MessageNode );
						}
					}
				}
			}
			catch( UnauthorizedAccessException ) // Ignore that directory if limited
			{
			}
			finally {
				// Clear dummy tag
				node.Tag = null;
			}
		}

		private void ContructStringNode( TreeNode node, string subdir )
		{
			TreeNode StringNode = node.Nodes[ "String" ];

			if( StringNode == null ) {
				node.Nodes.Add( "String", "String", (int)ObjectImage.Collector, (int)ObjectImage.Collector );
				StringNode = node.Nodes[ "String" ];
				StringNode.Tag = new LanguageCollector();
			}


			LanguageCollector Languages = StringNode.Tag as LanguageCollector;
			string language = Path.GetFileName( subdir ).ToUpper();
			string[] files = Directory.GetFiles( subdir + @"\string" );

			if( !Languages.ContainsKey( language ) ) {
				Languages[ language ] = new MessageCollector();
			}

			foreach( string file in files ) {
				if( Path.GetExtension( file ).ToUpper() == ".XML" ) {
					AddStrings( StringNode, file, language );
				}
			}
		}

		#endregion

		#region Load Xml

		private void AddStrings( TreeNode StringBranch, string filename, string language )
		{
			LanguageCollector Languages = StringBranch.Tag as LanguageCollector;
			XmlResmapState ResmapState;

			RectifyXmlFormat( filename );

			using( StreamReader Reader = new StreamReader( filename ) ) {
				try {
					ResmapState = Serializer.Deserialize( Reader ) as XmlResmapState;
					if( ResmapState != null ) {
						ResmapState.Filename = filename;
						ResmapStateList.Add( ResmapState );

						foreach( XmlMessageState mes in ResmapState.IncludedMessages ) {
							mes.Parent = ResmapState;
							if( !Languages[ language ].ContainsKey( mes.ID ) ) {
								Languages[ language ][ mes.ID ] = mes;
							}
						}
					}
				}
				catch( InvalidOperationException e ) {
					MessageBox.Show( "Error: " + filename + " " + e.Message );
				}
			}
		}

		private void RectifyXmlFormat( string XMLPath )
		{
			// Temporary solution for patch
			bool hasChanged = false;
			List<string> output = new List<string>();
			using( StreamReader file = new StreamReader( XMLPath ) ) {
				while( !file.EndOfStream ) {
					string line = file.ReadLine();

					if( line.Contains( " id=" ) ) {
						line = line.Replace( " id=", " ID=" );
						hasChanged = true;
					}

					output.Add( line );
				}
			}
			if( hasChanged ) {
				using( StreamWriter file = new StreamWriter( XMLPath ) ) {
					foreach( string line in output )
						file.WriteLine( line );
				}
			}
		}

		#endregion

		#endregion

	}
}
