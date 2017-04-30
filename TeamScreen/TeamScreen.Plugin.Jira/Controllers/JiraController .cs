using System.Threading.Tasks;
using TeamScreen.Plugin.Jira.Integration;
using TeamScreen.Plugin.Jira.Mapping;
using Microsoft.AspNetCore.Mvc;
using TeamScreen.Data.Services;
using TeamScreen.Plugin.Jira.Models;

namespace TeamScreen.Plugin.Jira.Controllers
{
    public class JiraController : Controller
    {
        private readonly IJiraService _jiraService;
        private readonly IIssueMapper _issueMapper;
        private readonly ISettingsService _settingsService;

        public JiraController(IJiraService jiraService, IIssueMapper issueMapper, ISettingsService settingsService)
        {
            _jiraService = jiraService;
            _issueMapper = issueMapper;
            _settingsService = settingsService;
        }

        public async Task<PartialViewResult> Content()
        {
            var settings = await _settingsService.Get<JiraSettings>(Const.PluginName);
            var boardConfiguration = await _jiraService.GetBoardConfigurationAsync(settings.Url, settings.Username, settings.Password, settings.BoardId);
            var issues = await _jiraService.GetIssuesForActiveSprintAsync(settings.Url, settings.Username, settings.Password, settings.BoardId);

            var models = _issueMapper.Map(issues, boardConfiguration);
            return PartialView(models);
        }

        public PartialViewResult Settings()
        {
            return PartialView();
        }

        public async Task<JsonResult> GetSettings()
        {
            var settings = await _settingsService.Get<JiraSettings>(Const.PluginName);
            return Json(settings);
        }

        [HttpPost]
        public async Task SaveSettings([FromBody]JiraSettings settings)
        {
            await _settingsService.Set(Const.PluginName, settings);
        }
    }
}