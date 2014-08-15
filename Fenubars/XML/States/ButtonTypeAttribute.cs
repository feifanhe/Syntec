using System;

namespace Fenubars.XML
{
	[Flags]
	public enum ButtonTypes
	{
		Escape = 0x01,
		Normal = 0x02,
		Next = 0x04
	};

	public class ButtonTypeAttribute : Attribute
	{
		private ButtonTypes _Type;
		public ButtonTypes Type {
			get {
				return _Type;
			}
			private set {
				_Type = value;
			}
		}
		public ButtonTypeAttribute(ButtonTypes Type) {
			this.Type = Type;
		}
	}
}
