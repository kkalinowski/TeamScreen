using Microsoft.AspNetCore.Mvc;
using TeamScreen.TeamCity;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace TeamScreen.Controllers
{
    public class TeamCityController : Controller
    {
        private readonly ITeamCityService _teamCityService;
        private readonly IConfigurationRoot _configurationRoot;

        public TeamCityController(ITeamCityService teamCityService, IConfigurationRoot configurationRoot)
        {
            _teamCityService = teamCityService;
            _configurationRoot = configurationRoot;
        }

        public async Task<IActionResult> Index()
        {
            var url = _configurationRoot["TeamCityUrl"];
            var username = _configurationRoot["TeamCityUsername"];
            var password = _configurationRoot["TeamCityPassword"];
            var builds = await _teamCityService.GetBuilds(url, username, password);
            return View(builds);
        }
    }
}