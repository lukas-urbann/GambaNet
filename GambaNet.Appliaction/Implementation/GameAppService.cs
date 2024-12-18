using GambaNet_Web.Application.Abstraction;
using GambaNet_Web.Domain.Entity;
using GambaNet_Web.Infrastructure.Database;

namespace GambaNet_Web.Application.Implementation
{
    public class GameAppService : IGameAppService
    {
        GambaNetDbContext _gambaNetDbContext;

        public GameAppService(GambaNetDbContext DbContext)
        {
            _gambaNetDbContext = DbContext;
        }

        public IList<Game> Select()
        {
            return _gambaNetDbContext.Games.ToList();
        }
        
        public void Create(Game game)
        {
            _gambaNetDbContext.Games.Add(game);
            _gambaNetDbContext.SaveChanges();
        }

        public bool Delete(int id)
        {
            bool deleted = false;
            Game? product = _gambaNetDbContext.Games.FirstOrDefault(prod => prod.Id == id);

            if (product == null) return deleted;
            
            _gambaNetDbContext.Games.Remove(product);
            _gambaNetDbContext.SaveChanges();
            deleted = true;

            return deleted;
        }
    }
}
