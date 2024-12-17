using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GambaNet.Domain.Entity;

namespace GambaNet.Infrastructure.Database.Seeding
{
    internal class TransactionTypeInit
    {
        public List<TransactionType> GetTransactionTypes()
        {
            List<TransactionType> transactionTypes = new List<TransactionType>
            {
                new TransactionType
                {
                    Id = 1,
                    TransactionDescription = "Deposit"
                },
                new TransactionType
                {
                    Id = 2,
                    TransactionDescription = "Withdraw"
                },
                new TransactionType
                {
                    Id = 3,
                    TransactionDescription = "GameTransfer"
                }
            };

            return transactionTypes;
        }
    }
}
