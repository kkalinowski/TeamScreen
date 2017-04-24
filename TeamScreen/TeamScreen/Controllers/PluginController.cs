using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TeamScreen.Models.Settings;
using TeamScreen.Services.Plugins;

namespace TeamScreen.Controllers
{
    public class PluginController : Controller
    {
        private readonly IPluginService _pluginService;

        public PluginController(IPluginService pluginService)
        {
            _pluginService = pluginService;
        }

        public IActionResult GetUsedPluginsUrls()
        {
            return Json(_pluginService.GetUsedPluginsUrls(Url));
        }

        public IActionResult GetPluginsEndpoints()
        {
            var coreSettingsEndpoint = new PluginSettingsEndpoint(Const.CorePluginName, Url.Action("CoreSettings","Settings"));
            var pluginSettingsUrls = _pluginService.GetPluginSettingsUrls(Url);

            var result = new List<PluginSettingsEndpoint>{coreSettingsEndpoint};
            result.AddRange(pluginSettingsUrls);
            return Json(result);
        }
    }
}