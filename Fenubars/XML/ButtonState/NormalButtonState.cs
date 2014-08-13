using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.ComponentModel;
using System.Drawing;

namespace Fenubars.XML
{
	public class NormalButtonState : INotifyPropertyChanged
	{
		#region XML readout storage

		private int _Position;
		[XmlElement( "position" )]
		public int Position {
			get {
				return _Position;
			}
			set {
				_Position = value;
				InvokePropertyChanged( "Position" );
			}
		}

		private string _Title = "TITLE FROM NBS";
		[XmlElement( "title" )]
		public string Title {
			get {
				return _Title;
			}
			set {
				_Title = value;
				InvokePropertyChanged( "Title" );
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
			}
		}

		private string _Picture;
		[XmlElement("picture")]
		public string Picture {
			get {
				return _Picture;
			}
			set {
				_Picture = value;
			}
		}

		private int _UserLevel;
		[XmlElement("userlevel")]
		public int UserLevel {
			get {
				return _UserLevel;
			}
			set {
				_UserLevel = value;
			}
		}

		private string _ForeColor;
		[XmlElement("forecolor")]
		public string ForeColor {
			get {
				return _ForeColor;
			}
			set {
				_ForeColor = value;
			}
		}

		#region BackColor

		private string _BackColor = "240,240,240";
		[XmlElement("backcolor")]
		[DefaultValue("240,240,240")]
		public string BackColor {
			get {
				return _BackColor;
			}
			set {
				_BackColor = value;
			}
		}

		[XmlIgnore]
		public Color ParseBackColor {
			get {
				string[] RGB = _BackColor.Split( ',' );
				return Color.FromArgb( int.Parse(RGB[ 0 ]), 
										int.Parse(RGB[ 1 ]), 
										int.Parse(RGB[ 2 ]) );
			}
			set {
				Color color = value;
				_BackColor = value.R.ToString() + ",";
				_BackColor += value.G.ToString() + ",";
				_BackColor += value.B.ToString();
			}
		}
		#endregion

		#region State

		private ButtonState _State = ButtonState.disable;
		[XmlElement("state")]
		[DefaultValue(ButtonState.disable)]
		public ButtonState State {
			get {
				return _State;
			}
			set {
				_State = value;
			}
		}

		[XmlIgnore]
		public bool ParseState {
			get {
				return ( _State == ButtonState.enable );
			}
			set {
				_State = ( value ) ? ButtonState.enable : ButtonState.disable;
			}
		}

		#endregion

		#region Visible

		private bool _Visible;
		[XmlElement("visible")]
		[DefaultValue(false)]
		public bool Visible {
			get {
				return _Visible;
			}
			set {
				_Visible = value;
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

		private bool _HoldMode;
		public bool HoldMode {
			get {
				return _HoldMode;
			}
			set {
				_HoldMode = value;
			}
		}

		private string _LightOnColor;
		public string LightOnColor {
			get {
				return _LightOnColor;
			}
			set {
				_LightOnColor = value;
			}
		}

		private int _Alignment;
		public int Alignment {
			get {
				return _Alignment;
			}
			set {
				_Alignment = value;
			}
		}

		private PasswordActions _PasswordActions;
		[XmlElement("pwd")]
		public PasswordActions PasswordActions {
			get {
				return _PasswordActions;
			}
			set {
				_PasswordActions = value;
			}
		}

		private string _InvisibleDevice;
		public string InvisibleDevice {
			get {
				return _InvisibleDevice;
			}
			set {
				_InvisibleDevice = value;
			}
		}

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

		#region INotifyPropertyChanged Members

		public event PropertyChangedEventHandler PropertyChanged;
		public void InvokePropertyChanged(string PropertyName) {
			PropertyChangedEventHandler handler = PropertyChanged;
			if( handler != null )
				handler( this, new PropertyChangedEventArgs( PropertyName ) );
		}

		#endregion
	}

	public enum ButtonState
	{
		enable,
		disable
	};

	public class PasswordActions
	{
		private int _Password;
		public int Password {
			get {
				return _Password;
			}
			set {
				_Password = value;
			}
		}

		private ActionCollection _Correct;
		public ActionCollection Correct {
			get {
				return _Correct;
			}
			set {
				_Correct = value;
			}
		}

		private ActionCollection _Incorrect;
		public ActionCollection Incorrect {
			get {
				return _Incorrect;
			}
			set {
				_Incorrect = value;
			}
		}
	}

	public class ActionCollection
	{
		private string _Action;
		public string Action {
			get {
				return _Action;
			}
			set {
				_Action = value;
			}
		}

		private List<string> _Actions = new List<string>();
		[XmlElement("actions")]
		public List<string> Actions {
			get {
				return _Actions;
			}
			set {
				_Actions = value;
			}
		}
	}
}
