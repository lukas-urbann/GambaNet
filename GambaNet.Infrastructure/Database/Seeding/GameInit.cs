using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GambaNet.Domain.Entity;

namespace GambaNet.Infrastructure.Database.Seeding
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
                    Name = "Casiino",
                    MinBet = 10,
                    MaxBet = 1000
                },
                new Game
                {
                    Id = 2,
                    Name = "Cassino roon",
                    MinBet = 10,
                    MaxBet = 1000
                }
            };

            return games;
        }
    }
}
