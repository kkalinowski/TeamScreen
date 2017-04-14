using Microsoft.AspNetCore.Mvc;

namespace TeamScreen.Controllers
{
    public class CoreSettingsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}