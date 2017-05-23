using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TeamScreen.Data.Services;
using TeamScreen.Models.Settings;
using TeamScreen.Plugin.Base;

namespace TeamScreen.Services.Plugins
{
    public interface IPluginService
    {
        Task<string[]> GetUsedPluginsUrlsAsync(IUrlHelper urlHelper);
        string[] GetPluginsNames();
        PluginSettingsEndpoint GetPluginSettingsUrls(string pluginName, IUrlHelper urlHelper);
    }

    public class PluginService : IPluginService
    {
        private readonly IEnumerable<IPlugin> _plugins;
        private readonly ISettingsService _settingsService;

        public PluginService(IEnumerable<IPlugin> plugins, ISettingsService settingsService)
        {
            _plugins = plugins;
            _settingsService = settingsService;
        }

        public async Task<string[]> GetUsedPluginsUrlsAsync(IUrlHelper urlHelper)
        {
            var coreSettings = await _settingsService.Get<CoreSettings>(Const.CorePluginName);
            return _plugins
                .Where(x => coreSettings.EnabledPluggins.Contains(x.Name))
                .Select(x => x.GetContentUrl(urlHelper))
                .ToArray();
        }

        public string[] GetPluginsNames()
        {
            return _plugins
                .Select(x => x.Name)
                .ToArray();
        }

        public PluginSettingsEndpoint GetPluginSettingsUrls(string pluginName, IUrlHelper urlHelper)
        {
            var plugin = _plugins
                .FirstOrDefault(x => x.Name == pluginName);

            return new PluginSettingsEndpoint(pluginName, plugin.GetSettingsUrl(urlHelper));
        }
    }
}