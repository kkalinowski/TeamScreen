using System;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using RestEase;

namespace TeamScreen.Plugin.Git.Integration
{
    public interface IGitHubService
    {
        Task<GetCommitsResponse> GetBuilds(string path, string username, string password, string owner, string repo);
    }

    public class GitHubService : IGitHubService
    {
        public async Task<GetCommitsResponse> GetBuilds(string path, string username, string password, string owner, string repo)
        {
            var api = RestClient.For<IGitHubClient>(path);
            var credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{password}"));
            api.Authorization = new AuthenticationHeaderValue("Basic", credentials);

            return await api.GetCommitsAsync(owner, repo);
        }
    }
}