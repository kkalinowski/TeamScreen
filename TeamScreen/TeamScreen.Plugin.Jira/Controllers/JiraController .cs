using System.Threading.Tasks;
using TeamScreen.Plugin.Jira.Integration;
using TeamScreen.Plugin.Jira.Mapping;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using TeamScreen.Plugin.Jira.Models;

namespace TeamScreen.Plugin.Jira.Controllers
{
    public class JiraController : Controller
    {
        private readonly IJiraService _jiraService;
        private readonly IConfigurationRoot _configurationRoot;
        private readonly IIssueMapper _issueMapper;

        public JiraController(IJiraService jiraService, IConfigurationRoot configurationRoot, IIssueMapper issueMapper)
        {
            _jiraService = jiraService;
            _configurationRoot = configurationRoot;
            _issueMapper = issueMapper;
        }

        public async Task<PartialViewResult> Content()
        {
            var url = _configurationRoot["JiraUrl"];
            var username = _configurationRoot["JiraUsername"];
            var password = _configurationRoot["JiraPassword"];
            var boardId = int.Parse(_configurationRoot["JiraBoardId"]);
            var boardConfiguration = await _jiraService.GetBoardConfigurationAsync(url, username, password, boardId);
            var issues = await _jiraService.GetIssuesForActiveSprintAsync(url, username, password, boardId);

            var models = _issueMapper.Map(issues, boardConfiguration);
            return PartialView(models);
        }

        public PartialViewResult Settings()
        {
            var model = new JiraSettings();
            return PartialView(model);
        }
    }
}