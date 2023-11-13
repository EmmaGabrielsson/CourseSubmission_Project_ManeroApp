namespace Manero.ViewModels;

public class MyProfileViewModel
{
	public string Id { get; set; } = null!;
	public string FirstName { get; set; } = null!;
	public string LastName { get; set; } = null!;
	public string Email { get; set; } = null!;
	public string? ProfileImageUrl { get; set; }
	public string? PhoneNumber { get; set; }
	public string? Location { get; set; }
}
