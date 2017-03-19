namespace TeamScreen.Jira
{
    public class GetIssuesForSprintResponse
    {
        public Issue[] Issues { get; set; }
    }

    public class Issue
    {
        public Fields Fields { get; set; }
    }

    public class Fields
    {
        public string Summary { get; set; }
    }
}