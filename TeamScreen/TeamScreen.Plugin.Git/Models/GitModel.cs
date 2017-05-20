namespace TeamScreen.Plugin.Git.Models
{
    public class GitModel
    {
        public string RepositoryName { get; set; }
        public CommitModel[] Commits { get; set; }
        public int NumberOfTodaysCommits { get; set; }
        public int BranchesCount { get; set; }
        public int TagsCount { get; set; }
    }
}