using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TeamScreen.Data.Services;
using TeamScreen.Models.Settings;
using Microsoft.AspNetCore.Identity;
using TeamScreen.Data.Entities;
using TeamScreen.Models.Container;

namespace TeamScreen.Controllers
{
    public class ContainerController : Controller
    {
        private readonly ISettingsService _settingsService;
        private readonly UserManager<ApplicationUser> _userManager;

        public ContainerController(ISettingsService settingsService, UserManager<ApplicationUser> userManager)
        {
            _settingsService = settingsService;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var settings = await _settingsService.Get<CoreSettings>(Const.CorePluginName);
            var user = await _userManager.GetUserAsync(HttpContext.User);
            return View(new ContainerModel { Settings = settings, User = user });
        }
    }
}