using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GambaNet.Domain.Validations;
using Microsoft.AspNetCore.Http;

namespace GambaNet_Web.Domain.Entities
{
    [Table(nameof(Game))]
    public class Game : Entity<int>
    {
        
        [Capitalize]
        public string Name { get; set; }
        public string Description { get; set; }

        public string? ImagePath { get; set; }
        [NotMapped]
        public IFormFile? Image { get; set; }
    }
}
