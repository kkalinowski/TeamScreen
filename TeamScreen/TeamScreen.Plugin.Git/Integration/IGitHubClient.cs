using System.Net.Http.Headers;
using System.Threading.Tasks;
using RestEase;

namespace TeamScreen.Plugin.Git.Integration
{
    [Header("Accept", "application/json")]
    public interface IGitHubClient
    {
        [Header("Authorization")]
        AuthenticationHeaderValue Authorization { get; set; }

        [Get("/repos/{owner}/{repo}/commits")]
        Task<GetCommitsResponse> GetCommitsAsync([Path]string owner, [Path]string repo);
    }
}