using System.ComponentModel.DataAnnotations;

namespace Manero.ViewModels
{
    public class ForgotPasswordViewModel
    {
        [Display(Name = "E-mail Address")]
        [Required(ErrorMessage = "E-mail is required")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid email format")]
        public string Email { get; set; } = null!;
    }
}