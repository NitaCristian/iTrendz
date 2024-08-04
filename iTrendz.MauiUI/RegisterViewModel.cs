using System.ComponentModel.DataAnnotations;

namespace iTrendz.MauiUI;

public class RegisterViewModel
{
    [Required] public string Username { get; set; }

    [Required] [EmailAddress] public string Email { get; set; }

    [Required] public string Password { get; set; }

    [Required]
    [Compare("Password", ErrorMessage = "Passwords do not match.")]
    public string ConfirmPassword { get; set; }
    [Required]
    public string UserType { get; set; }

    [Required]
    public string Description { get; set; }
}