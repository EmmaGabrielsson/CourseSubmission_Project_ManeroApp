using Manero.Models.Entities;
using Manero.ViewModels;
using System.Security.Claims;

namespace Manero.Models.Interfaces;

public interface IUserService
{
    Task<bool> UpdateUserProfile(MyProfileEditViewModel viewModel, ClaimsPrincipal userClaimsPrincipa);
    Task<UserEntity> GetUserAsync(ClaimsPrincipal claimsPrincipal);
    Task<string> GetUserIdAsync(UserEntity user);
}
