using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TeamScreen.Data.Services;
using TeamScreen.Plugin.TeamCity.Integration;
using TeamScreen.Plugin.TeamCity.Mapping;
using TeamScreen.Plugin.TeamCity.Models;

namespace TeamScreen.Plugin.TeamCity.Controllers
{
    public class TeamCityController : Controller
    {
        private readonly ITeamCityService _teamCityService;
        private readonly IBuildMapper _buildMapper;
        private readonly ISettingsService _settingsService;

        public TeamCityController(ITeamCityService teamCityService, IBuildMapper buildMapper, ISettingsService settingsService)
        {
            _teamCityService = teamCityService;
            _buildMapper = buildMapper;
            _settingsService = settingsService;
        }

        public async Task<PartialViewResult> Content()
        {
            var settings = await _settingsService.Get<TeamCitySettings>("TeamCity");
            var builds = await _teamCityService.GetBuilds(settings.Url, settings.Username, settings.Password);

            var models = _buildMapper.Map(builds);
            return PartialView(models);
        }

        public PartialViewResult Settings()
        {
            return PartialView();
        }

        public async Task<JsonResult> GetSettings()
        {
            var settings = await _settingsService.Get<TeamCitySettings>("TeamCity");
            return Json(settings);
        }

        [HttpPost]
        public async Task SaveSettings([FromBody]TeamCitySettings settings)
        {
            await _settingsService.Set("TeamCity", settings);
        }
    }
}