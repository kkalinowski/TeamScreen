using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TeamScreen.Data.Entities;
using TeamScreen.Data.Services;
using TeamScreen.Plugin.ProjectTeam.Models;

namespace TeamScreen.Plugin.ProjectTeam.Controllers
{
    public class ProjectTeamController : Controller
    {
        private readonly ISettingsService _settingsService;
        private readonly UserManager<ApplicationUser> _userManager;

        public ProjectTeamController(ISettingsService settingsService, UserManager<ApplicationUser> userManager)
        {
            _settingsService = settingsService;
            _userManager = userManager;
        }

        public async Task<PartialViewResult> Content()
        {
            var settings = await _settingsService.Get<ProjectTeamSettings>(Const.PluginName);
            var users = await _userManager.Users.ToArrayAsync();

            var model = new ProjectTeamContentModel
            {
                ProjectName = settings.Name,
                Description = settings.Description,
                UsedTechnologies = settings.Techs.Split(',').Select(x => x.Trim()).ToArray(),
                People = users
            };
            return PartialView(model);
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