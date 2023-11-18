using Manero.Models.Interfaces;
using Manero.ViewModels;
using Manero.Models.Entities;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Manero.Services;

public class UserService : IUserService
{
	private readonly UserManager<UserEntity> _userManager;
	private readonly IWebHostEnvironment _hostEnvironment;
    private readonly IFileService _fileService;

    public UserService(UserManager<UserEntity> userManager, IWebHostEnvironment hostEnvironment, IFileService fileService)
    {
        _userManager = userManager;
        _hostEnvironment = hostEnvironment;
        _fileService = fileService;
    }
    public async Task<UserEntity> GetUserAsync(ClaimsPrincipal claimsPrincipal)
  {
      // Implement the logic to get the user from claimsPrincipal using _userManager
      if (_userManager == null)
      {
          throw new InvalidOperationException("User manager is not initialized/No user Found");
      }
      var user = await _userManager.GetUserAsync(claimsPrincipal)!;
      return user!;
  }

  public Task<string> GetUserIdAsync(UserEntity user)
  {
      // Implement the logic to get the user ID from the user using _userManager
      return _userManager.GetUserIdAsync(user);
  }
	public async Task<bool> UpdateUserProfile(MyProfileEditViewModel viewModel, ClaimsPrincipal userClaimsPrincipal)
	{
		// Retrieve the user based on the ClaimsPrincipal
		var user = await _userManager.GetUserAsync(userClaimsPrincipal);
		//var result = await _userManager.UpdateAsync(user);

		// Check if the user is not found
		if (user == null)
		{
			return false; // Return false to indicate failure
		}
        if (viewModel.ProfileImage != null && viewModel.ProfileImage.Length > 0)
        {
            // Attempt to save the new image and retrieve its path
            var newImageUrl = await _fileService.SaveFileAsync(viewModel.ProfileImage, "images/profiles");

            // Check if the new image has been successfully saved
            if (!string.IsNullOrWhiteSpace(newImageUrl))
            {
                // If there is an old image, delete it
                if (!string.IsNullOrWhiteSpace(user.ProfileImageUrl))
                {
                    var existingFilePath = _hostEnvironment.WebRootPath + user.ProfileImageUrl;
                    _fileService.DeleteFile(existingFilePath);
                }

                // Update the user's profile image URL
                user.ProfileImageUrl = newImageUrl;
            }
        }

        // Split the full name into first name and last name
        var names = viewModel.Name?.Split(new[] { ' ' }, 2);
		if (names?.Length == 2)
		{
			user.FirstName = names[0];
			user.LastName = names[1];
		}

		// Update the user's email if provided
		if (!string.IsNullOrWhiteSpace(viewModel.Email))
		{
			user.Email = viewModel.Email;
		}

		// Update the user's phone number if provided
		if (!string.IsNullOrWhiteSpace(viewModel.PhoneNumber))
		{
			user.PhoneNumber = viewModel.PhoneNumber;
		}

		// Update the user's location if provided
		if (!string.IsNullOrWhiteSpace(viewModel.Location))
		{
			user.Location = viewModel.Location;
		}

		// Update the user's information in the database
		var result = await _userManager.UpdateAsync(user);

		// Return true if the update was successful, otherwise return false
		return result.Succeeded;
	}

}
