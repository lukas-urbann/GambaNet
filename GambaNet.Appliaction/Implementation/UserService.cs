using GambaNet.Infrastructure.Identity;
using GambaNet_Web.Application.Abstraction;
using GambaNet_Web.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GambaNet_Web.Application.Implementation
{
    public class UserService : IUserService
    {
        private readonly GambaNetDbContext _context;

        public UserService(GambaNetDbContext context)
        {
            _context = context;
        }

        public IList<User> GetTopUsersByBalance(int pageNumber, int pageSize, out int totalUsers)
        {
            totalUsers = _context.Users.Count();
            return _context.Users
                .OrderByDescending(u => u.Balance)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }
    }
}
