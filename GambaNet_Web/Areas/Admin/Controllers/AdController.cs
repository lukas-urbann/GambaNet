using GambaNet.Infrastructure.Identity.Enums;
using GambaNet_Web.Application.Abstraction;
using GambaNet_Web.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GambaNet_Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = nameof(Roles.Admin))]
    public class AdController : Controller
    {
        private readonly IAdService _adService;
        private readonly ILogger<AdController> _logger;

        public AdController(IAdService adService, ILogger<AdController> logger)
        {
            _adService = adService;
            _logger = logger;
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
            if (ModelState.IsValid)
            {
                await _adService.UploadAdAsync(ad, image);
                return RedirectToAction(nameof(Index));
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
            try
            {
                await _adService.DeleteAdAsync(id);
                var ad = await _adService.GetAdByIdAsync(id);
                if (ad == null)
                {
                    _logger.LogInformation($"Ad with ID {id} has been confirmed deleted.");
                }
                else
                {
                    _logger.LogWarning($"Ad with ID {id} still exists after deletion attempt.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while deleting ad with ID {id}.");
                return RedirectToAction(nameof(Index), new { errorMessage = "Error occurred while deleting ad." });
            }
            return RedirectToAction(nameof(Index));
        }

    }
}
