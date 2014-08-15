using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.ComponentModel;
using System.Drawing;

namespace Fenubars.XML
{
	public class FenuButtonState : Fenubars.Events.NotifyProperyChangedBase
	{
		#region Name

		private string _Name;
		[XmlAttribute( "name" )]
		public string Name {
			get {
				return _Name;
			}
			set {
				this.CheckPropertyChanged<string>( "Name", ref _Name, ref value );
			}
		}

		#endregion

		private int _Position;
		[XmlElement( "position" )]
		public int Position {
			get {
				return _Position;
			}
			set {
				this.CheckPropertyChanged<int>( "Position", ref _Position, ref value );
			}
		}

		#region Title

		private string _Title;
		[XmlElement( "title" )]
		public string Title {
			get {
				return _Title;
			}
			set {
				this.CheckPropertyChanged<string>( "Title",ref  _Title, ref value );
			}
		}

		private bool _TitleSpecified = false;
		[XmlIgnore]
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

		//private ButtonState _State = ButtonState.disable;
		//[XmlElement( "state" )]
		//[DefaultValue( ButtonState.disable )]
		//public ButtonState State {
		//    get {
		//        return _State;
		//    }
		//    set {
		//        _State = value;
		//        InvokePropertyChanged( "State" );
		//    }
		//}

		//[XmlIgnore]
		//public bool ParseState {
		//    get {
		//        return ( _State == ButtonState.enable );
		//    }
		//    set {
		//        _State = ( value ) ? ButtonState.enable : ButtonState.disable;
		//        InvokePropertyChanged( "State" );
		//    }
		//}

		#endregion
	}
}
