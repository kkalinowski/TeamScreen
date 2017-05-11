using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TeamScreen.Data.Services;
using TeamScreen.Models.Settings;
using TeamScreen.Services.Plugins;

namespace TeamScreen.Controllers
{
    [Authorize]
    public class SettingsController : Controller
    {
        private readonly IPluginService _pluginService;

        public SettingsController(IPluginService pluginService)
        {
            _pluginService = pluginService;
        }

        public IActionResult Index()
        {
            var pluginsNames = new List<string> { Const.CorePluginName };
            pluginsNames.AddRange(_pluginService.GetPluginsNames());

            return View(pluginsNames);
        }

        public IActionResult SinglePluginSettings(string plugin)
        {
            if (plugin == Const.CorePluginName)
                return View(new PluginSettingsEndpoint(Const.CorePluginName, Url.Action("Settings", "CoreSettings")));

            return View(_pluginService.GetPluginSettingsUrls(plugin, Url));
        }
    }
}