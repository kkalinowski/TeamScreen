using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TeamScreen.Data.Services;
using TeamScreen.Models.Settings;

namespace TeamScreen.Controllers
{
    public class ContainerController : Controller
    {
        private readonly ISettingsService _settingsService;

        public ContainerController(ISettingsService settingsService)
        {
            _settingsService = settingsService;
        }

        public async Task<IActionResult> Index()
        {
            var settings = await _settingsService.Get<CoreSettings>(Const.CorePluginName);
            return View(settings);
        }
    }
}