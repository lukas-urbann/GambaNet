using GambaNet_Web.Application.Abstraction;
using GambaNet_Web.Application.ViewModel;
using GambaNet_Web.Domain.Entities;
using GambaNet_Web.Infrastructure.Database;

namespace GambaNet_Web.Application.Implementation;

public class HomeService : IHomeService
{
    IGameAppService _gameAppService;

    public HomeService(IGameAppService gameAppService)
    {
        _gameAppService = gameAppService;
    }

    public GameViewModel GetIndexViewModel()
    {
        GameViewModel gameViewModel = new GameViewModel();
        gameViewModel.Games = _gameAppService.Select();
        return gameViewModel;
    }
}