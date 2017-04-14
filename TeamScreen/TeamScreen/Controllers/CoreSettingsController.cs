using Microsoft.AspNetCore.Mvc;
using TeamScreen.Models.Settings;
using TeamScreen.Services.Settings;

namespace TeamScreen.Controllers
{
    public class CoreSettingsController : Controller
    {
        private readonly ISettingsService _settingsService;

        public CoreSettingsController(ISettingsService settingsService)
        {
            _settingsService = settingsService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public void Save(CoreSettings settings)
        {
            _settingsService.Set(Const.CorePluginName, settings);
        }
    }
}