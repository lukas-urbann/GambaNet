using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GambaNet_Web.Application.Abstraction
{
    public interface IBalanceService
    {
        Task<decimal?> GetBalanceAsync(string userId);
        Task<bool> SetBalanceAsync(string userId, decimal amount);

        Task<bool> AddBalanceAsync(string userId, decimal amount);
        Task<bool> DeductBalanceAsync(string userId, decimal amount);
    }
}
