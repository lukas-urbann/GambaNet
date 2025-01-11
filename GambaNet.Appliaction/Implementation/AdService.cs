using GambaNet_Web.Domain.Entities;
using GambaNet_Web.Application.Abstraction;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GambaNet_Web.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace GambaNet_Web.Application.Implementation
{
    public class AdService : IAdService
    {
        private readonly GambaNetDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public AdService(GambaNetDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        public async Task UploadAdAsync(Ad ad, IFormFile image)
        {
            var filePath = Path.Combine(_environment.WebRootPath, "ads", image.FileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await image.CopyToAsync(stream);
            }
            ad.ImagePath = $"/ads/{image.FileName}";
            _context.Ads.Add(ad);
            await _context.SaveChangesAsync();
        }

        public async Task<Ad> GetRandomAdAsync()
        {
            var ads = await _context.Ads.ToListAsync();
            var random = new Random();
            return ads[random.Next(ads.Count)];
        }
    }
}