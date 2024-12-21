using Microsoft.AspNetCore.Identity;
using GambaNet_Web.Domain.Entities.Interfaces;

namespace GambaNet.Infrastructure.Identity
{
    public class User : IdentityUser<int>, IUser<int>
    {
        public virtual string? FirstName { get; set; }
        public virtual string? LastName { get; set; }
        
        public DateTime? StartDate { get; set; }
        public virtual Decimal? Balance { get; set; }
    }
}