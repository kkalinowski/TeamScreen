using System.Net.Http.Headers;
using System.Threading.Tasks;
using RestEase;

namespace TeamScreen.Jira
{
    public interface IJiraClient
    {
        [Header("Authorization")]
        AuthenticationHeaderValue Authorization { get; set; }

        [Get("rest/agile/1.0/board/{boardId}/sprint/{sprintId}/issue")]
        Task<GetIssuesForSprintResponse> GetIssuesForSprint([Path]int boardId, [Path]int sprintId);
    }
}