using System;

namespace TeamScreen.Plugin.TeamCity.Mapping
{
    public class TeamCityBuildModel
    {
        public string Name { get; set; }
        public TeamCityStatusModel Status { get; set; }
        public DateTime Date { get; set; }
        public string TriggeredBy { get; set; }
    }

    public enum TeamCityStatusModel
    {
        Success,
        Pending,
        Failure
    }
}