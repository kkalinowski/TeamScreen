using System;
namespace TeamScreen.Plugin.Git.Integration
{
    public class GetCommitsResponse
    {
        public Commit Commit { get; set; }
    }

    public class Commit
    {
        public string Message { get; set; }
        public Committer Committer { get; set; }
    }

    public class Committer
    {
        public string Email { get; set; }
        public DateTime Date { get; set; }
    }
}