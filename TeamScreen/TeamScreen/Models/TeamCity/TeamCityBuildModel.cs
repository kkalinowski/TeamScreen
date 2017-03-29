using System;

namespace TeamScreen.Models.TeamCity
{
    public class TeamCityBuildModel
    {
        public string Name { get; set; }
        public TeamCityStatusModel Status { get; set; }
        public DateTime Date { get; set; }
        public string TrrggeredBy { get; set; }
    }

    public enum TeamCityStatusModel
    {
        Success,
        Pending,
        Failure
    }
}