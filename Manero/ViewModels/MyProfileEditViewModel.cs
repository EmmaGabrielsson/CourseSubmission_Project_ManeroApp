using System.ComponentModel.DataAnnotations;

namespace Manero.ViewModels;

public class MyProfileEditViewModel
{

	[Display(Name = "Profile Image")]
	public IFormFile? ProfileImage { get; set; }

	[Required]
	[Display(Name = "Name")]
	public string? Name { get; set; }

	[Required]
	[EmailAddress]
	[Display(Name = "Email")]
	public string? Email { get; set; }

	[Required]
	[Phone]
	[Display(Name = "Phone Number")]
	public string? PhoneNumber { get; set; }

	[Display(Name = "Location")]
	public string? Location { get; set; }

}
