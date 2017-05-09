using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TeamScreen.Data.Services;
using TeamScreen.Plugin.HealthCheck.Integration;
using TeamScreen.Plugin.HealthCheck.Models;

namespace TeamScreen.Plugin.HealthCheck.Controllers
{
    public class HealthCheckController : Controller
    {
        private readonly ISettingsService _settingsService;
        private readonly IWardenService _wardenService;

        public HealthCheckController(ISettingsService settingsService, IWardenService wardenService)
        {
            _settingsService = settingsService;
            _wardenService = wardenService;
        }

        public async Task<PartialViewResult> Content()
        {
            var settings = await _settingsService.Get<HealthCheckSettings>(Const.PluginName);
            var results = await _wardenService.DoHealthChecks(settings.Settings);
            return PartialView(results);
        }

        public PartialViewResult Settings()
        {
            return PartialView();
        }

        public async Task<JsonResult> GetSettings()
        {
            var settings = await _settingsService.Get<HealthCheckSettings>(Const.PluginName);
            return Json(settings);
        }

        [HttpPost]
        public async Task SaveSettings([FromBody]HealthCheckSettings settings)
        {
            await _settingsService.Set(Const.PluginName, settings);
        }
    }
}