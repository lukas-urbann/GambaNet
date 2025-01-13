using GambaNet.Domain.Entities;

namespace GambaNet.Infrastructure.Database.Seeding
{
    internal class QuoteInit
    {
        public List<Quote> GetQuotes()
        {
            List<Quote> quotes = new List<Quote>
            {
                new Quote
                {
                    Id = 1,
                    Description = "90 % gamblerů přestane hrát těsně před jejich další výhrou, nepřestávej!"
                },
                new Quote
                {
                    Id = 2,
                    Description = "Kdo se nevzdá, vyhraje!"
                },
                new Quote
                {
                    Id = 3,
                    Description = "Nezapomeň, že loseři prohrávájí - ale to ty nejsi, takže to nevzdávej!"
                },
                new Quote
                {
                    Id = 4,
                    Description = "Kdo hraje, ten nezlobí!"
                },
                new Quote
                {
                    Id = 5,
                    Description = "Rozdáváme peníze zdarma!"
                },
                new Quote
                {Id = 6,
                    Description = "Bez gamby nejsou koláče!"
                },
                new Quote
                {Id = 7,
                    Description = "Odvážným štěstí přeje!"
                },
                new Quote
                {Id = 8,
                    Description = "Není to tak moc o tom, co prohraješ - je to o tom co vyhraješ!"
                },
                new Quote
                {Id = 9,
                    Description = "Ty texty co tu vyskakujou nemají s psychologickou manipulací nic společného, to říkají slabí doktoři co nikdy nevyhráli pořádnou sumu!"
                },
                new Quote
                {Id = 10,
                    Description = "Neznám nikoho, kdo by neměl rád peníze zdarma!"
                },
                new Quote
                {Id = 11,
                    Description = "Rozlučte se s živořením!"
                },
            };

            return quotes;
        }
    }
}
