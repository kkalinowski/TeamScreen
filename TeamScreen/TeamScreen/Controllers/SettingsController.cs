using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TeamScreen.Models.Settings;
using TeamScreen.Services.Settings;

namespace TeamScreen.Controllers
{
    public class SettingsController : Controller
    {
        private readonly ISettingsService _settingsService;

        public SettingsController(ISettingsService settingsService)
        {
            _settingsService = settingsService;
        }

        public IActionResult Index()
        {
            return View();
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
        public void SaveCoreSettings(CoreSettings settings)
        {
            _settingsService.Set(Const.CorePluginName, settings);
        }
    }
}