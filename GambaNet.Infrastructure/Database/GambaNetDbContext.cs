using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GambaNet.Domain.Entity;
using GambaNet.Infrastructure.Database.Seeding;

namespace GambaNet.Infrastructure.Database
{
    public class GambaNetDbContext : DbContext
    {
        public DbSet<TransactionType> TransactionType { get; set; }
        public DbSet<Game> Game { get; set; }


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
