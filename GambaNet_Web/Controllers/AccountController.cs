using GambaNet.Infrastructure.Identity;
using GambaNet_Web.Application.Abstraction;
using GambaNet_Web.Application.Implementation;
using GambaNet_Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace GambaNet_Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IBalanceService _balanceService;
        private readonly UserManager<User> _userManager;
        private readonly IReCaptchaService _reCaptchaService;
        private readonly ILogger<AccountController> _logger;

        public AccountController(IBalanceService balanceService, UserManager<User> userManager, IReCaptchaService reCaptchaService, ILogger<AccountController> logger)
        {
            _balanceService = balanceService;
            _userManager = userManager;
            _reCaptchaService = reCaptchaService;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult AddMoney()
        {
            return View(new AddMoneyViewModel());
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
                    string paypalUrl = "https://www.paypal.com/donate/?hosted_button_id=28UX6B9MWQWLS";
                    return Redirect(paypalUrl);
                }
                else if (submitButton == "AddMoney")
                {
                    var isCaptchaValid = await VerifyCaptcha(model.gRecaptchaResponse);

                    if (!isCaptchaValid)
                    {
                        var result = await _balanceService.AddBalanceAsync(user.Id.ToString(), model.Amount);
                        return RedirectToAction("AddMoneySuccess");
                    }
                    else
                    {
                        _logger.LogError("Failed to add money to the account.");
                    }
                }
                return RedirectToAction("Info", "Home");
            }

            return View(model);
        }

        private async Task<bool> VerifyCaptcha(string captchaResponse)
        {
            var isCaptchaValid = await _reCaptchaService.VerifyCaptchaAsync(captchaResponse);
            _logger.LogInformation($"Captcha verification result: {isCaptchaValid}");
            return isCaptchaValid;
        }

        public IActionResult AddMoneySuccess()
        {
            return View();
        }
    }
}
