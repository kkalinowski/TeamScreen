using System.Net.Http.Headers;
using System.Threading.Tasks;
using RestEase;

namespace TeamScreen.Plugin.TeamCity.Integration
{
    [Header("Accept", "application/json")]
    public interface ITeamCityClient
    {
        [Header("Authorization")]
        AuthenticationHeaderValue Authorization { get; set; }

        [Get("/httpAuth/app/rest/projects")]
        Task<GetProjectsResponse> GetProjectsAsync();

        [Get("/httpAuth/app/rest/buildTypes?locator=affectedProject:(id:{projectId})&fields=buildType(name,project(id,name),builds($locator(running:any,canceled:false,count:1),build(status,state,startDate,finishDate,triggered(user(name,email),buildType(name)))))")]
        Task<GetBuildsResponse> GetLastBuildForProjectAsync([Path]string projectId);
    }
}
