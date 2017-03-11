using System.Collections.Generic;
using System.Threading.Tasks;
using RestEase;

namespace TeamScreen.TeamCity
{
    public interface ITeamCityClient
    {
        [Get("/app/rest/projects")]
        Task<List<Project>> GetProjectsAsync();

        [Get("/app/rest/buildTypes?locator=affectedProject:(id:{projectId})&fields=buildType(id,name,builds($locator(running:false,canceled:false,count:1),build(number,status,statusText)))")]
        Task<List<Build>> GetBuildsWithStatusesAsync([Path]string projectId);
    }
}
