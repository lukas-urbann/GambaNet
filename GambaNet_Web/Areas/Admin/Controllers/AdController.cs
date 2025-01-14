using Microsoft.AspNetCore.Mvc;
using GambaNet_Web.Domain.Entities;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using GambaNet_Web.Infrastructure.Database;

namespace GambaNet_Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdController : Controller
    {
        private readonly GambaNetDbContext _context;

        public AdController(GambaNetDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Ad
        public async Task<IActionResult> Index()
        {
            var ads = await _context.Ads.ToListAsync();
            return View(ads);
        }

        // GET: Admin/Ad/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var ad = await _context.Ads.FindAsync(id);
            if (ad == null)
            {
                return NotFound();
            }
            return View(ad);
        }

        // POST: Admin/Ad/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Url")] Ad ad, IFormFile image)
        {
            if (id != ad.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (image != null && image.Length > 0)
                    {
                        // Save the image to a location and set the path to ad.ImagePath
                        var imagePath = Path.Combine("wwwroot/images", image.FileName);
                        using (var stream = new FileStream(imagePath, FileMode.Create))
                        {
                            await image.CopyToAsync(stream);
                        }
                        ad.ImagePath = $"/images/{image.FileName}";
                    }

                    _context.Update(ad);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdExists(ad.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(ad);
        }

        private bool AdExists(int id)
        {
            return _context.Ads.Any(e => e.Id == id);
        }
    }
}
