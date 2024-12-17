using GambaNet.Application.Abstraction;
using GambaNet.Domain.Entity;
using GambaNet.Infrastructure.Database;

namespace GambaNet.Application.Implementation
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
    }
}
