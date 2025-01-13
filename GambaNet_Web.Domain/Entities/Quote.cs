using GambaNet_Web.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GambaNet.Domain.Entities
{
    [Table(nameof(Quote))]
    public class Quote : Entity<int>
    {
        public string Description { get; set; }
    }
}
