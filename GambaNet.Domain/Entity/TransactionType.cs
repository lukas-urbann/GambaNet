using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GambaNet.Domain.Entity
{
    [Table(nameof(TransactionType))]
    public class TransactionType : Entity<int>
    {
        public string TransactionDescription { get; set; }
    }
}
