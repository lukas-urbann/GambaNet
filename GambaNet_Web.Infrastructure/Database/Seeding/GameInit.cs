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
                    GameType = "Cups",
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
                    GameType = "Slot",
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
                    GameType = "Plinko",
                    Description = "Proč to musel udělat",
                    Winrate = 0,
                    BackgroundRed = 189,
                    BackgroundGreen = 138,
                    BackgroundBlue = 169,
                },
                    new Game
                {
                    Id = 4,
                    Name = "Hvězda Severu",
                    GameType = "Slot",
                    Description = "Vyhraješ, nebo tě potopí?",
                    Winrate = 25,
                    BackgroundRed = 34,
                    BackgroundGreen = 85,
                    BackgroundBlue = 58,
                },
                    new Game
                {
                    Id = 5,
                    Name = "Zimní Vánek",
                    GameType = "Cups",
                    Description = "Cítíš ten chlad?",
                    Winrate = 75,
                    BackgroundRed = 210,
                    BackgroundGreen = 240,
                    BackgroundBlue = 255,
                },
                new Game
                {
                    Id = 6,
                    Name = "Střepy Štěstí",
                    GameType = "Plinko",
                    Description = "Štěstí bolí.",
                    Winrate = 10,
                    BackgroundRed = 160,
                    BackgroundGreen = 20,
                    BackgroundBlue = 40,
                },
                new Game
                {
                    Id = 7,
                    Name = "Rytířská Síla",
                    GameType = "Slot",
                    Description = "Jsi připraven na bitvu?",
                    Winrate = 40,
                    BackgroundRed = 50,
                    BackgroundGreen = 50,
                    BackgroundBlue = 50,
                },
                new Game
                {
                    Id = 8,
                    Name = "Pohár Života",
                    GameType = "Cups",
                    Description = "Co ti přinese osud?",
                    Winrate = 60,
                    BackgroundRed = 255,
                    BackgroundGreen = 215,
                    BackgroundBlue = 0,
                },
                new Game
                {
                    Id = 9,
                    Name = "Rozbité Sny",
                    GameType = "Slot",
                    Description = "Co se mohlo stát jinak?",
                    Winrate = 20,
                    BackgroundRed = 100,
                    BackgroundGreen = 100,
                    BackgroundBlue = 255,
                },
                new Game
                {
                    Id = 10,
                    Name = "Pouštní Bouře",
                    GameType = "Cups",
                    Description = "Zvládneš přežít?",
                    Winrate = 30,
                    BackgroundRed = 210,
                    BackgroundGreen = 180,
                    BackgroundBlue = 140,
                },
                new Game
                {
                    Id = 11,
                    Name = "Horká Čokoláda",
                    GameType = "Plinko",
                    Description = "Zahřeje nebo spálí?",
                    Winrate = 45,
                    BackgroundRed = 139,
                    BackgroundGreen = 69,
                    BackgroundBlue = 19,
                },
                new Game
                {
                    Id = 12,
                    Name = "Ledový Král",
                    GameType = "Plinko",
                    Description = "Zmrazíš soupeře?",
                    Winrate = 55,
                    BackgroundRed = 173,
                    BackgroundGreen = 216,
                    BackgroundBlue = 230,
                },
                new Game
                {
                    Id = 13,
                    Name = "Ztracené Město",
                    GameType = "Slot",
                    Description = "Najdeš poklad?",
                    Winrate = 35,
                    BackgroundRed = 128,
                    BackgroundGreen = 0,
                    BackgroundBlue = 128,
                }
            };

            return games;
        }
    }
}
