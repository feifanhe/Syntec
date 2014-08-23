using System.Windows.Forms;
using System.Drawing;

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

	public static class ColorConverter
	{
		public static void StringToColor(object sender, ConvertEventArgs cevent) {
			string[] RGB = ((string)cevent.Value).Split( ',' );
			cevent.Value = Color.FromArgb( int.Parse( RGB[ 0 ] ),
											int.Parse( RGB[ 1 ] ),
											int.Parse( RGB[ 2 ] ) );
		}

		public static void ColorToString(object sender, ConvertEventArgs cevent) {
			string ColorString = string.Empty;
			ColorString = ((Color)cevent.Value).R.ToString() + ",";
			ColorString += ((Color)cevent.Value).G.ToString() + ",";
			ColorString += ((Color)cevent.Value).B.ToString();
			cevent.Value = ColorString;
		}
	}
}
