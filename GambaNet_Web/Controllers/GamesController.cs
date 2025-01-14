using GambaNet.Infrastructure.Identity;
using GambaNet.Infrastructure.Identity.Enums;
using GambaNet_Web.Application.Abstraction;
using GambaNet_Web.Application.Implementation;
using GambaNet_Web.Application.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GambaNet_Web.Controllers
{
    public class GamesController : Controller
    {
        private readonly UserManager<User> _userManager;
        IHomeService _homeService;

        public GamesController(UserManager<User> userManager, IHomeService homeService)
        {
            _userManager = userManager;
            _homeService = homeService;
        }

        [Authorize(Roles = $"{nameof(Roles.Admin)},{nameof(Roles.Default)}")]
        public IActionResult Index()
        {
            GameViewModel gameModel = _homeService.GetIndexViewModel();
            return View(gameModel);
        }

        [Authorize(Roles = $"{nameof(Roles.Admin)},{nameof(Roles.Default)}")]
        public IActionResult Cups(int id) 
        {
            Tuple<int, string?> ad = new Tuple<int, string?>(id, _userManager.GetUserId(User));
            return View(ad);
        }

        [Authorize(Roles = $"{nameof(Roles.Admin)},{nameof(Roles.Default)}")]
        public IActionResult Plinko(int id)
        {
            Tuple<int, string?> ad = new Tuple<int, string?>(id, _userManager.GetUserId(User));
            return View(ad);
        }

        [Authorize(Roles = $"{nameof(Roles.Admin)},{nameof(Roles.Default)}")]
        public IActionResult Slots(int id)
        {
            Tuple<int, string?> ad = new Tuple<int, string?>(id, _userManager.GetUserId(User));
            return View(ad);
        }
    }
}
