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

        public async Task<PartialViewResult> CoreSettings()
        {
            var coreSettings = await _settingsService.Get<CoreSettings>(Const.CorePluginName);
            return PartialView(coreSettings);
        }
    }
}