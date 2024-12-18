using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GambaNet_Web.Domain.Entity.Interfaces;

namespace GambaNet_Web.Domain.Entity
{
    [Table(nameof(Bonus))]
    public class Bonus : Entity<int>
    {
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }

        public string Description { get; set; }
        public Decimal Amount { get; set; }

        public DateTime Expiration { get; set; }

        public IUser<int> User { get; set; }
    }
}
