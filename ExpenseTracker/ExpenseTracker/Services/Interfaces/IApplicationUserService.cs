using ExpenseTracker.Models.DTOs;
using ExpenseTracker.Models.Entities;
using Microsoft.AspNetCore.Identity;

namespace ExpenseTracker.Services.Interfaces
{
    public interface IApplicationUserService
    {
        Task<IdentityResult> RegisterAsync(RegisterDTO model);
        Task<SignInResult> LoginAsync(LoginDTO model);
        Task<IEnumerable<ApplicationUserDTO>> GetAllUsersAsync();
        Task<ApplicationUserDTO> GetUserByIdAsync(string userId);
        Task UpdateUserAsync(ApplicationUser user);
        Task<bool> DeleteUserAsync(string userId);
        Task<TokenDTO> GenerateJwtTokenAsync(ApplicationUser user);
    }
}
