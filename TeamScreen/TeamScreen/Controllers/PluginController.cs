using System.Threading.Tasks;
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

        public async Task<IActionResult> GetUsedPluginsUrls()
        {
            var pluginsUrls = await _pluginService.GetUsedPluginsUrlsAsync(Url);
            return Json(pluginsUrls);
        }
    }
}