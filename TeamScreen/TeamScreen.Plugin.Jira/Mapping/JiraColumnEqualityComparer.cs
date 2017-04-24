using System.Collections.Generic;
using TeamScreen.Plugin.Jira.Models;

namespace TeamScreen.Plugin.Jira.Mapping
{
    public class JiraColumnEqualityComparer : IEqualityComparer<JiraIssuesModel>
    {
        public bool Equals(JiraIssuesModel x, JiraIssuesModel y)
        {
            return x.Column == y.Column;
        }

        public int GetHashCode(JiraIssuesModel obj)
        {
            return obj.GetHashCode();
        }
    }
}