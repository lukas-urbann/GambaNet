using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GambaNet.Domain.Validations;

namespace GambaNet_Web.Domain.Entity
{
    [Table(nameof(Game))]
    public class Game : Entity<int>
    {
        [Capitalize]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
