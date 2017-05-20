using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TeamScreen.Data.Services;
using TeamScreen.Plugin.Git.Integration;
using TeamScreen.Plugin.Git.Mapping;
using TeamScreen.Plugin.Git.Models;

namespace TeamScreen.Plugin.Git.Controllers
{
    public class GitController : Controller
    {
        private readonly ISettingsService _settingsService;
        private readonly IGitHubService _gitHubService;
        private readonly IGitMapper _gitMapper;

        public GitController(ISettingsService settingsService, IGitHubService gitHubService, IGitMapper gitMapper)
        {
            _settingsService = settingsService;
            _gitHubService = gitHubService;
            _gitMapper = gitMapper;
        }

        public async Task<PartialViewResult> Content()
        {
            var settings = await _settingsService.Get<GitSettings>(Const.PluginName);
            var commits = await _gitHubService.GetCommits(settings.Username, settings.Password, settings.Owner,
                settings.Repository);
            var branches = await _gitHubService.GetBranches(settings.Username, settings.Password, settings.Owner,
                settings.Repository);

            var model = new GitModel
            {
                RepositoryName = settings.Repository,
                Commits = _gitMapper.MapCommits(commits),
                NumberOfTodaysCommits = _gitMapper.GetNumberOfTodaysCommits(commits),
                BranchesCount = branches.Length
            };
            return PartialView(model);
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