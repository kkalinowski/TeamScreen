using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TeamScreen.Models.Settings;
using TeamScreen.Plugin.Base;

namespace TeamScreen.Services.Plugins
{
    public interface IPluginService
    {
        string[] GetUsedPluginsUrls(IUrlHelper urlHelper);
        string[] GetPluginsNames();
        PluginSettingsEndpoint[] GetPluginSettingsUrls(IUrlHelper urlHelper);
    }

    public class PluginService : IPluginService
    {
        private readonly IEnumerable<IPlugin> _plugins;

        public PluginService(IEnumerable<IPlugin> plugins)
        {
            this._plugins = plugins;
        }

        public string[] GetUsedPluginsUrls(IUrlHelper urlHelper)
        {
            return _plugins
                .Select(x => x.GetContentUrl(urlHelper))
                .ToArray();
        }

        public string[] GetPluginsNames()
        {
            return _plugins
                .Select(x => x.Name)
                .ToArray();
        }

        public PluginSettingsEndpoint[] GetPluginSettingsUrls(IUrlHelper urlHelper)
        {
            return _plugins
                .Select(x => new PluginSettingsEndpoint(x.Name, x.GetSettingsUrl(urlHelper)))
                .ToArray();
        }
    }
}