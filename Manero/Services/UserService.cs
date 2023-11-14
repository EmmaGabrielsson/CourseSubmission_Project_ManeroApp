using Manero.Models.Entities;
using Manero.Models.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Manero.Services;

public class UserService : IUserManagerProvider
{
    private readonly UserManager<UserEntity> _userManager;

    public UserService(UserManager<UserEntity> userManager)
    {
        _userManager = userManager;
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
}
