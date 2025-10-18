using IdentityTemplate.Shared.DTOs.Auth;
using System.Security.Claims;

namespace IdentityTemplate.Core.Application.Abstraction.Services.Auth
{
    public interface IAuthService
    {
        Task<UserDto> LoginAysnc(LoginDto loginDto);

        Task<UserDto> RegisterAsync(RegisterDto registerDto);

        Task<UserDto> GetCurrentUser(ClaimsPrincipal claimsPrincipal);

       
        Task<bool> EmailExists(string email);
    }
}
