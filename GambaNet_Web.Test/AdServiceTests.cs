using GambaNet_Web.Application.Implementation;
using GambaNet_Web.Domain.Entities;
using GambaNet_Web.Infrastructure.Database;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using System.Threading;
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
        public async Task AddAdAsync_ShouldAddAd()
        {
            // Arrange
            using var context = CreateContext();
            var adService = new AdService(context, _mockEnvironment.Object, _mockLogger.Object);
            var ad = new Ad { Id = 1, Title = "New Ad", ImagePath = "/ads/new.jpg" };

            // Act
            await adService.AddAdAsync(ad);

            // Assert
            var addedAd = await context.Ads.FindAsync(1);
            Assert.NotNull(addedAd);
            Assert.Equal("New Ad", addedAd.Title);
        }

        [Fact]
        public async Task UpdateAdAsync_ShouldUpdateAd()
        {
            // Arrange
            using var context = CreateContext();
            var adService = new AdService(context, _mockEnvironment.Object, _mockLogger.Object);
            var ad = new Ad { Id = 1, Title = "Old Ad", ImagePath = "/ads/old.jpg" };
            context.Ads.Add(ad);
            await context.SaveChangesAsync();

            ad.Title = "Updated Ad";

            // Act
            await adService.UpdateAdAsync(ad);

            // Assert
            var updatedAd = await context.Ads.FindAsync(1);
            Assert.NotNull(updatedAd);
            Assert.Equal("Updated Ad", updatedAd.Title);
        }
    }
}