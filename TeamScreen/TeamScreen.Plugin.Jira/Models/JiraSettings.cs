using TeamScreen.Data.Entities;

namespace TeamScreen.Plugin.Jira.Models
{
    public class JiraSettings : ISettings<JiraSettings>
    {
        public string Url { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int BoardId { get; set; }

        public JiraSettings WithDefaultValues()
        {
            return this;
        }
    }
}