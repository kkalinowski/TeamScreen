using System.Collections.Generic;
using System.Linq;
using TeamScreen.Plugin.Git.Integration;
using TeamScreen.Plugin.Git.Models;

namespace TeamScreen.Plugin.Git.Mapping
{
    public interface IGitMapper
    {
        CommitModel[] MapCommits(IEnumerable<GetCommitsResponse> response);
    }

    public class GitMapper : IGitMapper
    {
        public CommitModel[] MapCommits(IEnumerable<GetCommitsResponse> response)
        {
            return response
                .Select(x => x.Commit)
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