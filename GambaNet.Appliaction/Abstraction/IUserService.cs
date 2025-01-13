using GambaNet.Infrastructure.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GambaNet_Web.Application.Abstraction
{
    public interface IUserService
    {
        IList<User> GetTopUsersByBalance(int pageNumber, int pageSize, out int totalUsers);
    }
}
