using System.Linq;
using TeamScreen.Plugin.Git.Integration;
using TeamScreen.Plugin.Git.Models;

namespace TeamScreen.Plugin.Git.Mapping
{
    public interface IGitMapper
    {
        CommitModel[] MapCommits(GetCommitsResponse response);
    }

    public class GitMapper : IGitMapper
    {
        public CommitModel[] MapCommits(GetCommitsResponse response)
        {
            return response.Commits
                .Select(x => x.Info)
                .Select(x => new CommitModel
                {
                    Message = x.Message,
                    AuthorEmail = x.Committer.Email,
                    Date = x.Committer.Date
                })
                .ToArray();
        }
    }
}