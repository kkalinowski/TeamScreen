using System;
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

        [JsonConverter(typeof(StringEnumConverter))]
        public BuildState State { get; set; }

        [JsonConverter(typeof(TeamCityDateConverter))]
        public DateTime? StartDate { get; set; }

        [JsonConverter(typeof(TeamCityDateConverter))]
        public DateTime? FinishDate { get; set; }

        [JsonProperty(PropertyName = "triggered")]
        public BuildTrigger Trigger { get; set; }
    }

    public class BuildTrigger
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public TriggerType Type { get; set; }

        public TeamCityUser User { get; set; }
    }

    public class TeamCityUser
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }

    public enum TriggerType
    {
        User,
        VCS,
        BuildType//don't really know what it is
    }

    public enum BuildStatus
    {
        Success,
        Failure,
        Error
    }

    public enum BuildState
    {
        Queued,
        Running,
        Finished
    }
}