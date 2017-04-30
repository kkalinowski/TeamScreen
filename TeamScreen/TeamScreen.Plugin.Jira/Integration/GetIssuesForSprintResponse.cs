using Newtonsoft.Json;

namespace TeamScreen.Plugin.Jira.Integration
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
        public Status Status { get; set; }
        public Assignee Assignee { get; set; }
    }

    public class Assignee
    {
        [JsonProperty("displayName")]
        public string Name { get; set; }
        [JsonProperty("emailAddress")]
        public string Email { get; set; }
    }

    public class Status
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}