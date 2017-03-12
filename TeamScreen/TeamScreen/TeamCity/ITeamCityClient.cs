using System.Net.Http.Headers;
using System.Threading.Tasks;
using RestEase;

namespace TeamScreen.TeamCity
{
    [Header("Accept", "application/json")]
    public interface ITeamCityClient
    {
        [Header("Authorization")]
        AuthenticationHeaderValue Authorization { get; set; }

        [Get("/httpAuth/app/rest/projects")]
        Task<GetProjectsResponse> GetProjectsAsync();

        [Get("/httpAuth/app/rest/buildTypes?locator=affectedProject:(id:{projectId})&fields=buildType(id,name,project,builds($locator(running:false,canceled:false,count:1),build(number,status,statusText)))")]
        Task<GetBuildsResponse> GetBuildsWithStatusesAsync([Path]string projectId);
    }
}
