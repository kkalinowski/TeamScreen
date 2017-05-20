using System;

namespace TeamScreen.Plugin.Git.Models
{
    public class CommitModel
    {
        public string AuthorEmail { get; set; }
        public DateTime Date { get; set; }
        public string Message { get; set; }
    }
}