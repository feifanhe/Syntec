using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Design;
using System.Windows.Forms.Design;

namespace Fenubars.XML
{
	public class FenuButtonState : Fenubars.Events.NotifyProperyChangedBase
	{
		#region Name

		private string _Name;
		[XmlAttribute( "name" )]
		[Category( "Fenu Button" )]
		[ButtonType( ButtonTypes.EscapeButton | ButtonTypes.NormalButton | ButtonTypes.NextButton )]
		public string Name
		{
			get
			{
				return _Name;
			}
			set
			{
				NameSpecified = this.CheckPropertyChanged<string>( "Name", ref _Name, ref value );
			}
		}

		private bool _NameSpecified = false;
		[XmlIgnore]
		[Browsable( false )]
		public bool NameSpecified
		{
			get
			{
				return _NameSpecified;
			}
			set
			{
				_NameSpecified = value;
			}
		}

		#endregion

		#region Position

		private int _Position;
		[XmlElement( "position" )]
		[Category( "Fenu Button" )]
		[ReadOnly( true )]
		[ButtonType( ButtonTypes.NormalButton )]
		public int Position
		{
			get
			{
				return _Position;
			}
			set
			{
				PositionSpecified = this.CheckPropertyChanged<int>( "Position", ref _Position, ref value );
			}
		}

		private bool _PositionSpecified = false;
		[XmlIgnore]
		[Browsable( false )]
		public bool PositionSpecified
		{
			get
			{
				return _PositionSpecified;
			}
			set
			{
				_PositionSpecified = value;
			}
		}

		#endregion

		#region Title

		private string _Title;
		[XmlElement( "title" )]
		[Category( "Appearance" )]
		[ButtonType( ButtonTypes.NormalButton )]
		public string Title
		{
			get
			{
				return _Title;
			}
			set
			{
				TitleSpecified = this.CheckPropertyChanged<string>( "Title", ref  _Title, ref value );
			}
		}

		private bool _TitleSpecified = false;
		[XmlIgnore]
		[Browsable( false )]
		public bool TitleSpecified
		{
			get
			{
				return _TitleSpecified;
			}
			set
			{
				_TitleSpecified = value;
			}
		}

		#endregion

		#region Alignment

		//private int _AlignmentIndex = 0;
		//[XmlElement( "Alignment" )]
		//[DefaultValue( 0 )]
		//[Browsable( false )]
		//public int AlignmentIndex
		//{
		//    get
		//    {
		//        return _AlignmentIndex;
		//    }
		//    set
		//    {
		//        _AlignmentIndex = value;
		//    }
		//}

		//[XmlIgnore]
		//[Browsable( false )]
		//public bool AlignmentIndexSpecified
		//{
		//    get
		//    {
		//        return _AlignmentIndex == 0 ? false : true;
		//    }
		//}

		//[XmlIgnore]
		//[Category( "Appearance" )]
		//[ButtonType( ButtonTypes.EscapeButton | ButtonTypes.NormalButton | ButtonTypes.NextButton )]
		//public ContentAlignment Alignment
		//{
		//    get
		//    {
		//        switch( _AlignmentIndex ) {
		//            case 1:
		//                return ContentAlignment.TopLeft;
		//            case 2:
		//                return ContentAlignment.TopCenter;
		//            case 3:
		//                return ContentAlignment.TopRight;
		//            case 4:
		//                return ContentAlignment.MiddleLeft;
		//            case 5:
		//                return ContentAlignment.MiddleCenter;
		//            case 6:
		//                return ContentAlignment.MiddleRight;
		//            case 7:
		//                return ContentAlignment.BottomLeft;
		//            case 8:
		//                return ContentAlignment.BottomCenter;
		//            case 9:
		//                return ContentAlignment.BottomRight;
		//            default:
		//                return ContentAlignment.TopLeft;
		//        }
		//    }
		//    set
		//    {
		//        switch( value ) {
		//            case ContentAlignment.TopLeft:
		//                this._AlignmentIndex = 1;
		//                break;
		//            case ContentAlignment.TopCenter:
		//                this._AlignmentIndex = 2;
		//                break;
		//            case ContentAlignment.TopRight:
		//                this._AlignmentIndex = 3;
		//                break;
		//            case ContentAlignment.MiddleLeft:
		//                this._AlignmentIndex = 4;
		//                break;
		//            case ContentAlignment.MiddleCenter:
		//                this._AlignmentIndex = 5;
		//                break;
		//            case ContentAlignment.MiddleRight:
		//                this._AlignmentIndex = 6;
		//                break;
		//            case ContentAlignment.BottomLeft:
		//                this._AlignmentIndex = 7;
		//                break;
		//            case ContentAlignment.BottomCenter:
		//                this._AlignmentIndex = 8;
		//                break;
		//            case ContentAlignment.BottomRight:
		//                this._AlignmentIndex = 9;
		//                break;
		//            default:
		//                this._AlignmentIndex = 0;
		//                break;
		//        }
		//    }
		//}

		#endregion

		#region State

		private ButtonState _State = ButtonState.enable;
		[XmlElement( "state" )]
		[Category( "Behavior" )]
		[ButtonType( ButtonTypes.EscapeButton | ButtonTypes.NormalButton | ButtonTypes.NextButton )]
		[DefaultValue( ButtonState.enable )]
		public ButtonState State
		{
			get
			{
				return _State;
			}
			set
			{
				StateSpecified = this.CheckPropertyChanged<ButtonState>( "State", ref _State, ref value );
			}
		}

		private bool _StateSpecified = false;
		[XmlIgnore]
		[Browsable( false )]
		public bool StateSpecified
		{
			get
			{
				return _StateSpecified;
			}
			set
			{
				_StateSpecified = value;
			}
		}

		#endregion

		#region Picture

		private string _Picture;
		[XmlElement( "picture" )]
		[Category( "Appearance" )]
		[ButtonType( ButtonTypes.NormalButton )]
		public string Picture
		{
			get
			{
				return _Picture;
			}
			set
			{
				PictureSpecified = this.CheckPropertyChanged<string>( "Picture", ref  _Picture, ref value );
			}
		}

		private bool _PictureSpecified = false;
		[XmlIgnore]
		[Browsable( false )]
		public bool PictureSpecified
		{
			get
			{
				return _PictureSpecified;
			}
			set
			{
				_PictureSpecified = value;
			}
		}

		#endregion

		#region ForeColor

		private string _ForeColorArgb = "0,0,0";
		[XmlElement( "forecolor" )]
		[Browsable( false )]
		[DefaultValue( "0,0,0" )]
		public string ForeColorArgb
		{
			get
			{
				return _ForeColorArgb;
			}
			set
			{
				ForeColorArgbSpecified =
					this.CheckPropertyChanged<string>( "ForeColorArgb", ref _ForeColorArgb, ref value );
			}
		}

		private bool _ForeColorArgbSpecified;
		[XmlIgnore]
		[Browsable( false )]
		public bool ForeColorArgbSpecified
		{
			get
			{
				return _ForeColorArgbSpecified;
			}
			set
			{
				_ForeColorArgbSpecified = value;
			}
		}

		[XmlIgnore]
		[Category( "Appearance" )]
		[ButtonType( ButtonTypes.NormalButton )]
		public Color ForeColor
		{
			get
			{
				return ColorConverter.StringToColor( ForeColorArgb );
			}
			set
			{
				ForeColorArgb = ColorConverter.ColorToString( value );
			}
		}

		#endregion

		#region BackColor

		private string _BackColorArgb = "240,240,240";
		[XmlElement( "backcolor" )]
		[Browsable( false )]
		[ButtonType( ButtonTypes.NormalButton )]
		[DefaultValue( "240,240,240" )]
		public string BackColorArgb
		{
			get
			{
				return _BackColorArgb;
			}
			set
			{
				BackColorArgbSpecified =
					this.CheckPropertyChanged<string>( "BackColorArgb", ref _BackColorArgb, ref value );
			}
		}

		private bool _BackColorArgbSpecified;
		[XmlIgnore]
		[Browsable( false )]
		public bool BackColorArgbSpecified
		{
			get
			{
				return _BackColorArgbSpecified;
			}
			set
			{
				_BackColorArgbSpecified = value;
			}
		}

		[XmlIgnore]
		[Category( "Appearance" )]
		[ButtonType( ButtonTypes.NormalButton )]
		public Color BackColor
		{
			get
			{
				return ColorConverter.StringToColor( BackColorArgb );
			}
			set
			{
				BackColorArgb = ColorConverter.ColorToString( value );
			}
		}

		#endregion

		#region LightOnColor

		private string _LightOnColorArgb = "240,240,240";
		[XmlElement( "LightOnColor" )]
		[Browsable( false )]
		[ButtonType( ButtonTypes.NormalButton )]
		[DefaultValue( "240,240,240" )]
		public string LightOnColorArgb
		{
			get
			{
				return _LightOnColorArgb;
			}
			set
			{
				LightOnColorArgbSpecified =
					this.CheckPropertyChanged<string>( "LightOnColorArgb", ref _LightOnColorArgb, ref value );
			}
		}

		private bool _LightOnColorArgbSpecified;
		[XmlIgnore]
		[Browsable( false )]
		public bool LightOnColorArgbSpecified
		{
			get
			{
				return _LightOnColorArgbSpecified;
			}
			set
			{
				_LightOnColorArgbSpecified = value;
			}
		}

		[XmlIgnore]
		[Category( "Appearance" )]
		[ButtonType( ButtonTypes.NormalButton )]
		public Color LightOnColor
		{
			get
			{
				return ColorConverter.StringToColor( LightOnColorArgb );
			}
			set
			{
				LightOnColorArgb = ColorConverter.ColorToString( value );
			}
		}

		#endregion

		#region HoldMode

		private bool _HoldMode = false;
		[XmlElement( "HoldMode" )]
		[Category( "Behavior" )]
		[ButtonType( ButtonTypes.NormalButton )]
		[DefaultValue( false )]
		public bool HoldMode
		{
			get
			{
				return _HoldMode;
			}
			set
			{
				HoldModeSpecified = this.CheckPropertyChanged<bool>( "HoldMode", ref _HoldMode, ref value );
			}
		}

		private bool _HoldModeSpecified = false;
		[XmlIgnore]
		[Browsable( false )]
		public bool HoldModeSpecified
		{
			get
			{
				return _HoldModeSpecified;
			}
			set
			{
				_HoldModeSpecified = value;
			}
		}

		#endregion

		#region Link

		private string _Link;
		[XmlElement( "link" )]
		[Category( "Behavior" )]
		[ButtonType( ButtonTypes.EscapeButton | ButtonTypes.NormalButton | ButtonTypes.NextButton )]
		[TypeConverter( typeof( FenuButtonState.LinkConverter ) )]
		public string Link
		{
			get
			{
				return _Link;
			}
			set
			{
				if( value == string.Empty ) {
					value = null;
				}
				LinkSpecified = this.CheckPropertyChanged<string>( "Link", ref _Link, ref value );
			}
		}

		private bool _LinkSpecified;
		[XmlIgnore]
		[Browsable( false )]
		public bool LinkSpecified
		{
			get
			{
				return _LinkSpecified;
			}
			set
			{
				_LinkSpecified = value;
			}
		}

		public class LinkConverter : StringConverter
		{
			public override bool GetStandardValuesSupported( ITypeDescriptorContext context )
			{
				return true;
			}
			public override bool GetStandardValuesExclusive( ITypeDescriptorContext context )
			{
				return false;
			}
			public override StandardValuesCollection GetStandardValues( ITypeDescriptorContext context )
			{
				return new StandardValuesCollection( new string[] { } );
			}
		}

		#endregion

		#region Visible

		private bool _Visible = true;
		[XmlElement( "visible" )]
		[Category( "Behavior" )]
		[ButtonType( ButtonTypes.EscapeButton | ButtonTypes.NormalButton | ButtonTypes.NextButton )]
		[DefaultValue( true )]
		public bool Visible
		{
			get
			{
				return _Visible;
			}
			set
			{
				VisibleSpecified = this.CheckPropertyChanged<bool>( "Visible", ref _Visible, ref value );
			}
		}

		private bool _VisibleSpecified = false;
		[XmlIgnore]
		[Browsable( false )]
		public bool VisibleSpecified
		{
			get
			{
				return _VisibleSpecified;
			}
			set
			{
				_VisibleSpecified = value;
			}
		}

		#endregion

		#region UserLevel

		private int _UserLevel = 99;
		[XmlElement( "userlevel" )]
		[Category( "Behavior" )]
		[ButtonType( ButtonTypes.NormalButton | ButtonTypes.NextButton )]
		[DefaultValue( 99 )]
		public int UserLevel
		{
			get
			{
				return _UserLevel;
			}
			set
			{
				UserLevelSpecified = this.CheckPropertyChanged<int>( "UserLevel", ref _UserLevel, ref value );
			}
		}

		private bool _UserLevelSpecified = false;
		[XmlIgnore]
		[Browsable( false )]
		public bool UserLevelSpecified
		{
			get
			{
				return _UserLevelSpecified;
			}
			set
			{
				_UserLevelSpecified = value;
			}
		}

		#endregion

		#region Action

		// Remember to sync with MiscOptions:ActionCollection

		private List<string> _Actions = new List<string>();
		[XmlArray( "actions" )]
		[XmlArrayItem( "action", typeof( string ) )]
		[Category( "Behavior" )]
		[ButtonType( ButtonTypes.EscapeButton | ButtonTypes.NormalButton | ButtonTypes.NextButton )]
		[EditorAttribute( typeof( FenuButtonState.ActionsConverter ), typeof( System.Drawing.Design.UITypeEditor ) )]
		public List<string> Actions
		{
			get
			{
				return _Actions;
			}
			set
			{
				_Actions = value;
			}
		}

		[XmlIgnore]
		[Browsable( false )]
		public bool ActionsSpecified
		{
			get
			{
				if( _Actions.Count <= 1 ) {
					return false;
				}
				else {
					return true;
				}
			}
		}

		[XmlElement( "action" )]
		[Browsable( false )]
		public string Action
		{
			get
			{
				return _Actions[ 0 ];
			}
			set
			{
				if( value != string.Empty ) {
					_Actions.Add( value );
				}
			}
		}

		[XmlIgnore]
		[Browsable( false )]
		public bool ActionSpecified
		{
			get
			{
				if( _Actions.Count == 1 ) {
					return true;
				}
				else {
					return false;
				}
			}
		}

		public class ActionsConverter : UITypeEditor
		{
			public override UITypeEditorEditStyle GetEditStyle( ITypeDescriptorContext context )
			{
				return UITypeEditorEditStyle.Modal;
			}

			public override object EditValue( ITypeDescriptorContext context, IServiceProvider provider, object value )
			{
				IWindowsFormsEditorService service = (IWindowsFormsEditorService)provider.GetService( typeof( IWindowsFormsEditorService ) );

				if( service != null ) {
					ActionsSelector.ActionsSelectDialog dialog = new ActionsSelector.ActionsSelectDialog();
					dialog.ShowDialog( value as List<string> );
				}
				return value;
			}
		}

		#endregion

		#region Password

		private PasswordActions _PasswordActions = new PasswordActions();
		[XmlElement( "pwd", IsNullable = false )]
		[Category( "Behavior" )]
		[ReadOnly( true )]
		[ButtonType( ButtonTypes.EscapeButton | ButtonTypes.NormalButton )]
		public PasswordActions PasswordActions
		{
			get
			{
				return _PasswordActions;
			}
			set
			{
				_PasswordActions = value;
			}
		}

		[XmlIgnore]
		[Browsable( false )]
		public bool PasswordActionsSpecified
		{
			get
			{
				if( _PasswordActions.Password != null &&
					_PasswordActions.Password != string.Empty ) {
					return true;
				}
				else {
					return false;
				}
			}
		}

		#endregion

	}
}
