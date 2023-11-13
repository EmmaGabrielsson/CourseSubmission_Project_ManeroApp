using System.ComponentModel.DataAnnotations;

namespace Manero.ViewModels;

public class LoginViewModel
{
    [Display(Name = "E-mail Address")]
    [Required(ErrorMessage = "E-mail is required")]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; } = null!;

    [Display(Name = "Password")]
    [Required(ErrorMessage = "Password is required")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = null!;

    public bool RememberMe { get; set; }
}
