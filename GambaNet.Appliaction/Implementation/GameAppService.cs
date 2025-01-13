using GambaNet_Web.Application.Abstraction;
using GambaNet_Web.Domain.Entities;
using GambaNet_Web.Infrastructure.Database;

namespace GambaNet_Web.Application.Implementation
{
    public class GameAppService : IGameAppService
    {
        private readonly GambaNetDbContext _gambaNetDbContext;
        private readonly IThumbnailUploadService _thumbnailUploadService;

        public GameAppService(GambaNetDbContext dbContext, IThumbnailUploadService thumbnailUploadService)
        {
            _gambaNetDbContext = dbContext;
            _thumbnailUploadService = thumbnailUploadService;
        }

        public IList<Game> Select()
        {
            return _gambaNetDbContext.Games.ToList();
        }

        public void Create(Game game)
        {
            if (game.Image != null)
            {
                string imagePath = _thumbnailUploadService.FileUpload(game.Image, Path.Combine("thumbnail", "games"));
                game.ImagePath = imagePath;
                game.Image = null;
            }
            _gambaNetDbContext.Games.Add(game);
            _gambaNetDbContext.SaveChanges();
        }

        public bool Delete(int id)
        {
            bool deleted = false;
            Game? game = _gambaNetDbContext.Games.FirstOrDefault(g => g.Id == id);

            if (game == null) return deleted;

            _gambaNetDbContext.Games.Remove(game);
            _gambaNetDbContext.SaveChanges();
            deleted = true;

            return deleted;
        }

        public void Update(Game game)
        {
            var existingGame = _gambaNetDbContext.Games.FirstOrDefault(g => g.Id == game.Id);
            if (existingGame != null)
            {
                existingGame.Name = game.Name;
                existingGame.GameType = game.GameType;
                existingGame.Description = game.Description;
                existingGame.Winrate = game.Winrate;
                existingGame.BackgroundRed = game.BackgroundRed;
                existingGame.BackgroundGreen = game.BackgroundGreen;
                existingGame.BackgroundBlue = game.BackgroundBlue;

                if (game.Image != null)
                {
                    string imagePath = _thumbnailUploadService.FileUpload(game.Image, Path.Combine("thumbnail", "games"));
                    existingGame.ImagePath = imagePath;
                    game.Image = null;
                }

                _gambaNetDbContext.Games.Update(existingGame);
                _gambaNetDbContext.SaveChanges();
            }
        }
    }
}
