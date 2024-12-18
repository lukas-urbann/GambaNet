using System.ComponentModel.DataAnnotations;

namespace GambaNet_Web.Application.ViewModel;

public class LoginViewModel
{
    [Required]
    public string? Username { get; set; }
    [Required]
    public string? Password { get; set; }
    public bool LoginFailed { get; set; }
}