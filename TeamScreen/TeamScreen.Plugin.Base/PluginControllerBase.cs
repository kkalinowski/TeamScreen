using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace TeamScreen.Plugin.Base
{
    public abstract class PluginControllerBase : Controller
    {
        public abstract string Name { get; }
        public abstract Task<PartialViewResult> Content();
    }
}
