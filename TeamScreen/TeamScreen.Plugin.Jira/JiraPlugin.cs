using Microsoft.AspNetCore.Mvc;
using TeamScreen.Plugin.Base;
using TeamScreen.Plugin.Jira.Controllers;

namespace TeamScreen.Plugin.Jira
{
    public class JiraPlugin : IPlugin
    {
        public string Name { get; } = Const.PluginName;

        public string GetContentUrl(IUrlHelper urlHelper)
        {
            return urlHelper.Action(nameof(JiraController.Content), "Jira");
        }

        public string GetSettingsUrl(IUrlHelper urlHelper)
        {
            return urlHelper.Action(nameof(JiraController.Settings), "Jira");
        }
    }
}