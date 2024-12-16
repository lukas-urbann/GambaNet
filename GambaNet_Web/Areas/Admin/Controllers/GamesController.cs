using Microsoft.AspNetCore.Mvc;

namespace GambaNet_Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class GamesController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }
    }
}
