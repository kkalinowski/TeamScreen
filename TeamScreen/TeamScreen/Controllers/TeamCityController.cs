using Microsoft.AspNetCore.Mvc;

namespace TeamScreen.Controllers
{
    public class TeamCityController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}