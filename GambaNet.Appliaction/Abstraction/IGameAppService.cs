using GambaNet.Domain.Entity;

namespace GambaNet.Appliaction.Abstraction
{
    public interface IGameAppService
    {
        IList<Game> Select();
    }
}
