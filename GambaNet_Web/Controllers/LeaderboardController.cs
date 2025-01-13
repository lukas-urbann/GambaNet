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

        public IActionResult Index()
        {
            var topUsers = _userService.GetTopUsersByBalance(10); // Fetch top 10 users by balance
            return View(topUsers);
        }
    }
}
