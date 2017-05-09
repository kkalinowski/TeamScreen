using TeamScreen.Data.Entities;

namespace TeamScreen.Plugin.ProjectTeam.Models
{
    public class ProjectTeamSettings : ISettings<ProjectTeamSettings>
    {
        public ProjectTeamSettings WithDefaultValues()
        {
            return this;
        }
    }
}