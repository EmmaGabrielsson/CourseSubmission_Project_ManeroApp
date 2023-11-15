using System.ComponentModel.DataAnnotations;

namespace Manero.ViewModels
{
    public class LoginViewModel
    {
        [Display(Name = "E-mail Address")]
        [Required(ErrorMessage = "E-mail is required")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid email format")]
        public string Email { get; set; } = null!;

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$", ErrorMessage = "Password must have at least 8 characters, including one uppercase letter, one lowercase letter, one digit, and one special character.")]
        public string Password { get; set; } = null!;

        public bool RememberMe { get; set; }
    }
}
