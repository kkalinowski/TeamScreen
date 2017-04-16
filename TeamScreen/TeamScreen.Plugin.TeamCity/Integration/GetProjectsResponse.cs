using System.Collections.Generic;
using Newtonsoft.Json;

namespace TeamScreen.Plugin.TeamCity.Integration
{
    public class GetProjectsResponse
    {
        [JsonProperty("project")]
        public List<Project> Projects { get; set; }
    }

    public class Project
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}