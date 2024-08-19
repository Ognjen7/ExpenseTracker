using ExpenseTracker.Models.Entities;
using Microsoft.AspNetCore.Identity;

namespace ExpenseTracker.Repository.Interfaces
{
    public interface IApplicationUserRepository : IBaseRepository<ApplicationUser>
    {
        Task<IdentityResult> CreateUserAsync(ApplicationUser user, string password);
        Task<ApplicationUser> GetUserByIdAsync(string userId);
        Task DeleteUserAsync(ApplicationUser user);
    }
}
