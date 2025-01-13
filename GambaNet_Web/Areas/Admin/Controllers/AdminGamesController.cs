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
        private readonly IGameAppService _gameAppService;
        private readonly IThumbnailUploadService _thumbnailUploadService;

        public AdminGamesController(IGameAppService gameAppService, IThumbnailUploadService thumbnailUploadService)
        {
            _gameAppService = gameAppService;
            _thumbnailUploadService = thumbnailUploadService;
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
                if (game.Image != null)
                {
                    if (!ValidateImageFile(game.Image, out string errorMessage))
                    {
                        ModelState.AddModelError("Image", errorMessage);
                        return View(game);
                    }

                    string imagePath = _thumbnailUploadService.FileUpload(game.Image, Path.Combine("thumbnail", "games"));
                    game.ImagePath = imagePath;
                    game.Image = null;
                }
                _gameAppService.Create(game);
                return RedirectToAction(nameof(Select));
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
                if (game.Image != null)
                {
                    if (!ValidateImageFile(game.Image, out string errorMessage))
                    {
                        ModelState.AddModelError("Image", errorMessage);
                        return View(game);
                    }

                    string imagePath = _thumbnailUploadService.FileUpload(game.Image, Path.Combine("thumbnail", "games"));
                    game.ImagePath = imagePath;
                    game.Image = null;
                }
                _gameAppService.Update(game);
                return RedirectToAction(nameof(Select));
            }
            return View(game);
        }


        private bool ValidateImageFile(IFormFile file, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (file.Length > 5 * 1024 * 1024)
            {
                errorMessage = "Soubor je moc veliký.";
                return false;
            }

            var allowedFileTypes = new[] { "image/jpeg", "image/png", "image/gif" };
            if (!allowedFileTypes.Contains(file.ContentType))
            {
                errorMessage = "Jenom JPEG, PNG a GIF.";
                return false;
            }

            return true;
        }
    }


}
