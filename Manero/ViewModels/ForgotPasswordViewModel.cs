using System.ComponentModel.DataAnnotations;

namespace Manero.ViewModels
{
    public class ForgotPasswordViewModel
    {
        [Display(Name = "E-mail Address")]
        [Required(ErrorMessage = "E-mail is required")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^[^\s@]+@[^\s@]+\.[^\s@]+$", ErrorMessage = "Invalid email format")]
        public string Email { get; set; } = null!;
    }
}