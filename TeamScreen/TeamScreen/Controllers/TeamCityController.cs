using Microsoft.AspNetCore.Mvc;
using TeamScreen.TeamCity;
using System.Threading.Tasks;

namespace TeamScreen.Controllers
{
    public class TeamCityController : Controller
    {
        private readonly ITeamCityService _teamCityService;

        public TeamCityController(ITeamCityService teamCityService)
        {
            _teamCityService = teamCityService;
        }

        public async Task<IActionResult> Index()
        {
            var builds = await _teamCityService.GetBuilds("");
            return View(builds);
        }
    }
}