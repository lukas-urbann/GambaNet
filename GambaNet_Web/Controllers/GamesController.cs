using Microsoft.AspNetCore.Mvc;

namespace GambaNet_Web.Controllers
{
    public class GamesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        /* --- Nefunguje přetížení
        public IActionResult Index(string name, int numTimes = 1)
        {
            ViewData["Message"] = "Hello " + name;
            ViewData["NumTimes"] = numTimes;
            return View();
        }
        */
    }
}
