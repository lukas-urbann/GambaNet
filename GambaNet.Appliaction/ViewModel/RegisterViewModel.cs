using System.ComponentModel.DataAnnotations;

namespace GambaNet_Web.Application.ViewModel;

public class RegisterViewModel
{
    [Required]
    public string? Username { get; set; }
    [Required]
    [EmailAddress]
    public string? Email { get; set; }
    [Phone]
    public string? Phone { get; set; }
    [Required]
    public string? Password { get; set; }
    [Required]
    [Compare(nameof(Password), ErrorMessage = "Passwords don't match!")]
    public string? RepeatedPassword { get; set; }
}