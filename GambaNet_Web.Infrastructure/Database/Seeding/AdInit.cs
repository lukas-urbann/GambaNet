using GambaNet_Web.Domain.Entities;
using GambaNet_Web.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace GambaNet.Infrastructure.Database.Seeding
{
    public class AdInit
    {
        public static async Task SeedAsync(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<GambaNetDbContext>();

            if (await context.Ads.AnyAsync())
            {
                return;
            }

            var ads = new List<Ad>
            {
                new Ad
                {
                    Title = "Casiino",
                    ImagePath = "/images/ad1.png",
                    Url = "https://www.youtube.com/watch?v=dQw4w9WgXcQ"
                },
                new Ad
                {
                    Title = "Casiino head",
                    ImagePath = "/images/ad2.png",
                    Url = "https://www.youtube.com/watch?v=dQw4w9WgXcQ"
                },
                new Ad
                {
                    Title = "Cassino Looms",
                    ImagePath = "/images/ad3.png",
                    Url = "https://www.youtube.com/watch?v=dQw4w9WgXcQ"
                }
            };

            context.Ads.AddRange(ads);
            await context.SaveChangesAsync();
        }
    }
}
