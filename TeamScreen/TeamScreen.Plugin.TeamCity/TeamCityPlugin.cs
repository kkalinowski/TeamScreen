using Microsoft.AspNetCore.Mvc;
using TeamScreen.Plugin.Base;
using TeamScreen.Plugin.TeamCity.Controllers;

namespace TeamScreen.Plugin.TeamCity
{
    public class TeamCityPlugin : IPlugin
    {
        public string Name { get; } = "TeamCity";

        public string GetContentUrl(IUrlHelper urlHelper)
        {
            return urlHelper.Action(nameof(TeamCityController.Content), nameof(TeamCityController));
        }
    }
}