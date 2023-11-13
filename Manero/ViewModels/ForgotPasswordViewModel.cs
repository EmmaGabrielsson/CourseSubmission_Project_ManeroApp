using System.ComponentModel.DataAnnotations;

namespace Manero.ViewModels;

public class ForgotPasswordViewModel
{
    [Display(Name = "E-mail Address")]
    [Required(ErrorMessage = "E-mail is required")]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; } = null!;
}
