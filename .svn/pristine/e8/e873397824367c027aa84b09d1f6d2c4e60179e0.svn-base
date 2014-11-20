using System.Windows.Forms;
using System.Drawing;

namespace Fenubars.XML
{

	public static class StateConverter
	{
		public static void BoolToState( object sender, ConvertEventArgs cevent )
		{
			if( cevent.DesiredType != typeof( ButtonState ) )
				return;
			cevent.Value = ( (bool)cevent.Value ) ? ButtonState.enable : ButtonState.disable;
		}

		public static void StateToBool( object sender, ConvertEventArgs cevent )
		{
			cevent.Value = ( (ButtonState)cevent.Value == ButtonState.enable );
		}
	}

	public static class ColorConverter
	{
		public static void StringToColor( object sender, ConvertEventArgs cevent )
		{
			cevent.Value = StringToColor( (string)cevent.Value );
		}

		public static Color StringToColor( string rgb )
		{
			string[] RGB = rgb.Split( ',' );
			if( RGB.Length != 3 ) {
				return Color.FromArgb( 0, 0, 0 );
			}
			return Color.FromArgb( int.Parse( RGB[ 0 ] ),
									int.Parse( RGB[ 1 ] ),
									int.Parse( RGB[ 2 ] ) );
		}

		public static void ColorToString( object sender, ConvertEventArgs cevent )
		{
			cevent.Value = ColorToString( (Color)cevent.Value );
		}

		public static string ColorToString( Color color )
		{
			return string.Concat( 
				color.R.ToString(), ",", 
				color.G.ToString(), ",", 
				color.B.ToString() );
		}
	}
}
