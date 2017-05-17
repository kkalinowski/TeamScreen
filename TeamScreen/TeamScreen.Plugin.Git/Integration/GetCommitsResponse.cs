using System;
using Newtonsoft.Json;

namespace TeamScreen.Plugin.Git.Integration
{
    public class GetCommitsResponse
    {
        public Commit[] Commits { get; set; }
    }

    public class Commit
    {
        [JsonProperty(PropertyName = "commit")]
        public CommitInfo Info { get; set; }
    }

    public class CommitInfo
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