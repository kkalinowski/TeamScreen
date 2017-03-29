using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TeamScreen.TeamCity;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using TeamScreen.Models.TeamCity;

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
            return View(MapToModels(builds));
        }

        public Dictionary<string, TeamCityBuildModel[]> MapToModels(IEnumerable<BuildJob> buildJobs)
        {
            return buildJobs
                .GroupBy(x => x.Project.Name)
                .ToDictionary(x => x.Key, y => y.Select(MapSingleBuild).ToArray());
        }

        public TeamCityBuildModel MapSingleBuild(BuildJob buildJob)
        {
            var lastBuild = buildJob.BuildCollection.Builds.First();
            return new TeamCityBuildModel
            {
                Name = buildJob.Name,
                Date = lastBuild.FinishDate ?? lastBuild.StartDate,
                Status = MapStatus(lastBuild),
                TrrggeredBy = MapTriggeredBy(lastBuild.Trigger)
            };
        }

        public TeamCityStatusModel MapStatus(Build build)
        {
            if(build.State != BuildState.Finished)
                return TeamCityStatusModel.Pending;
            else if (build.Status != BuildStatus.Success)
                return TeamCityStatusModel.Failure;
            else
                return TeamCityStatusModel.Success;
        }

        public string MapTriggeredBy(BuildTrigger trigger)
        {
            if (trigger.Type == TriggerType.User)
                return trigger.User.Name;
            else if (trigger.Type == TriggerType.BuildType)
                return trigger.DependantBuild?.Name;
            else
                return "Source control";
        }
    }
}