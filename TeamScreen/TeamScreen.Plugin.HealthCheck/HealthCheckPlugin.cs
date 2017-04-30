using Microsoft.AspNetCore.Mvc;
using TeamScreen.Plugin.Base;
using TeamScreen.Plugin.HealthCheck.Controllers;

namespace TeamScreen.Plugin.HealthCheck
{
    public class HealthCheckPlugin : IPlugin
    {
        public string Name { get; } = Const.PluginName;

        public string GetContentUrl(IUrlHelper urlHelper)
        {
            return urlHelper.Action(nameof(HealthCheckController.Content), "HealthCheck");
        }

        public string GetSettingsUrl(IUrlHelper urlHelper)
        {
            return urlHelper.Action(nameof(HealthCheckController.Settings), "HealthCheck");
        }
    }
}