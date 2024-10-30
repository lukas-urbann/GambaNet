using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GambaNet.Domain.Entity
{
    public class Stat : Entity<int>
    {
        public Decimal TotalBet { get; set; }
        public Decimal TotalRevenue { get; set; }
        public int WinRate { get; set; }
        [ForeignKey(nameof(Game))]
        public int GameId { get; set; }

        public Game? Game { get; set; }
    }
}
