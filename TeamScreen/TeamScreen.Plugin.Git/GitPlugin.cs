using Microsoft.AspNetCore.Mvc;
using TeamScreen.Plugin.Base;
using TeamScreen.Plugin.Git.Controllers;

namespace TeamScreen.Plugin.Git
{
    public class GitPlugin : IPlugin
    {
        public string Name { get; } = Const.PluginName;

        public string GetContentUrl(IUrlHelper urlHelper)
        {
            return urlHelper.Action(nameof(GitController.Content), "Git");
        }

        public string GetSettingsUrl(IUrlHelper urlHelper)
        {
            return urlHelper.Action(nameof(GitController.Settings), "Git");
        }
    }
}