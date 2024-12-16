using GambaNet.Appliaction.Abstraction;
using GambaNet.Domain;

namespace GambaNet.Appliaction
{
    public class GameService : IGameService
    {
        gameDbContext _gameDbContext;
        IFileUploadService _fileUploadService;

        public GameAppService(gameDbContext gameDbContext, IFileUploadService fileUploadService)
        {
            _gameDbContext = gameDbContext;
            _fileUploadService = fileUploadService;
        }

        public IList<Game> Select()
        {
            return _gameDbContext.Games.ToList();
        }

        public void Create(Game game)
        {
            if (game.Image != null)
            {
                string imageSrc = _fileUploadService.FileUpload(game.Image, Path.Combine("img", "games"));
                game.ImageSrc = imageSrc;
            }

            _gameDbContext.Games.Add(game);
            _gameDbContext.SaveChanges();
        }

        public bool Delete(int id)
        {
            bool deleted = false;

            Game? game
                = _gameDbContext.Games.FirstOrDefault(prod => prod.Id == id);

            if (game != null)
            {
                _gameDbContext.Games.Remove(game);
                _gameDbContext.SaveChanges();
                deleted = true;
            }

            return deleted;
        }
    }
}
