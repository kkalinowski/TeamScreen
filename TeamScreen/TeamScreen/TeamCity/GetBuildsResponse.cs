using System.Collections.Generic;
using Newtonsoft.Json;

namespace TeamScreen.TeamCity
{
    public class GetBuildsResponse
    {
        [JsonProperty(PropertyName = "buildType")]
        public List<BuildJob> BuildJobs { get; set; }
    }

    public class BuildJob
    {
        public string Name { get; set; }
        [JsonProperty(PropertyName = "builds")]
        public BuildCollection BuildCollection { get; set; }
    }

    public class BuildCollection
    {
        [JsonProperty(PropertyName = "build")]
        public Build[] Builds { get; set; }
    }

    public class Build
    {
        public string Status { get; set; }
    }
}