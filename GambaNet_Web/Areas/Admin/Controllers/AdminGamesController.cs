using GambaNet_Web.Domain.Entities;
using GambaNet_Web.Application.Abstraction;
using GambaNet.Infrastructure.Identity.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GambaNet_Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = nameof(Roles.Admin))]
    public class AdminGamesController : Controller
    {
        IGameAppService _gameAppService;

        public AdminGamesController(IGameAppService gameAppService)
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
            if (ModelState.IsValid)
            {
                _gameAppService.Create(game);
                return RedirectToAction(nameof(AdminGamesController.Select));
            }

            return View(game);
        }
        
        public IActionResult Delete(int id)
        {
            bool deleted = _gameAppService.Delete(id);
            if (deleted)
            {
                return RedirectToAction(nameof(AdminGamesController.Select));
            }
            else
            {
                return NotFound();
            }
        }
        public IActionResult Edit(int id)
        {
            var game = _gameAppService.Select().FirstOrDefault(g => g.Id == id);
            if (game == null)
            {
                return NotFound();
            }
            return View(game);
        }

        [HttpPost]
        public IActionResult Edit(Game game)
        {
            if (ModelState.IsValid)
            {
                _gameAppService.Update(game);
                return RedirectToAction(nameof(Select));
            }
            return View(game);
        }

    }
}
