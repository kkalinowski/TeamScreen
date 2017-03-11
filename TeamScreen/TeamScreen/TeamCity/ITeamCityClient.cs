using System.Collections.Generic;
using System.Threading.Tasks;
using RestEase;

namespace TeamScreen.TeamCity
{
    public interface ITeamCityClient
    {
        [Get("projects")]
        Task<List<Project>> GetProjectsAsync();

        [Get("buildTypes?locator=affectedProject:(id:{projectid})&fields=buildType(id,name,builds($locator(running:false,canceled:false,count:1),build(number,status,statusText)))")]
        Task<List<Build>> GetBuildsWithStatusesAsync([Path]string projectId);
    }
}
