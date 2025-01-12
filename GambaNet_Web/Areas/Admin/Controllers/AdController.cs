using GambaNet.Infrastructure.Identity.Enums;
using GambaNet_Web.Application.Abstraction;
using GambaNet_Web.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GambaNet_Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = nameof(Roles.Admin))]
    public class AdController : Controller
    {
        private readonly IAdService _adService;
        private readonly ILogger<AdController> _logger;

        public AdController(IAdService adService)
        {
            _adService = adService;
        }

        public async Task<IActionResult> Index()
        {
            var ads = await _adService.GetAllAdsAsync();
            return View(ads);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Ad ad, IFormFile image)
        {
            _logger.LogInformation("Create action called");

            if (ModelState.IsValid)
            {
                _logger.LogInformation("Model state is valid");

                if (image != null && image.Length > 0)
                {
                    _logger.LogInformation("Image file is provided");

                    try
                    {
                        // Save the image file to a location and set the ImagePath property
                        var filePath = Path.Combine("wwwroot/images", image.FileName);
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await image.CopyToAsync(stream);
                        }
                        ad.ImagePath = $"/images/{image.FileName}";
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, "An error occurred while saving the image file");
                        ModelState.AddModelError("", "An error occurred while saving the image file");
                        return View(ad);
                    }
                }

                try
                {
                    await _adService.AddAdAsync(ad);
                    _logger.LogInformation("Ad successfully created");
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "An error occurred while adding the ad");
                    ModelState.AddModelError("", "An error occurred while adding the ad");
                }
            }
            else
            {
                _logger.LogWarning("Model state is invalid");
            }

            return View(ad);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var ad = await _adService.GetAdByIdAsync(id);
            if (ad == null)
            {
                return NotFound();
            }
            return View(ad);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Ad ad)
        {
            if (id != ad.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                await _adService.UpdateAdAsync(ad);
                return RedirectToAction(nameof(Index));
            }
            return View(ad);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var ad = await _adService.GetAdByIdAsync(id);
            if (ad == null)
            {
                return NotFound();
            }
            return View(ad);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _adService.DeleteAdAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

