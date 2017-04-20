using Microsoft.AspNetCore.Mvc;

namespace TeamScreen.Plugin.Base
{
    public interface IPlugin
    {
        string Name { get; }
        string GetContentUrl(IUrlHelper urlHelper);
        string GetSettingsUrl(IUrlHelper urlHelper);
    }
}
