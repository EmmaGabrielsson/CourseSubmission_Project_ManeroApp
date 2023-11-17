using Manero.Models.Entities;
using System.Security.Claims;

namespace Manero.Models.Interfaces
{
    public interface IUserService
    {
        Task<UserEntity> GetUserAsync(ClaimsPrincipal claimsPrincipal);
        Task<string> GetUserIdAsync(UserEntity user);
    }
}
