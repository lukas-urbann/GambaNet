using GambaNet.Infrastructure.Identity;

namespace GambaNet_Web.Infrastructure.Database.Seeding;

internal class RolesInit
{
    public List<Role> GetRolesAD()
    {
        List<Role> roles = new List<Role>();

        Role roleAdmin = new Role()
        {
            Id = 1,
            Name = "Admin",
            NormalizedName = "ADMIN",
            ConcurrencyStamp = Guid.Empty.ToString()
        };

        Role roleDefault = new Role()
        {
            Id = 2,
            Name = "Default",
            NormalizedName = "DEFAULT",
            ConcurrencyStamp = Guid.Empty.ToString()
        };
        
        roles.Add(roleAdmin);
        roles.Add(roleDefault);
        
        return roles;
    }
}