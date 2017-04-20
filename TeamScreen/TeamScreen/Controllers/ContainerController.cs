using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TeamScreen.Models.Settings;
using TeamScreen.Services.Plugins;
using TeamScreen.Services.Settings;

namespace TeamScreen.Controllers
{
    public class ContainerController : Controller
    {
        private readonly ISettingsService _settingsService;
        private readonly IPluginService _pluginService;

        public ContainerController(ISettingsService settingsService, IPluginService pluginService)
        {
            _settingsService = settingsService;
            _pluginService = pluginService;
        }

        public async Task<IActionResult> Index()
        {
            var settings = await _settingsService.Get<CoreSettings>(Const.CorePluginName);
            return View(settings);
        }
    }
}