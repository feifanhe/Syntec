using System.Collections.Generic;
using System.Xml.Serialization;

namespace Fenubars.XML
{
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
		[XmlElement( "actions" )]
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
