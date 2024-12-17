using GambaNet.Domain.Entity;
using GambaNet.Application.Abstraction;
using Microsoft.AspNetCore.Mvc;

namespace GambaNet_Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class GamesController : Controller
    {
        IGameAppService _gameAppService;

        public GamesController(IGameAppService gameAppService)
        {
            _gameAppService = gameAppService;
        }

        public IActionResult Select()
        {
            IList<Game> games = _gameAppService.Select();
            return View(games);
        }
    }
}
