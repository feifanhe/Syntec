namespace Syntec
{
	// A static instance for global stuff
	public class Global
	{
		public Global( ) {
		}

		#region Plugin Manager

		// Plugin services 
		public static Syntec.Plugin.PluginServices Plugins = new Syntec.Plugin.PluginServices();

		public static readonly string PluginsFolderPath = @"\Plugins";

		#endregion
	}
}
