using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Fenubars.XML
{
	[Serializable]
	public class FenuButtonState : Fenubars.Events.NotifyProperyChangedBase
	{
		#region Name

		private string _Name;
		[XmlAttribute( "name" )]
		[Category( "Fenu Button" )]
		[ReadOnly( true )]
		[ButtonType( ButtonTypes.EscapeButton | ButtonTypes.NormalButton | ButtonTypes.NextButton )]
		public string Name {
			get {
				return _Name;
			}
			set {
				this.CheckPropertyChanged<string>( "Name", ref _Name, ref value );
			}
		}

		//private bool _NameSpecified = false;
		//[XmlIgnore]
		//public bool NameSpecified {
		//    get {
		//        return _NameSpecified;
		//    }
		//    set {
		//        _NameSpecified = value;
		//    }
		//}

		#endregion

		#region Position

		private int _Position;
		[XmlElement( "position" )]
		[Category( "Fenu Button" )]
		[ButtonType( ButtonTypes.NormalButton )]
		public int Position {
			get {
				return _Position;
			}
			set {
				PositionSpecified = this.CheckPropertyChanged<int>( "Position", ref _Position, ref value );
			}
		}

		private bool _PositionSpecified = false;
		[XmlIgnore]
		[Browsable( false )]
		public bool PositionSpecified {
			get {
				return _PositionSpecified;
			}
			set {
				_PositionSpecified = value;
			}
		}

		#endregion

		#region Title

		private string _Title;
		[XmlElement( "title" )]
		[Category( "Fenu Button" )]
		[ButtonType( ButtonTypes.NormalButton )]
		public string Title {
			get {
				return _Title;
			}
			set {
				TitleSpecified = this.CheckPropertyChanged<string>( "Title", ref  _Title, ref value );
			}
		}

		private bool _TitleSpecified = false;
		[XmlIgnore]
		[Browsable( false )]
		public bool TitleSpecified {
			get {
				return _TitleSpecified;
			}
			set {
				_TitleSpecified = value;
			}
		}

		#endregion

		#region State

		private ButtonState _State = ButtonState.disable;
		[XmlElement( "state" )]
		[Category( "Fenu Button" )]
		[ButtonType( ButtonTypes.EscapeButton | ButtonTypes.NormalButton | ButtonTypes.NextButton )]
		[DefaultValue( ButtonState.disable )]
		public ButtonState State {
			get {
				return _State;
			}
			set {
				StateSpecified = this.CheckPropertyChanged<ButtonState>( "State", ref _State, ref value );
			}
		}

		private bool _StateSpecified = false;
		[XmlIgnore]
		[Browsable( false )]
		public bool StateSpecified {
			get {
				return _StateSpecified;
			}
			set {
				_StateSpecified = value;
			}
		}

		#endregion

		#region BackColor

		private string _BackColor = "240,240,240";
		[XmlElement( "backcolor" )]
		[Category( "Fenu Button" )]
		[ButtonType( ButtonTypes.EscapeButton | ButtonTypes.NormalButton | ButtonTypes.NextButton )]
		[DefaultValue( "240,240,240" )]
		public string BackColor {
			get {
				return _BackColor;
			}
			set {
				BackColorSpecified = this.CheckPropertyChanged<string>( "BackColor", ref _BackColor, ref value );
			}
		}

		private bool _BackColorSpecified;
		[XmlIgnore]
		[Browsable( false )]
		public bool BackColorSpecified {
			get {
				return _BackColorSpecified;
			}
			set {
				_BackColorSpecified = value;
			}
		}

		#endregion
	}
}
