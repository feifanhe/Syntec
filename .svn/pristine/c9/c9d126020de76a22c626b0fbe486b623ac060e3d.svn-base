using System.Collections.Generic;
using System.Xml.Serialization;
using System.ComponentModel;

namespace Fenubars.XML
{
	public enum ButtonState
	{
		enable,
		disable
	};

	[TypeConverter( typeof( ExpandableObjectConverter ) )]
	public class PasswordActions : Fenubars.Events.NotifyProperyChangedBase
	{
		[XmlElement( "value" )]
		private string _Password;
		public string Password
		{
			get
			{
				return _Password;
			}
			set
			{
				PasswordSpecified = this.CheckPropertyChanged<string>( "Password", ref _Password, ref value );
			}
		}

		private bool _PasswordSpecified = false;
		[XmlIgnore]
		[Browsable( false )]
		public bool PasswordSpecified
		{
			get
			{
				return _PasswordSpecified;
			}
			set
			{
				_PasswordSpecified = value;
			}
		}

		[XmlElement( "cor" )]
		private ActionCollection _Correct = new ActionCollection();
		public ActionCollection Correct
		{
			get
			{
				return _Correct;
			}
			set
			{
				_Correct = value;
			}
		}

		[XmlElement( "incor" )]
		private ActionCollection _Incorrect = new ActionCollection();
		public ActionCollection Incorrect
		{
			get
			{
				return _Incorrect;
			}
			set
			{
				_Incorrect = value;
			}
		}

		public override string ToString()
		{
			return string.Empty;
		}
	}

	[TypeConverter( typeof( ExpandableObjectConverter ) )]
	public class ActionCollection : Fenubars.Events.NotifyProperyChangedBase
	{
		// Remember to sync with FenuButtonState:Action

		private List<string> _Actions = new List<string>();
		[XmlArray( "actions" )]
		[XmlArrayItem( "action", typeof( string ) )]
		[Category( "Fenu Button" )]
		[ButtonType( ButtonTypes.EscapeButton | ButtonTypes.NormalButton | ButtonTypes.NextButton )]
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
				if( _Actions.Count < 1 ) {
					return false;
				}
				return true;
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
				return false;
			}
		}

		public override string ToString()
		{
			return string.Empty;
		}
	}
}
