using System;
using System.Collections.Generic;
using System.Text;
using Fenubars.Buttons;

namespace Fenubars.XML
{
	public class FenuContent
	{
		#region Basic fenu attributes

		private string _Name;
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

		private NormalButtonState _NB = new NormalButtonState();
		public NormalButtonState NB {
			get {
				return _NB;
			}
			set {
				_NB = value;
			}
		}

		#endregion
	}
}
