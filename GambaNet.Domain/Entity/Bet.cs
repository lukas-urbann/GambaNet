using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GambaNet.Domain.Entity.Interfaces;

namespace GambaNet.Domain.Entity
{
    public class Bet : Entity<int>
    {
        [ForeignKey(nameof(Game))]
        public int GameId { get; set; }
        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        [Required]
        public Decimal Amount { get; set; }

        public Boolean IsWin { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime TimeStamp { get; protected set; }

        public IUser<int> User { get; set; }
        public Game? Game { get; set; }
    }
}
