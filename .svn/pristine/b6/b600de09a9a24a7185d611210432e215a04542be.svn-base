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
		

		#region incor

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

		[XmlIgnore]
		[Browsable( false )]
		public bool CorrectSpecified
		{
			get
			{
				if( _Correct.Count == 0 ) {
					return false;
				}
				else {
					return true;
				}
			}
		}

		#endregion

		#region incor

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

		[XmlIgnore]
		[Browsable( false )]
		public bool IncorrectSpecified
		{
			get
			{
				if( _Incorrect.Count == 0 ) {
					return false;
				}
				else {
					return true;
				}
			}
		}

		#endregion

		public override string ToString()
		{
			return string.Empty;
		}
	}

	[TypeConverter( typeof( ExpandableObjectConverter ) )]
	public class ActionCollection : Fenubars.Events.NotifyProperyChangedBase
	{
		// Remember to sync with FenuButtonState:Action

		#region Action

		// Remember to sync with MiscOptions:ActionCollection

		private List<string> _Actions = new List<string>();
		[XmlArray( "actions" )]
		[XmlArrayItem( "action", typeof( string ) )]
		[ButtonType( ButtonTypes.EscapeButton | ButtonTypes.NormalButton | ButtonTypes.NextButton )]
		//public ActionCollection Actions
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

		#endregion

		[XmlIgnore]
		[Browsable( false )]
		public int Count
		{
			get
			{
				return _Actions.Count;
			}
		}

		public override string ToString()
		{
			return string.Empty;
		}
	}
}
