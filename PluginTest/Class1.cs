using System;
using System.Collections.Generic;
using System.Text;

using PluginInterface;
using System.Windows.Forms;

namespace PluginTest
{
	public class Plugin : IPlugin
	{
		#region IPlugin Members

		IPluginHost myHost = null;
		public IPluginHost Host {
			get {
				return myHost;
			}
			set {
				myHost = value;
			}
		}

		public string Name {
			get {
				return "PLUGIN TEST";
			}
		}

		public string Description {
			get {
				return "USE FOR TESTING ONLY";
			}
		}

		public string Version {
			get {
				return "1.0.0";
			}
		}

		UserControl frm = new UserControl1();
		public UserControl MainInterface {
			get {
				return frm;
			}
		}

		public bool Initialize(string XMLPath) {
			return true; // false to fail the initialization progress
		}

		public void Load(string Name) {
		}

		public void Dispose( ) {
		}

		public void Save( ) {
		}

		public void SaveAs(string XMLPath) {
		}

		public void Cut( ) {
		}

		public void Copy( ) {
		}

		public void Paste( ) {
		}

		public void Delete( ) {
		}

		#endregion
	}
}
