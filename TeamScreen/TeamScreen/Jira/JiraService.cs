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
        Task<GetIssuesForSprintResponse> GetIssuesForActiveSprint(string path, string username, string password, int boardId);
    }

    public class JiraService : IJiraService
    {
        public async Task<GetIssuesForSprintResponse> GetIssuesForActiveSprint(string path, string username, string password, int boardId)
        {
            var api = RestClient.For<IJiraClient>(path);
            var credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{password}"));
            api.Authorization = new AuthenticationHeaderValue("Basic", credentials);

            var activeSprint = await api.GetActiveSprint(boardId);
            return await api.GetIssuesForSprint(boardId, activeSprint.Sprints.First().Id);
        }
    }
}