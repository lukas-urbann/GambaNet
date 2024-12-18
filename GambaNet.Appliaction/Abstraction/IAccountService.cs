using GambaNet_Web.Application.ViewModel;
using GambaNet.Infrastructure.Identity.Enums;

namespace GambaNet_Web.Application.Abstraction;

public interface IAccountService
{
    Task<bool> Login(LoginViewModel vm);
    Task Logout();
    Task<string[]> Register(RegisterViewModel vm, params Roles[] roles);
}