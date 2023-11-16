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
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$", ErrorMessage = "Password must have at least 8 characters, including one uppercase letter, one lowercase letter, one digit, and one special character.")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = null!;

    [Display(Name = "Confirm Password")]
    [Required(ErrorMessage = "Confirm Password is required")]
    [Compare("Password", ErrorMessage = "Password and Confirm Password must match.")]
    [DataType(DataType.Password)]
    public string ConfirmPassword { get; set; } = null!;

    public string Token { get; set; } = null!;
}
