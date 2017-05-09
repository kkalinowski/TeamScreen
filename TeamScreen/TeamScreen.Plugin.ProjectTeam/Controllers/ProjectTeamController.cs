using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TeamScreen.Data.Services;
using TeamScreen.Plugin.ProjectTeam.Models;

namespace TeamScreen.Plugin.ProjectTeam.Controllers
{
    public class ProjectTeamController : Controller
    {
        private readonly ISettingsService _settingsService;

        public ProjectTeamController(ISettingsService settingsService)
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
            var settings = await _settingsService.Get<ProjectTeamSettings>(Const.PluginName);
            return Json(settings);
        }

        [HttpPost]
        public async Task SaveSettings([FromBody]ProjectTeamSettings settings)
        {
            await _settingsService.Set(Const.PluginName, settings);
        }
    }
}