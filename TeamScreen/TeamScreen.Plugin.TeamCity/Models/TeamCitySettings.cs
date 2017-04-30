using TeamScreen.Data.Entities;

namespace TeamScreen.Plugin.TeamCity.Models
{
    public class TeamCitySettings : ISettings<TeamCitySettings>
    {
        public string Url { get; set; }
        public string Project { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public TeamCitySettings WithDefaultValues()
        {
            Project = Const.RootProject;
            return this;
        }
    }
}