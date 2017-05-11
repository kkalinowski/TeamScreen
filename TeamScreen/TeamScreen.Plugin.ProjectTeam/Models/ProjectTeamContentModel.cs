using TeamScreen.Data.Entities;

namespace TeamScreen.Plugin.ProjectTeam.Models
{
    public class ProjectTeamContentModel
    {
        public string ProjectName { get; set; }
        public string Description { get; set; }
        public string[] UsedTechnologies { get; set; }
        public ApplicationUser[] People { get; set; }
    }
}