using System;
using Newtonsoft.Json;

namespace TeamScreen.Plugin.Jira.Integration
{
    public class GetActiveSprintResponse
    {
        [JsonProperty(PropertyName = "values")]
        public Sprint[] Sprints { get; set; }
    }

    public class Sprint
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}