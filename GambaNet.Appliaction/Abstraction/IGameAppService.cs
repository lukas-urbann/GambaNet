using GambaNet.Domain.Entity;

namespace GambaNet.Application.Abstraction
{
    public interface IGameAppService
    {
        IList<Game> Select();
        void Create(Game game);
        bool Delete(int id);
    }
}
