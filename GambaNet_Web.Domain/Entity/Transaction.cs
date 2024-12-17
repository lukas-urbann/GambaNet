using GambaNet.Domain.Entity.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GambaNet.Domain.Entity
{
    //bylo by dobré mít nějaký hlavní účet kterýmu se budou posílat
    //prohraný peníze z gamby
    [Table(nameof(Transaction))]
    public class Transaction : Entity<int>
    {
        [Required]
        public Decimal Amount { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime TimeStamp { get; set; }
        [ForeignKey(nameof(TransactionType))]
        public int TransactionTypeId { get; set; }
        [ForeignKey(nameof(User))]
        public int UserId { get; set; }

        public TransactionType? TransactionType { get; set; }
        public IUser<int> User { get; set; }
    }
}
