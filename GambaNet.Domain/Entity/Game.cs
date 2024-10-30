using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GambaNet.Domain.Entity
{
    [Table(nameof(Game))]
    public class Game : Entity<int>
    {
        public string Name { get; set; }
        public Decimal MinBet { get; set; }
        public Decimal MaxBet { get; set; }

    }
}
