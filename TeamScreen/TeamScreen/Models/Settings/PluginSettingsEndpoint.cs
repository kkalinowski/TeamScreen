namespace TeamScreen.Models.Settings
{
    public class PluginSettingsEndpoint
    {
        public string PluginName { get; set; }
        public string SettingsUrl { get; set; }

        public PluginSettingsEndpoint(string pluginName, string settingsUrl)
        {
            PluginName = pluginName;
            SettingsUrl = settingsUrl;
        }
    }
}