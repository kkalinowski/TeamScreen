using System.Net.Http.Headers;
using System.Threading.Tasks;
using RestEase;

namespace TeamScreen.JIRA
{
    public interface IJiraClient
    {
        [Header("Authorization")]
        AuthenticationHeaderValue Authorization { get; set; }

        [Get("rest/agile/1.0/board/{boardId}/sprint/{sprintId}/issue")]
        Task<GetIssuesForSprintResponse> GetIssuesForSprint(int boardId, int sprintId);
    }
}