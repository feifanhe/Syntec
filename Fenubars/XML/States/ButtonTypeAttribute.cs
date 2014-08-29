using System;

namespace Fenubars.XML
{
	[Flags]
	public enum ButtonTypes
	{
		EscapeButton = 0x01,
		NormalButton = 0x02,
		NextButton = 0x04
	};

	public class ButtonTypeAttribute : Attribute
	{
		private ButtonTypes _Type;
		public ButtonTypes Type
		{
			get
			{
				return _Type;
			}
			private set
			{
				_Type = value;
			}
		}
		public ButtonTypeAttribute( ButtonTypes Type )
		{
			this.Type = Type;
		}
	}
}
