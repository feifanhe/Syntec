using System.ComponentModel;
using System.Xml.Serialization;

using Fenubars;

namespace Fenubars.XML
{
	public class NextButtonState : Fenubars.Events.NotifyProperyChangedBase
	{
		#region XML readout storage

		#region Name

		private string _Name;
		[XmlAttribute( "name" )]
		public string Name {
			get {
				return _Name;
			}
			set {
				_Name = value;
				this.FirePropertyChanged( "Name" );
				//InvokePropertyChanged( "Name" );
			}
		}

		#endregion

		private string _Title = ">>";
		//[ReadOnly(true)]
		[XmlIgnore]
		public string Title {
			get {
				return _Title;
			}
			set {
				if( this.CheckPropertyChanged<string>( "Title", ref _Title, ref value ) )
				{
					this.FirePropertyChanged( "Title" );
				}
				//_Title = value;
				//InvokePropertyChanged( "Title" );
			}
		}

		private ActionCollection _ActionCollection;
		[XmlElement]
		public ActionCollection ActionCollection {
			get {
				return _ActionCollection;
			}
			set {
				_ActionCollection = value;
			}
		}

		private string _Link;
		public string Link {
			get {
				return _Link;
			}
			set {
				_Link = value;
				//InvokePropertyChanged( "Link" );
			}
		}

		private int _UserLevel;
		[XmlElement( "userlevel" )]
		public int UserLevel {
			get {
				return _UserLevel;
			}
			set {
				_UserLevel = value;
			}
		}

		#region State

		private ButtonState _State = ButtonState.disable;
		[XmlElement( "state" )]
		[DefaultValue( ButtonState.disable )]
		public ButtonState State {
			get {
				return _State;
			}
			set {
				_State = value;
				//InvokePropertyChanged( "State" );
			}
		}

		[XmlIgnore]
		public bool ParseState {
			get {
				return ( _State == ButtonState.enable );
			}
			set {
				_State = ( value ) ? ButtonState.enable : ButtonState.disable;
				//InvokePropertyChanged( "State" );
			}
		}

		#endregion

		#region Visible

		private bool _Visible;
		[XmlElement( "visible" )]
		[DefaultValue( false )]
		public bool Visible {
			get {
				return _Visible;
			}
			set {
				_Visible = value;
				if( _Visible )
					State = ButtonState.enable;
				//InvokePropertyChanged( "Visible" );
			}
		}

		//private bool _VisibleSpecified = false;
		//[XmlIgnore]
		//public bool VisibleSpecified {
		//    get {
		//        return _VisibleSpecified;
		//    }
		//    set {
		//        _VisibleSpecified = value;
		//    }
		//}

		#endregion

		private string _VisibleRule;
		public string VisibleRule {
			get {
				return _VisibleRule;
			}
			set {
				_VisibleRule = value;
			}
		}

		private string _EnableRule;
		public string EnableRule {
			get {
				return _EnableRule;
			}
			set {
				_EnableRule = value;
			}
		}

		#endregion

		//#region INotifyPropertyChanged Members

		//public event PropertyChangedEventHandler PropertyChanged;
		//public void InvokePropertyChanged(string PropertyName) {
		//    PropertyChangedEventHandler handler = PropertyChanged;
		//    if( handler != null )
		//        handler( this, new PropertyChangedEventArgs( PropertyName ) );
		//    State = ButtonState.enable;
		//}

		//#endregion
	}
}
