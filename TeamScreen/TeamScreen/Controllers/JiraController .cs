using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Configuration;
using TeamScreen.Jira;
using TeamScreen.Models.Jira;

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
            var boardConfiguration = await _jiraService.GetBoardConfigurationAsync(url, username, password, boardId);
            var modelDict = MapBoardConfigurationToModels(boardConfiguration);

            var response = await _jiraService.GetIssuesForActiveSprintAsync(url, username, password, boardId);
            foreach (var issue in response.Issues)
                modelDict[issue.Fields.Status.Id].Issues.Add(issue);

            return View(modelDict.Values.Distinct((x, y) => x.Column == y.Column));
        }

        private Dictionary<int, JiraIssuesModel> MapBoardConfigurationToModels(GetBoardConfigurationResponse boardConfiguration)
        {
            var dict = new Dictionary<int, JiraIssuesModel>();
            var columns = boardConfiguration.ColumnConfig.Columns;
            foreach (var column in columns)
            {
                var model = new JiraIssuesModel { Column = column.Name };
                foreach (var status in column.Statuses)
                {
                    dict.Add(status.Id, model);
                }
            }

            return dict;
        }
    }
}