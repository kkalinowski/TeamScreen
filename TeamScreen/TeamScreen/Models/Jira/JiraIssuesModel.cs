using System.Collections.Generic;
using TeamScreen.Jira;

namespace TeamScreen.Models.Jira
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