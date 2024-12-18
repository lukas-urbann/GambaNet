using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GambaNet_Web.Domain.Entity;
using GambaNet_Web.Infrastructure.Database.Seeding;
using GambaNet.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace GambaNet_Web.Infrastructure.Database
{
    public class GambaNetDbContext : IdentityDbContext<User, Role, int>
    {
        public DbSet<TransactionType> TransactionType { get; set; }
        public DbSet<Game> Games { get; set; }

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
        }
    }
}
