using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TeamScreen.Plugin.Base;

namespace TeamScreen.Services.Plugins
{
    public interface IPluginService
    {
        string[] GetPluginSettingsUrls(IUrlHelper urlHelper);
        string[] GetUsedPluginsUrls(IUrlHelper urlHelper);
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

        public string[] GetPluginSettingsUrls(IUrlHelper urlHelper)
        {
            return new string[0];
        }
    }
}