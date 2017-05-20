namespace TeamScreen.Plugin.Git.Models
{
    public class GitModel
    {
        public string RepositoryName { get; set; }
        public CommitModel[] Commits { get; set; }
        public int NumberOfTodaysCommits { get; set; }
    }
}