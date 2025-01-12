using GambaNet.Infrastructure.Identity;
using GambaNet_Web.Application.Abstraction;
using GambaNet_Web.Infrastructure.Database;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GambaNet_Web.Application.Implementation
{
    public class BalanceService : IBalanceService
    {
        private readonly UserManager<User> _userManager;
        private readonly GambaNetDbContext _context;

        public BalanceService(UserManager<User> userManager, GambaNetDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public async Task<decimal?> GetBalanceAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            return user?.Balance;
        }

        public async Task<bool> SetBalanceAsync(string userId, decimal amount)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null) return false;

            user.Balance = amount;
            var result = await _userManager.UpdateAsync(user);
            return result.Succeeded;
        }

        public async Task<bool> AddBalanceAsync(string userId, decimal amount)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null) return false;
            user.Balance += amount;
            var result = await _userManager.UpdateAsync(user);
            return result.Succeeded;
        }

        public async Task<bool> DeductBalanceAsync(string userId, decimal amount)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null) return false;
            user.Balance -= amount;
            var result = await _userManager.UpdateAsync(user);
            return result.Succeeded;
        }
    }
}
