using GambaNet_Web.Domain.Entities;
using GambaNet_Web.Application.Abstraction;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using GambaNet_Web.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace GambaNet_Web.Application.Implementation
{
    public class AdService : IAdService
    {
        private readonly GambaNetDbContext _context;
        private readonly IWebHostEnvironment _environment;
        private readonly ILogger<AdService> _logger;

        public AdService(GambaNetDbContext context, IWebHostEnvironment environment, ILogger<AdService> logger)
        {
            _context = context;
            _environment = environment;
            _logger = logger;
        }

        public async Task UploadAdAsync(Ad ad, IFormFile image)
        {
            try
            {
                var filePath = Path.Combine(_environment.WebRootPath, "ads", image.FileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await image.CopyToAsync(stream);
                }
                ad.ImagePath = $"/ads/{image.FileName}";
                _context.Ads.Add(ad);
                await _context.SaveChangesAsync();
                _logger.LogInformation("Ad uploaded successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while uploading the ad");
                throw;
            }
        }

        public async Task<Ad> GetRandomAdAsync()
        {
            try
            {
                var ads = await _context.Ads.ToListAsync();
                if (ads.Count == 0)
                {
                    return null;
                }
                var random = new Random();
                return ads[random.Next(ads.Count)];
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting a random ad");
                throw;
            }
        }

        public async Task<IEnumerable<Ad>> GetAllAdsAsync()
        {
            try
            {
                return await _context.Ads.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting all ads");
                throw;
            }
        }

        public async Task<Ad> GetAdByIdAsync(int id)
        {
            try
            {
                return await _context.Ads.FindAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting the ad by ID");
                throw;
            }
        }

        public async Task AddAdAsync(Ad ad)
        {
            try
            {
                _context.Ads.Add(ad);
                await _context.SaveChangesAsync();
                _logger.LogInformation("Ad added successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while adding the ad");
                throw;
            }
        }

        public async Task UpdateAdAsync(Ad ad)
        {
            try
            {
                _context.Ads.Update(ad);
                await _context.SaveChangesAsync();
                _logger.LogInformation("Ad updated successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating the ad");
                throw;
            }
        }

        public async Task DeleteAdAsync(int id)
        {
            try
            {
                var ad = await _context.Ads.FindAsync(id);
                if (ad != null)
                {
                    _context.Ads.Remove(ad);
                    await _context.SaveChangesAsync();
                    _logger.LogInformation("Ad deleted successfully");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting the ad");
                throw;
            }
        }
    }
}



