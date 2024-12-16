using Microsoft.AspNetCore.Mvc;

namespace GambaNet_Web.Areas.Admin.Controllers
{
    [Area("User")]
    public class ProductController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }
    }
}
