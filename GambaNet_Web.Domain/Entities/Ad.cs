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
        [Required(ErrorMessage = "Title is required")]
        [StringLength(100, ErrorMessage = "Title cannot be longer than 100 characters")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Image path is required")]
        public string ImagePath { get; set; }

        [Url(ErrorMessage = "Please enter a valid URL")]
        public string? Url { get; set; }
    }
}
