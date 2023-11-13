using System.ComponentModel.DataAnnotations;

namespace Manero.ViewModels;

public class ResetPasswordViewModel
{
    [Display(Name = "E-mail Address")]
    [Required(ErrorMessage = "E-mail is required")]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; } = null!;

    [Display(Name = "Password")]
    [Required(ErrorMessage = "Password is required")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = null!;

    [Display(Name = "Confirm Password")]
    [Required(ErrorMessage = "Confirm Password is reqired")]
    [Compare("Password", ErrorMessage = "Password and Confirm Passsword must match.")]
    [DataType(DataType.Password)]
    public string ConfirmPassword { get; set; } = null!;

    public string Token { get; set; } = null!;
}
