using TeamScreen.Data.Entities;

namespace TeamScreen.Plugin.TeamCity.Models
{
    public class TeamCitySettings : ISettings<TeamCitySettings>
    {
        private const string DefaultTeamCityProjectContainer = "_Root";

        public string Url { get; set; }
        public string Project { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public TeamCitySettings WithDefaultValues()
        {
            Project = DefaultTeamCityProjectContainer;
            return this;
        }
    }
}