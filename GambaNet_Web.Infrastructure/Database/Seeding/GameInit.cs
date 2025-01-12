using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GambaNet_Web.Domain.Entities;

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
                    Name = "Láska Strejdy",
                    Description = "Máš na to ?",
                    Winrate = 100,
                    BackgroundRed = 230,
                    BackgroundGreen = 179,
                    BackgroundBlue = 39,
                },
                new Game
                {
                    Id = 2,
                    Name = "Léto v Čečensku",
                    Description = "Kde to jen bylo",
                    Winrate = 50,
                    BackgroundRed = 39,
                    BackgroundGreen = 80,
                    BackgroundBlue = 230,
                },
                new Game
                {
                    Id = 3,
                    Name = "Igor Hnízdo",
                    Description = "Proč to musel udělat",
                    Winrate = 0,
                    BackgroundRed = 189,
                    BackgroundGreen = 138,
                    BackgroundBlue = 169,
                }
            };

            return games;
        }
    }
}
