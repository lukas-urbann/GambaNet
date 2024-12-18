using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GambaNet_Web.Domain.Entity;

namespace GambaNet_Web.Infrastructure.Database.Seeding
{
    internal class GameInit
    {
        public List<Game> GetGames()
        {
            List<Game> games = new List<Game>
            {
                new Game
                {
                    Id = 1,
                    Name = "Slots",
                    Description = "Slots machine description",
                },
                new Game
                {
                    Id = 2,
                    Name = "Cups",
                    Description = "Cups description",
                },
                new Game
                {
                    Id = 3,
                    Name = "Plinko",
                    Description = "Plinko description",
                }
            };

            return games;
        }
    }
}
