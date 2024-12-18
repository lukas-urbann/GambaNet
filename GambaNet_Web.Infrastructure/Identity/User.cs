using GambaNet_Web.Domain.Entity.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace GambaNet.Infrastructure.Identity;

public class User : IdentityUser<int>, IUser<int>
{
    public string? UserName { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public DateTime? StartDate { get; set; }
    public decimal? Balance { get; set; }
}