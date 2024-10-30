using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GambaNet.Domain.Entity
{
    public class TransactionType : Entity<int>
    {
        public string TransactionDescription { get; set; }
    }
}
