using GambaNet_Web.Domain.Entities;
using GambaNet_Web.Application.Abstraction;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
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

        public IList<Ad> Select()
        {
            return _context.Ads.ToList();
        }
        public void Create(Ad ad)
        {
            _context.Ads.Add(ad);
            _context.SaveChanges();
        }
        public bool Delete(int id)
        {
            bool deleted = false;
            Ad? ad = _context.Ads.FirstOrDefault(a => a.Id == id);
            if (ad == null) return deleted;
            _context.Ads.Remove(ad);
            _context.SaveChanges();
            deleted = true;
            return deleted;
        }
        public void Update(Ad ad)
        {
            var existingAd = _context.Ads.FirstOrDefault(a => a.Id == ad.Id);
            if (existingAd != null)
            {
                existingAd.Title = ad.Title;
                existingAd.ImagePath = ad.ImagePath;
                existingAd.Url = ad.Url;
                _context.Ads.Update(existingAd);
                _context.SaveChanges();
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

        public async Task DeleteAdAsync(int id)
        {
            var ad = await _context.Ads.FindAsync(id);
            if (ad != null)
            {
                _context.Ads.Remove(ad);
                await _context.SaveChangesAsync();
            }
        }
    }
}
