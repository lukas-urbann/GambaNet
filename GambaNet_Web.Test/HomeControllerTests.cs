using GambaNet_Web.Application.Abstraction;
using GambaNet_Web.Application.Implementation;
using GambaNet_Web.Application.ViewModel;
using GambaNet_Web.Domain.Entities;
using Moq;

namespace GambeNet_Test;

public class HomeControllerTests
{
    [Fact]
    public void GetIndexViewModel_ReturnsGameViewModelWithGames()
    {
        // Arrange
        var gameAppService = new Mock<IGameAppService>();
        gameAppService.Setup(x => x.Select()).Returns(new List<Game>
        {
            new Game { Id = 1, Name = "Game 1" },
            new Game { Id = 2, Name = "Game 2" }
        });
        var homeService = new HomeService(gameAppService.Object);
        // Act
        GameViewModel gameViewModel = homeService.GetIndexViewModel();
        // Assert
        Assert.Equal(2, gameViewModel.Games.Count);
    }
}