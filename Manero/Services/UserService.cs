using Manero.ViewModels;
using Manero.Models.Entities;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Manero.Models.Interfaces;

namespace Manero.Services;
public class UserService : IUserService
{
	private readonly UserManager<UserEntity> _userManager;
	private readonly IWebHostEnvironment _hostEnvironment;

	public UserService(UserManager<UserEntity> userManager, IWebHostEnvironment hostEnvironment)
	{
		_userManager = userManager;
		_hostEnvironment = hostEnvironment;
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

		// Handle profile image update if a new image is provided
		if (viewModel.ProfileImage != null && viewModel.ProfileImage.Length > 0)
		{
			// Generate a unique file name for the new profile image
			var fileName = Path.GetFileNameWithoutExtension(viewModel.ProfileImage.FileName);
			var extension = Path.GetExtension(viewModel.ProfileImage.FileName);
			var fileNewName = $"{Guid.NewGuid()}_{DateTime.Now:yyyyMMddHHmmss}{fileName}{extension}";

			// Define the file path for the new profile image
			var filePath = Path.Combine(_hostEnvironment.WebRootPath, "images", "profiles", fileNewName).Replace("\\", "/");

			// Check if there's an existing profile image and delete it
			if (!string.IsNullOrWhiteSpace(user.ProfileImageUrl))
			{
				var existingFilePath = _hostEnvironment.WebRootPath + user.ProfileImageUrl;
				if (System.IO.File.Exists(existingFilePath))
				{
					System.IO.File.Delete(existingFilePath);
				}
			}

			// Copy the new profile image to the specified file path
			using (var fileStream = new FileStream(filePath, FileMode.Create))
			{
				await viewModel.ProfileImage.CopyToAsync(fileStream);
			}

			// Update the user's profile image URL
			user.ProfileImageUrl = "/" + Path.Combine("images", "profiles", fileNewName);
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
