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
	public class PasswordActions
	{
		private int _Password;
		public int Password
		{
			get
			{
				return _Password;
			}
			set
			{
				_Password = value;
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

		private ActionCollection _Correct;
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

		private ActionCollection _Incorrect;
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
	}

	[TypeConverter( typeof( ExpandableObjectConverter ) )]
	public class ActionCollection
	{
		private string _Action;
		[XmlElement( "action" )]
		public string Action
		{
			get
			{
				return _Action;
			}
			set
			{
				_Action = value;
			}
		}

		private List<string> _Actions = new List<string>();
		[XmlElement( "actions" )]
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

		public override string ToString()
		{
			return string.Empty;
		}
	}
}
