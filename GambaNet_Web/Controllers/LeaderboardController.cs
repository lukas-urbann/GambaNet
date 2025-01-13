using Microsoft.AspNetCore.Mvc;
using GambaNet_Web.Application.Abstraction;
using Microsoft.AspNetCore.Authorization;

namespace GambaNet_Web.Controllers
{
    public class LeaderboardController : Controller
    {
        private readonly IUserService _userService;

        public LeaderboardController(IUserService userService)
        {
            _userService = userService;
        }

        [Authorize]
        public IActionResult Index(int pageNumber = 1, int pageSize = 10)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Leaderboard", "Security");
            }

            int totalUsers;
            var topUsers = _userService.GetTopUsersByBalance(pageNumber, pageSize, out totalUsers);

            ViewBag.PageNumber = pageNumber;
            ViewBag.PageSize = pageSize;
            ViewBag.TotalUsers = totalUsers;

            return View(topUsers);
        }
    }
}
