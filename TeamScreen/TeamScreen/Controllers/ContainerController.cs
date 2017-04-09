using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TeamScreen.Controllers
{
    public class ContainerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}