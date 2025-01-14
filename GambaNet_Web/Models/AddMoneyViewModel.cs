using System.ComponentModel.DataAnnotations;

namespace GambaNet_Web.Models
{
    public class AddMoneyViewModel
    {
        [Required]
        [Range(1, 1000, ErrorMessage = "Dobíjení je v rozmezí 1 až 1000 Kč.")]
        public decimal Amount { get; set; }

        [Required]
        public string gRecaptchaResponse { get; set; }
    }
}
