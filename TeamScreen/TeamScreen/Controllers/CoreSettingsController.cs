using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TeamScreen.Data.Services;
using TeamScreen.Models.Settings;
using TeamScreen.Services.Plugins;

namespace TeamScreen.Controllers
{
    public class CoreSettingsController : Controller
    {
        private readonly ISettingsService _settingsService;
        private readonly IPluginService _pluginService;

        public CoreSettingsController(ISettingsService settingsService, IPluginService pluginService)
        {
            _settingsService = settingsService;
            _pluginService = pluginService;
        }

        public PartialViewResult Settings()
        {
            return PartialView();
        }

        public async Task<JsonResult> Get()
        {
            var coreSettings = await _settingsService.Get<CoreSettings>(Const.CorePluginName);
            var plugins = _pluginService.GetPluginsNames();

            var model = new CoreSettingsModel(coreSettings, plugins);
            return Json(model);
        }

        [HttpPost]
        public async Task Save([FromBody]CoreSettingsModel settingsModel)
        {
            await _settingsService.Set(Const.CorePluginName, settingsModel.ToCoreSettings());
        }
    }
}