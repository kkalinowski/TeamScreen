using Microsoft.AspNetCore.Mvc;
using TeamScreen.Controllers;
using TeamScreen.Plugin.Base;

namespace TeamScreen
{
    public class JiraPlugin : IPlugin
    {
        public string Name { get; } = "JIRA";

        public string GetContentUrl(IUrlHelper urlHelper)
        {
            return urlHelper.Action(nameof(JiraController.Content), nameof(JiraController));
        }
    }
}