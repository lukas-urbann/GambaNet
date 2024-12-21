using Microsoft.AspNetCore.Identity;

namespace GambaNet_Web.Infrastructure.Database.Seeding
{
    internal class UserRolesInit
    {
        public List<IdentityUserRole<int>> GetRolesForAdmin()
        {
            List<IdentityUserRole<int>> adminUserRoles = new List<IdentityUserRole<int>>()
            {
                new IdentityUserRole<int>()
                {
                    UserId = 1,
                    RoleId = 1
                },
                new IdentityUserRole<int>()
                {
                    UserId = 1,
                    RoleId = 2
                },
            };
            
            return adminUserRoles;
        }
        
        public List<IdentityUserRole<int>> GetRolesForDefault()
        {
            List<IdentityUserRole<int>> defaultUserRoles = new List<IdentityUserRole<int>>()
            {
                new IdentityUserRole<int>()
                {
                    UserId = 2,
                    RoleId = 2
                },
            };
            
            return defaultUserRoles;
        }
    }
}