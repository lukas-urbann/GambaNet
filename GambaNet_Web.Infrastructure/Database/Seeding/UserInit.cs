using GambaNet.Infrastructure.Identity;

namespace GambaNet_Web.Infrastructure.Database.Seeding;

internal class UserInit
{
    public User GetAdmin()
    {
        User admin = new User()
        {
            Id = 1,
            UserName = "this_guy",
            Email = "admin@admin.com",
            EmailConfirmed = true,
            Password = "admin",
            Balance = 9999,
            NormalizedUserName = "THIS_GUY",
            NormalizedEmail = "ADMIN@ADMIN.COM",
            StartDate = DateTime.Now,
            ConcurrencyStamp = string.Empty,
            
            LockoutEnabled = true,
            AccessFailedCount = 0,
            LockoutEnd = null,
            PhoneNumber = null,
            PhoneNumberConfirmed = true,
            SecurityStamp = string.Empty,
            PasswordHash = null,
            TwoFactorEnabled = false,
        };
        
        return admin;
    }

    public User GetDefault()
    {
        User @default = new User()
        {
            Id = 2,
            UserName = "that_guy",
            Email = "def@def.com",
            EmailConfirmed = true,
            Password = "default",
            Balance = 100,
            NormalizedUserName = "THAT_GUY",
            NormalizedEmail = "DEF@DEF.COM",
            StartDate = DateTime.Now,
            ConcurrencyStamp = string.Empty,
            
            LockoutEnabled = true,
            AccessFailedCount = 0,
            LockoutEnd = null,
            PhoneNumber = null,
            PhoneNumberConfirmed = true,
            SecurityStamp = string.Empty,
            PasswordHash = null,
            TwoFactorEnabled = false,
        };

        return @default;
    }
}