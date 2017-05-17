using TeamScreen.Data.Entities;

namespace TeamScreen.Plugin.Git.Models
{
    public class GitSettings : ISettings<GitSettings>
    {
        public GitSettings WithDefaultValues()
        {
            return this;
        }
    }
}