using System;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using RestEase;

namespace TeamScreen.Jira
{
    public interface IJiraService
    {
        Task<GetIssuesForSprintResponse> GetIssuesForActiveSprintAsync(string path, string username, string password, int boardId);
        Task<GetBoardConfigurationResponse> GetBoardConfigurationAsync(string path, string username, string password, int boardId);
    }

    public class JiraService : IJiraService
    {
        private IJiraClient CreateApi(string path, string username, string password)
        {
            var api = RestClient.For<IJiraClient>(path);
            var credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{password}"));
            api.Authorization = new AuthenticationHeaderValue("Basic", credentials);
            return api;
        }

        public async Task<GetIssuesForSprintResponse> GetIssuesForActiveSprintAsync(string path, string username, string password, int boardId)
        {
            var api = CreateApi(path, username, password);
            var activeSprint = await api.GetActiveSprint(boardId);
            return await api.GetIssuesForSprint(boardId, activeSprint.Sprints.First().Id);
        }

        public async Task<GetBoardConfigurationResponse> GetBoardConfigurationAsync(string path, string username, string password, int boardId)
        {
            var api = CreateApi(path, username, password);
            return await api.GetBoardConfiguration(boardId);
        }
    }
}