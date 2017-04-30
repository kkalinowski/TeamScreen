using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TeamScreen.Data.Services;
using TeamScreen.Plugin.HealthCheck.Models;

namespace TeamScreen.Plugin.HealthCheck.Controllers
{
    public class HealthCheckController : Controller
    {
        private readonly ISettingsService _settingsService;

        public HealthCheckController(ISettingsService settingsService)
        {
            _settingsService = settingsService;
        }

        public async Task<PartialViewResult> Content()
        {
            return PartialView();
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