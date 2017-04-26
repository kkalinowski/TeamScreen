using Microsoft.AspNetCore.Mvc;
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
    }
}