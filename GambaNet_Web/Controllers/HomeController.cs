using GambaNet_Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using GambaNet_Web.Application.Abstraction;
using GambaNet_Web.Application.ViewModel;

namespace GambaNet_Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        IHomeService _homeService;
        
        public HomeController(ILogger<HomeController> logger, IHomeService homeService)
        {
            _logger = logger;
            _homeService = homeService;
        }

        public IActionResult Index()
        {
            GameViewModel gameModel = _homeService.GetIndexViewModel();
            return View(gameModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
