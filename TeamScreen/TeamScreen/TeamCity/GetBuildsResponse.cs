using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

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
        public Project Project { get; set; }

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
        [JsonConverter(typeof(StringEnumConverter))]
        public BuildStatus Status { get; set; }
    }

    public enum BuildStatus
    {
        Success,
        Failure
    }
}