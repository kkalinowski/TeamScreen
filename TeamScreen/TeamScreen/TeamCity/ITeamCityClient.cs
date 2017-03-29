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

        [Get("/httpAuth/app/rest/buildTypes?locator=affectedProject:(id:{projectId})&fields=buildType(name,project(id,name),builds($locator(canceled:false,count:1),build(status,state,startDate,finishDate,triggered(user(name,email)))))")]
        Task<GetBuildsResponse> GetLastBuildForProjectAsync([Path]string projectId);
    }
}
