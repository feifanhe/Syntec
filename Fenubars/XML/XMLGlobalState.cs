using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.ComponentModel;
using System.Drawing;

namespace Fenubars.XML
{
	[XmlRoot( "root" )]
	public class XMLGlobalState
	{
		#region Fenu global states

		private bool _Button3D = true;
		[Category( "Global" )]
		[XmlElement( "Button3D" )]
		[DefaultValue( true )]
		public bool Button3D
		{
			get
			{
				return _Button3D;
			}
			set
			{
				_Button3D = value;
			}
		}

		private int _Level3D = 4;
		[Category( "Global" )]
		[XmlElement( "Level3D" )]
		[DefaultValue( 4 )]
		public int Level3D
		{
			get
			{
				return _Level3D;
			}
			set
			{
				_Level3D = value;
			}
		}

		private bool _NoFunc = false;
		[Category( "Global" )]
		[XmlElement( "NoFunc" )]
		[DefaultValue( false )]
		public bool NoFunc
		{
			get
			{
				return _NoFunc;
			}
			set
			{
				_NoFunc = value;
			}
		}

		private bool _NoLR = false;
		[Category( "Global" )]
		[XmlElement( "NoLR" )]
		[DefaultValue( false )]
		public bool NoLR
		{
			get
			{
				return _NoLR;
			}
			set
			{
				_NoLR = value;
			}
		}

		private bool _BigLR = false;
		[Category( "Global" )]
		[XmlElement( "BigLR" )]
		[DefaultValue( false )]
		public bool BigLR
		{
			get
			{
				return _BigLR;
			}
			set
			{
				_BigLR = value;
			}
		}

		private bool _TextOverPic = false;
		[Category( "Global" )]
		[XmlElement( "TextOverPic" )]
		[DefaultValue( false )]
		public bool TextOverPic
		{
			get
			{
				return _TextOverPic;
			}
			set
			{
				_TextOverPic = value;
			}
		}

		private string _Title;
		[Category( "Global" )]
		[XmlElement( "Title" )]
		[ReadOnly( true )]
		[Browsable( false )]
		public string Title
		{
			get
			{
				return _Title;
			}
			set
			{
				_Title = value;
			}
		}

		private int _AlignmentIndex = 1;
		[XmlElement( "Alignment" )]
		[DefaultValue( 1 )]
		[Browsable(false)]
		public int AlignmentIndex
		{
			get
			{
				return _AlignmentIndex;
			}
			set
			{
				_AlignmentIndex = value;
			}
		}

		[XmlIgnore]
		[Category( "Global" )]
		public ContentAlignment Alignment
		{
			get
			{
				switch( _AlignmentIndex ) {
					case 1:
						return ContentAlignment.TopLeft;
					case 2:
						return ContentAlignment.TopCenter;
					case 3:
						return ContentAlignment.TopRight;
					case 4:
						return ContentAlignment.MiddleLeft;
					case 5:
						return ContentAlignment.MiddleCenter;
					case 6:
						return ContentAlignment.MiddleRight;
					case 7:
						return ContentAlignment.BottomLeft;
					case 8:
						return ContentAlignment.BottomCenter;
					case 9:
						return ContentAlignment.BottomRight;
					default:
						return ContentAlignment.TopLeft;
				}
			}
			set
			{
				switch( value ) {
					case ContentAlignment.TopLeft:
						this._AlignmentIndex = 1;
						break;
					case ContentAlignment.TopCenter:
						this._AlignmentIndex = 2;
						break;
					case ContentAlignment.TopRight:
						this._AlignmentIndex = 3;
						break;
					case ContentAlignment.MiddleLeft:
						this._AlignmentIndex = 4;
						break;
					case ContentAlignment.MiddleCenter:
						this._AlignmentIndex = 5;
						break;
					case ContentAlignment.MiddleRight:
						this._AlignmentIndex = 6;
						break;
					case ContentAlignment.BottomLeft:
						this._AlignmentIndex = 7;
						break;
					case ContentAlignment.BottomCenter:
						this._AlignmentIndex = 8;
						break;
					case ContentAlignment.BottomRight:
						this._AlignmentIndex = 9;
						break;
					default:
						this._AlignmentIndex = 1;
						break;
				}
			}
		}

		#endregion

		#region Fenus contained in the file

		private List<FenuState> _IncludedFenus = new List<FenuState>();
		[XmlElement( "fenu" )]
		[Browsable( false )]
		public List<FenuState> IncludedFenus
		{
			get
			{
				return _IncludedFenus;
			}
			set
			{
				_IncludedFenus = value;
			}
		}

		#endregion
	}
}
