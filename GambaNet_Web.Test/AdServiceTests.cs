using GambaNet_Web.Application.Implementation;
using GambaNet_Web.Domain.Entities;
using GambaNet_Web.Infrastructure.Database;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace GambaNet_Web.Test
{
    public class AdServiceTests
    {
        private readonly DbContextOptions<GambaNetDbContext> _options;
        private readonly Mock<IWebHostEnvironment> _mockEnvironment;
        private readonly Mock<ILogger<AdService>> _mockLogger;

        public AdServiceTests()
        {
            _options = new DbContextOptionsBuilder<GambaNetDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;
            _mockEnvironment = new Mock<IWebHostEnvironment>();
            _mockLogger = new Mock<ILogger<AdService>>();
        }

        private GambaNetDbContext CreateContext()
        {
            var context = new GambaNetDbContext(_options);
            context.Database.EnsureDeleted(); // Ensure the database is cleared before each test
            context.Database.EnsureCreated();
            return context;
        }

        [Fact]
        public async Task DeleteAdAsync_ShouldRemoveAd()
        {
            // Arrange
            using var context = CreateContext();
            var adService = new AdService(context, _mockEnvironment.Object, _mockLogger.Object);
            var ad = new Ad { Id = 1, Title = "Test Ad", ImagePath = "/ads/test.jpg" };
            context.Ads.Add(ad);
            await context.SaveChangesAsync();

            // Act
            await adService.DeleteAdAsync(1);

            // Assert
            var deletedAd = await context.Ads.FindAsync(1);
            Assert.Null(deletedAd);
        }

        [Fact]
        public void Create_ShouldAddAd()
        {
            // Arrange
            using var context = CreateContext();
            var adService = new AdService(context, _mockEnvironment.Object, _mockLogger.Object);
            var ad = new Ad { Id = 1, Title = "New Ad", ImagePath = "/ads/new.jpg" };

            // Act
            adService.Create(ad);

            // Assert
            var addedAd = context.Ads.Find(1);
            Assert.NotNull(addedAd);
            Assert.Equal("New Ad", addedAd.Title);
        }

        [Fact]
        public void Delete_ShouldRemoveAd()
        {
            // Arrange
            using var context = CreateContext();
            var adService = new AdService(context, _mockEnvironment.Object, _mockLogger.Object);
            var ad = new Ad { Id = 1, Title = "Test Ad", ImagePath = "/ads/test.jpg" };
            context.Ads.Add(ad);
            context.SaveChanges();

            // Act
            var result = adService.Delete(1);

            // Assert
            var deletedAd = context.Ads.Find(1);
            Assert.True(result);
            Assert.Null(deletedAd);
        }

        [Fact]
        public void Update_ShouldUpdateAd()
        {
            // Arrange
            using var context = CreateContext();
            var adService = new AdService(context, _mockEnvironment.Object, _mockLogger.Object);
            var ad = new Ad { Id = 1, Title = "Old Ad", ImagePath = "/ads/old.jpg" };
            context.Ads.Add(ad);
            context.SaveChanges();

            ad.Title = "Updated Ad";

            // Act
            adService.Update(ad);

            // Assert
            var updatedAd = context.Ads.Find(1);
            Assert.NotNull(updatedAd);
            Assert.Equal("Updated Ad", updatedAd.Title);
        }

        [Fact]
        public async Task GetRandomAdAsync_ShouldReturnAd()
        {
            // Arrange
            using var context = CreateContext();
            var adService = new AdService(context, _mockEnvironment.Object, _mockLogger.Object);
            var ad1 = new Ad { Id = 1, Title = "Ad 1", ImagePath = "/ads/ad1.jpg" };
            var ad2 = new Ad { Id = 2, Title = "Ad 2", ImagePath = "/ads/ad2.jpg" };
            context.Ads.AddRange(ad1, ad2);
            await context.SaveChangesAsync();

            // Act
            var randomAd = await adService.GetRandomAdAsync();

            // Assert
            Assert.NotNull(randomAd);
            Assert.Contains(randomAd.Title, new[] { "Ad 1", "Ad 2" });
        }
    }
}
