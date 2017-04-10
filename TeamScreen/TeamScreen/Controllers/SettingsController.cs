using Microsoft.AspNetCore.Mvc;

namespace TeamScreen.Controllers
{
    public class SettingsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}