using GambaNet.Infrastructure.Identity;
using GambaNet.Infrastructure.Identity.Enums;
using GambaNet_Web.Application.Abstraction;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GambaNet_Web.Controllers
{
    public class GamesController : Controller
    {
        private readonly UserManager<User> _userManager;

        public GamesController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        [Authorize(Roles = nameof(Roles.Default))]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = nameof(Roles.Default))]
        public IActionResult Cups(int id)
        {
            Tuple<int, string?> ad = new Tuple<int, string?>(id, _userManager.GetUserId(User));
            return View(ad);
        }

        [Authorize(Roles = nameof(Roles.Default))]
        public IActionResult Plinko(int id)
        {
            Tuple<int, string?> ad = new Tuple<int, string?>(id, _userManager.GetUserId(User));
            return View(ad);
        }

        [Authorize(Roles = nameof(Roles.Default))]
        public IActionResult Slot(int id)
        {
            Tuple<int, string?> ad = new Tuple<int, string?>(id, _userManager.GetUserId(User));
            return View(ad);
        }
    }
}
