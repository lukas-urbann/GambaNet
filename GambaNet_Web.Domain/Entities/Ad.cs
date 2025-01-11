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
        [Required]
        public string Title { get; set; }

        [Required]
        public string ImagePath { get; set; }


        public string? Url { get; set; }
    }
}
