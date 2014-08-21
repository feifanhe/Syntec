using System.Windows.Forms;

namespace Fenubars.XML
{
	public static class StateConverter
	{
		public static void BoolToState(object sender, ConvertEventArgs cevent) {
			if( cevent.DesiredType != typeof( ButtonState ) )
				return;
			cevent.Value = ( (bool)cevent.Value ) ? ButtonState.enable : ButtonState.disable;
		}

		public static void StateToBool(object sender, ConvertEventArgs cevent) {
			cevent.Value = ((ButtonState)cevent.Value == ButtonState.enable );
		}
	}
}
