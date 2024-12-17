using GambaNet.Domain.Entity;

namespace GambaNet_Web.Application.Abstraction
{
    public interface IGameAppService
    {
        IList<Game> Select();
        void Create(Game game);
        bool Delete(int id);
    }
}
