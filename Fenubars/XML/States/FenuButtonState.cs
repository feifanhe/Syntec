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
		[ButtonType( ButtonTypes.Escape | ButtonTypes.Normal | ButtonTypes.Next )]
		public string Name {
			get {
				return _Name;
			}
			set {
				NameSpecified = this.CheckPropertyChanged<string>( "Name", ref _Name, ref value );
			}
		}

		private bool _NameSpecified = false;
		[XmlIgnore]
		public bool NameSpecified {
			get {
				return _NameSpecified;
			}
			set {
				_NameSpecified = value;
			}
		}

		#endregion

		#region Position

		private int _Position;
		[XmlElement( "position" )]
		[ButtonType( ButtonTypes.Normal )]
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
		[ButtonType( ButtonTypes.Escape | ButtonTypes.Normal | ButtonTypes.Next )]
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
		public bool TitleSpecified {
			get {
				return _TitleSpecified;
			}
			set {
				_TitleSpecified = value;
			}
		}

		#endregion
	}
}
