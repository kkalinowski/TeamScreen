namespace TeamScreen.Jira
{
    public class GetIssuesForSprintResponse
    {
        public Issue[] Issues { get; set; }
    }

    public class Issue
    {
        public string Key { get; set; }
        public Fields Fields { get; set; }
    }

    public class Fields
    {
        public string Summary { get; set; }
        public string Status { get; set; }
    }

    public class Status
    {
        public string Name { get; set; }
    }
}