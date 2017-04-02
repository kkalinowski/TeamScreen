﻿using System;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using RestEase;

namespace TeamScreen.TeamCity
{
    public interface ITeamCityService
    {
        Task<BuildJob[]> GetBuilds(string path, string username, string password);
    }

    public class TeamCityService : ITeamCityService
    {
        private const string RootProject = "_Root";

        public async Task<BuildJob[]> GetBuilds(string path, string username, string password)
        {
            var api = RestClient.For<ITeamCityClient>(path);
            var credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{password}"));
            api.Authorization = new AuthenticationHeaderValue("Basic", credentials);

            var projects = await api.GetProjectsAsync();
            return projects.Projects
                .Where(x => x.Id != RootProject)
                .SelectMany(x => api.GetLastBuildForProjectAsync(x.Id).Result.BuildJobs)
                .ToArray();
        }
    }
}