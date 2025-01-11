using Microsoft.AspNetCore.Mvc;
using GambaNet_Web.Application.Abstraction;
using GambaNet_Web.Domain.Entities;

namespace GambaNet_Web.Areas.Admin.Controllers
{
    public class AdController : Controller
    {
        private readonly IAdService _adService;

        public AdController(IAdService adService)
        {
            _adService = adService;
        }

        [HttpGet]
        public IActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Upload(Ad ad, IFormFile image)
        {
            if (ModelState.IsValid)
            {
                await _adService.UploadAdAsync(ad, image);
                return RedirectToAction("Upload");
            }
            return View(ad);
        }
    }
}
