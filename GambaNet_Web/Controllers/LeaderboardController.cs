using Microsoft.AspNetCore.Mvc;
using GambaNet_Web.Application.Abstraction;

namespace GambaNet_Web.Controllers
{
    public class LeaderboardController : Controller
    {
        private readonly IUserService _userService;

        public LeaderboardController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index(int pageNumber = 1, int pageSize = 10)
        {
            int totalUsers;
            var topUsers = _userService.GetTopUsersByBalance(pageNumber, pageSize, out totalUsers);

            ViewBag.PageNumber = pageNumber;
            ViewBag.PageSize = pageSize;
            ViewBag.TotalUsers = totalUsers;

            return View(topUsers);
        }
    }
}
