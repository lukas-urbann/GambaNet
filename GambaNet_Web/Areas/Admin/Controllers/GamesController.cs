using GambaNet.Domain.Entity;
using GambaNet_Web.Application.Abstraction;
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
        
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Create(Game game)
        {
            _gameAppService.Create(game);
            return RedirectToAction(nameof(GamesController.Select));
        }
        
        public IActionResult Delete(int id)
        {
            bool deleted = _gameAppService.Delete(id);
            if (deleted)
            {
                return RedirectToAction(nameof(GamesController.Select));
            }
            else
            {
                return NotFound();
            }
        }
    }
}
