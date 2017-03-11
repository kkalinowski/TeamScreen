using System.Collections.Generic;
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
        Task<List<Project>> GetProjectsAsync();

        [Get("/httpAuth/app/rest/buildTypes?locator=affectedProject:(id:{projectId})&fields=buildType(id,name,builds($locator(running:false,canceled:false,count:1),build(number,status,statusText)))")]
        Task<List<Build>> GetBuildsWithStatusesAsync([Path]string projectId);
    }
}
