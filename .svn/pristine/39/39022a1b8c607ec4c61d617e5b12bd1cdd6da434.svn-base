using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.ComponentModel;

namespace Fenubars.XML
{
	[XmlRoot( "root" )]
	public class XMLGlobalState
	{
		#region Fenu global states

		private bool _Button3D = true;
		[Category( "Global" )]
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

		private int _Alignment = 1;
		[Category( "Global" )]
		[DefaultValue( 1 )]
		public int Alignment
		{
			get
			{
				return _Alignment;
			}
			set
			{
				_Alignment = value;
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
