using GambaNet.Infrastructure.Identity;
using GambaNet_Web.Application.Abstraction;
using GambaNet_Web.Application.Implementation;
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
        private readonly IReCaptchaService _reCaptchaService;

        public AccountController(IBalanceService balanceService, UserManager<User> userManager, IReCaptchaService reCaptchaService)
        {
            _balanceService = balanceService;
            _userManager = userManager;
            _reCaptchaService = reCaptchaService;
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
                    // Verify captcha (testing potom odstranit !)
                    if (!await VerifyCaptcha(model.CaptchaResponse))
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
                return RedirectToAction("Info", "Home");

            }

            return View(model);
        }

        private async Task<bool> VerifyCaptcha(string captchaResponse)
        {
            return await _reCaptchaService.VerifyCaptchaAsync(captchaResponse);
        }

        public IActionResult AddMoneySuccess()
        {
            return View();
        }
    }
}
