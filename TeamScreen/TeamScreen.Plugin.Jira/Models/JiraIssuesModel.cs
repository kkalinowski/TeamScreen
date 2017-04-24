using System.Collections.Generic;
using TeamScreen.Plugin.Jira.Integration;

namespace TeamScreen.Plugin.Jira.Models
{
    public class JiraIssuesModel
    {
        public string Column { get; set; }
        public List<Issue> Issues { get; set; }

        public JiraIssuesModel()
        {
            Issues = new List<Issue>();
        }
    }
}