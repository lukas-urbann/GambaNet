using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GambaNet.Domain.Entity.Interfaces
{
    public interface IUser<TKey> : IEntity<TKey>
    {
        string? UserName { get; set; }
        string? Email { get; set; }
        string? Password { get; set; }
        DateTime? StartDate { get; set; }
        Decimal? Balance { get; set; }
    }
}
