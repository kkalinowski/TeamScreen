namespace TeamScreen.Services.Plugins
{
    public interface IPluginService
    {
        string[] GetPluginSettingsUrls();
        string[] GetUsedPluginsUrls();
    }

    public class PluginService : IPluginService
    {
        public string[] GetUsedPluginsUrls()
        {
            return new string[0];
        }

        public string[] GetPluginSettingsUrls()
        {
            return new string[0];
        }
    }
}