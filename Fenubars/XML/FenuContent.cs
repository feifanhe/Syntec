using System;
using System.Collections.Generic;
using System.Text;
using Fenubars.Buttons;
using System.Xml.Serialization;

namespace Fenubars.XML
{
	public class FenuContent
	{
		//// Initiate normal button list
		//public FenuContent( ) {
		//    // TODO: How many buttons on the list varies here
		//    for( int i = 1; i <= 8; i++ )
		//    {
		//        NormalButtonState DummyButton = new NormalButtonState();
		//        _NormalButtonList.Add( DummyButton );
		//    }
		//}

		#region Basic fenu attributes

		private string _Name;
		[XmlAttribute( "name" )]
		public string Name {
			get {
				return _Name;
			}
			set {
				_Name = value;
			}
		}

		#endregion

		#region Contained buttons

		private EscapeButtonState _EscapeButton = new EscapeButtonState();
		[XmlElement( "escape" )]
		public EscapeButtonState EscapeButton {
			get {
				return _EscapeButton;
			}
			set {
				_EscapeButton = value;
			}
		}

		private List<NormalButtonState> _NormalButtonList = new List<NormalButtonState>();
		[XmlElement( "button" )]
		public List<NormalButtonState> NormalButtonList {
			get {
				return _NormalButtonList;
			}
			set {
				_NormalButtonList = value;
			}
		}

		private NextButtonState _NextButton = new NextButtonState();
		[XmlElement( "next" )]
		public NextButtonState NextButton {
			get {
				return _NextButton;
			}
			set {
				_NextButton = value;
			}
		}

		#endregion
	}
}
