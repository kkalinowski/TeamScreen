using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using TeamScreen.Jira;

namespace TeamScreen.Controllers
{
    public class JiraController : Controller
    {
        private readonly IJiraService _jiraService;
        private readonly IConfigurationRoot _configurationRoot;

        public JiraController(IJiraService jiraService, IConfigurationRoot configurationRoot)
        {
            _jiraService = jiraService;
            _configurationRoot = configurationRoot;
        }

        public async Task<IActionResult> Index()
        {
            var url = _configurationRoot["JiraUrl"];
            var username = _configurationRoot["JiraUsername"];
            var password = _configurationRoot["JiraPassword"];
            var boardId = int.Parse(_configurationRoot["JiraBoardId"]);
            var sprintId = int.Parse(_configurationRoot["JiraSprintId"]);
            var issues = await _jiraService.GetIssues(url, username, password, boardId, sprintId);
            return View(issues);
        }
    }
}