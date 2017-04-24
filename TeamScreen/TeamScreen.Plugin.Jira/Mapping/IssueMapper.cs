using System.Collections.Generic;
using System.Linq;
using TeamScreen.Plugin.Jira.Integration;
using TeamScreen.Plugin.Jira.Models;

namespace TeamScreen.Plugin.Jira.Mapping
{
    public interface IIssueMapper
    {
        JiraIssuesModel[] Map(GetIssuesForSprintResponse issuesResponse,
            GetBoardConfigurationResponse boardConfigurationResponse);
    }

    public class IssueMapper : IIssueMapper
    {
        public JiraIssuesModel[] Map(GetIssuesForSprintResponse issuesResponse, GetBoardConfigurationResponse boardConfigurationResponse)
        {
            var modelDict = MapBoardConfiguration(boardConfigurationResponse);

            foreach (var issue in issuesResponse.Issues)
                modelDict[issue.Fields.Status.Id].Issues.Add(issue);

            return modelDict.Values
                .Distinct((x, y) => x.Column == y.Column)
                .ToArray();
        }

        private Dictionary<int, JiraIssuesModel> MapBoardConfiguration(GetBoardConfigurationResponse boardConfiguration)
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