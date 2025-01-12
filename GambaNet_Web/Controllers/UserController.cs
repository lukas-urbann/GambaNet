using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using GambaNet_Web.Domain.Entities;
using GambaNet_Web.Application.Abstraction;
using System.Threading.Tasks;
using GambaNet.Infrastructure.Identity;


namespace GambaNet_Web.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IBalanceService _balanceService;

        public UserController(UserManager<User> userManager, IBalanceService balanceService)
        {
            _userManager = userManager;
            _balanceService = balanceService;
        }

        [HttpPost]
        public async Task<IActionResult> AddBalance()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user != null)
            {
                await _balanceService.AddBalanceAsync(user.Id.ToString(), 10); // Add a fixed amount to the user's balance
            }
            return RedirectToAction("Info", "Home");
        }
    }
}
