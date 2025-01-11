using Microsoft.EntityFrameworkCore;
using GambaNet_Web.Domain.Entities;
using GambaNet_Web.Infrastructure.Database.Seeding;
using GambaNet.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using GambaNet.Domain.Entities;

namespace GambaNet_Web.Infrastructure.Database
{
    public class GambaNetDbContext : IdentityDbContext<User, Role, int>
    {
        public DbSet<TransactionType> TransactionType { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Ad> Ads { get; set; }

        public GambaNetDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            GameInit gameInit = new GameInit();
            modelBuilder.Entity<Game>().HasData(gameInit.GetGames());
            
            TransactionTypeInit transactionTypeInit = new TransactionTypeInit();
            modelBuilder.Entity<TransactionType>().HasData(transactionTypeInit.GetTransactionTypes());
            
            RolesInit rolesInit = new RolesInit();
            modelBuilder.Entity<Role>().HasData(rolesInit.GetRolesAD());

            UserInit userInit = new UserInit();
            User admin = userInit.GetAdmin();
            User def = userInit.GetDefault();

            modelBuilder.Entity<User>().HasData(admin, def);

            UserRolesInit userRolesInit = new UserRolesInit();
            List<IdentityUserRole<int>> adminUserRoles = userRolesInit.GetRolesForAdmin();
            List<IdentityUserRole<int>> managerUserRoles = userRolesInit.GetRolesForDefault();
            modelBuilder.Entity<IdentityUserRole<int>>().HasData(adminUserRoles);
            modelBuilder.Entity<IdentityUserRole<int>>().HasData(managerUserRoles);

            modelBuilder.Entity<Ad>().ToTable("Ads");
        }
    }
}
