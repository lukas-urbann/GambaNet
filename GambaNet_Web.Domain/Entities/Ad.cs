using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GambaNet_Web.Domain.Entities;

namespace GambaNet_Web.Domain.Entities
{
    [Table("Ads")]
    public class Ad : Entity<int>
    {
        [Required(ErrorMessage = "Název je vyžadován")]
        [StringLength(100, ErrorMessage = "Max 100 znaků")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Cesta je vyžadována")]
        public string ImagePath { get; set; }

        [Url(ErrorMessage = "Zadejte vylidní URL")]
        public string? Url { get; set; }
    }
}
