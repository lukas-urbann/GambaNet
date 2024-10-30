using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GambaNet.Domain.Entity
{
    public class Game : Entity<int>
    {
        public string Name { get; set; }
        public Decimal MinBet { get; set; }
        public Decimal MaxBet { get; set; }

    }
}
