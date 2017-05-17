using TeamScreen.Data.Entities;

namespace TeamScreen.Plugin.Git.Models
{
    public class GitSettings : ISettings<GitSettings>
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Owner { get; set; }
        public string Repository { get; set; }

        public GitSettings WithDefaultValues()
        {
            return this;
        }
    }
}