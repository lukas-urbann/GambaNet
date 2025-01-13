using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public string GameType { get; set; }
        public string Description { get; set; }
        [Range(0, 100, ErrorMessage = "Winrate musí být 0 až 100.")]
        public int Winrate { get; set; }

        [Range(0, 255, ErrorMessage = "R 0-255.")]
        public int BackgroundRed { get; set; }

        [Range(0, 255, ErrorMessage = "G 0-255.")]
        public int BackgroundGreen { get; set; }

        [Range(0, 255, ErrorMessage = "B 0-255.")]
        public int BackgroundBlue { get; set; }

        public string? ImagePath { get; set; }
        [NotMapped]
        public IFormFile? Image { get; set; }
    }
}
