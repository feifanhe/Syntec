using System;
using System.Collections.Generic;
using System.Text;
using Fenubars.Buttons;
using System.Xml.Serialization;

namespace Fenubars.XML
{
	public class FenuState
	{
		#region Basic fenu attributes

		private string _Name;
		[XmlAttribute( "name" )]
		public string Name
		{
			get
			{
				return _Name;
			}
			set
			{
				_Name = value;
			}
		}

		#endregion

		#region Contained buttons

		private FenuButtonState _EscapeButton;
		[XmlElement( "escape", IsNullable = false )]
		public FenuButtonState EscapeButton
		{
			get
			{
				return _EscapeButton;
			}
			set
			{
				_EscapeButton = value;
			}
		}

		private List<FenuButtonState> _NormalButtonList = new List<FenuButtonState>();
		[XmlElement( "button", IsNullable = false )]
		public List<FenuButtonState> NormalButtonList
		{
			get
			{
				return _NormalButtonList;
			}
			set
			{
				_NormalButtonList = value;
			}
		}

		private FenuButtonState _NextButton;
		[XmlElement( "next", IsNullable = false )]
		public FenuButtonState NextButton
		{
			get
			{
				return _NextButton;
			}
			set
			{
				_NextButton = value;
			}
		}

		#endregion
	}
}
