using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TeamScreen.Data.Services;
using TeamScreen.Plugin.Git.Models;

namespace TeamScreen.Plugin.Git.Controllers
{
    public class GitController : Controller
    {
        private readonly ISettingsService _settingsService;

        public GitController(ISettingsService settingsService)
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
            var settings = await _settingsService.Get<GitSettings>(Const.PluginName);
            return Json(settings);
        }

        [HttpPost]
        public async Task SaveSettings([FromBody]GitSettings settings)
        {
            await _settingsService.Set(Const.PluginName, settings);
        }
    }
}