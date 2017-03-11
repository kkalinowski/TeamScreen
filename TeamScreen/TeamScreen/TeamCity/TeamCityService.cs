using System.Linq;
using System.Threading.Tasks;
using RestEase;

namespace TeamScreen.TeamCity
{
    public interface ITeamCityService
    {
        Task<Build[]> GetBuilds(string path);
    }

    public class TeamCityService : ITeamCityService
    {
        public async Task<Build[]> GetBuilds(string path)
        {
            var api = RestClient.For<ITeamCityClient>(path);

            var projects = await api.GetProjectsAsync();
            return projects
                .SelectMany(x => api.GetBuildsWithStatusesAsync(x.Id).Result)
                .ToArray();
        }
    }
}