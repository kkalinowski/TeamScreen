using Microsoft.AspNetCore.Mvc;
using TeamScreen.Plugin.Base;
using TeamScreen.Plugin.ProjectTeam.Controllers;

namespace TeamScreen.Plugin.ProjectTeam
{
    public class HealthCheckPlugin : IPlugin
    {
        public string Name { get; } = Const.PluginName;

        public string GetContentUrl(IUrlHelper urlHelper)
        {
            return urlHelper.Action(nameof(ProjectTeamController.Content), "ProjectTeam");
        }

        public string GetSettingsUrl(IUrlHelper urlHelper)
        {
            return urlHelper.Action(nameof(ProjectTeamController.Settings), "ProjectTeam");
        }
    }
}