using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TeamScreen.Data.Services;
using TeamScreen.Models.Settings;
using TeamScreen.Services.Plugins;

namespace TeamScreen.Controllers
{
    public class SettingsController : Controller
    {
        private readonly ISettingsService _settingsService;
        private readonly IPluginService _pluginService;

        public SettingsController(ISettingsService settingsService, IPluginService pluginService)
        {
            _settingsService = settingsService;
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
                return View(new PluginSettingsEndpoint(Const.CorePluginName, Url.Action("CoreSettings")));

            return View(_pluginService.GetPluginSettingsUrls(plugin, Url));
        }

        public PartialViewResult CoreSettings()
        {
            return PartialView();
        }

        public async Task<JsonResult> GetCoreSettings()
        {
            var coreSettings = await _settingsService.Get<CoreSettings>(Const.CorePluginName);
            return Json(coreSettings);
        }

        [HttpPost]
        public async Task SaveCoreSettings([FromBody]CoreSettings settings)
        {
            await _settingsService.Set(Const.CorePluginName, settings);
        }
    }
}