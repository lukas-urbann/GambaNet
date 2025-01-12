using System.ComponentModel.DataAnnotations;

namespace GambaNet_Web.Models
{
    public class AddMoneyViewModel
    {
        [Required]
        [Range(1, 1000, ErrorMessage = "Amount must be between 1 and 1000.")]
        public decimal Amount { get; set; }

        public string CaptchaResponse { get; set; }
    }
}
