using GambaNet_Web.Application.ViewModel;

namespace GambaNet_Web.Application.Abstraction;

public interface IHomeService
{
    GameViewModel GetIndexViewModel();
}