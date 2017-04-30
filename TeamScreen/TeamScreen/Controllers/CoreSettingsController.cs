using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TeamScreen.Data.Services;
using TeamScreen.Models.Settings;

namespace TeamScreen.Controllers
{
    public class CoreSettingsController : Controller
    {
        private readonly ISettingsService _settingsService;

        public CoreSettingsController(ISettingsService settingsService)
        {
            _settingsService = settingsService;
        }

        public PartialViewResult Settings()
        {
            return PartialView();
        }

        public async Task<JsonResult> Get()
        {
            var coreSettings = await _settingsService.Get<CoreSettings>(Const.CorePluginName);
            return Json(coreSettings);
        }

        [HttpPost]
        public async Task Save([FromBody]CoreSettings settings)
        {
            await _settingsService.Set(Const.CorePluginName, settings);
        }
    }
}