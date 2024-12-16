using GambaNet.Domain.Entity.Interfaces;
using Microsoft.AspNetCore.Identity;
using GambaNet.Domain.Entity.Interfaces;
namespace GambaNet.Infrastructure.Identity
{
    /// <summary>
    /// Our User class which can be modified
    /// </summary>
    public class User : IdentityUser<int>, IUser<int>
    {
        public virtual string? FirstName { get; set; }
        public virtual string? LastName { get; set; }
    }
}