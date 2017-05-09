using TeamScreen.Data.Entities;

namespace TeamScreen.Plugin.ProjectTeam.Models
{
    public class ProjectTeamSettings : ISettings<ProjectTeamSettings>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Techs { get; set; }

        public ProjectTeamSettings WithDefaultValues()
        {
            return this;
        }
    }
}