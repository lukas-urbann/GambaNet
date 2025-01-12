using GambaNet.Infrastructure.Identity;
using GambaNet_Web.Application.Abstraction;
using GambaNet_Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GambaNet_Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IBalanceService _balanceService;
        private readonly UserManager<User> _userManager;

        public AccountController(IBalanceService balanceService, UserManager<User> userManager)
        {
            _balanceService = balanceService;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult AddMoney()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddMoney(AddMoneyViewModel model, string submitButton)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                if (user == null) return RedirectToAction("Login", "Account");

                if (submitButton == "PayPal")
                {
                    // Redirect to PayPal
                    string paypalUrl = "https://www.paypal.com/donate/?hosted_button_id=28UX6B9MWQWLS";
                    return Redirect(paypalUrl);
                }
                else if (submitButton == "AddMoney")
                {
                    // Verify captcha
                    if (VerifyCaptcha(model.CaptchaResponse))
                    {
                        // Add money to the user's account
                        var result = await _balanceService.AddBalanceAsync(user.Id.ToString(), model.Amount);
                        if (result)
                        {
                            return RedirectToAction("AddMoneySuccess");
                        }
                        else
                        {
                            ModelState.AddModelError("", "Failed to add money to the account.");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Captcha verification failed.");
                    }
                }
            }

            return View(model);
        }

        private bool VerifyCaptcha(string captchaResponse)
        {
            // Implement your captcha verification logic here
            return true; // Placeholder
        }

        public IActionResult AddMoneySuccess()
        {
            return View();
        }
    }
}
