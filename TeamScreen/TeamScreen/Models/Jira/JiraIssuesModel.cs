using System.Collections.Generic;
using TeamScreen.Jira;

namespace TeamScreen.Models.Jira
{
    public class JiraIssuesModel
    {
        public Dictionary<string, Issue[]> Issues { get; set; }
    }
}