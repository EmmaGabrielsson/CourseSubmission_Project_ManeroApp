using Manero.Models.Entities;
using System.Security.Claims;

namespace Manero.Models.Interfaces
{
    public interface IUserManagerProvider
    {
        Task<UserEntity> GetUserAsync(ClaimsPrincipal claimsPrincipal);
        Task<string> GetUserIdAsync(UserEntity user);
    }
}
