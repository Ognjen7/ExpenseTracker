using ExpenseTracker.Models;
using ExpenseTracker.Models.Entities;
using ExpenseTracker.Repository.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.Repository;

public class ApplicationUserRepository : IApplicationUserRepository
{
    private readonly AppDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;

    public async Task<IdentityResult> CreateUserAsync(ApplicationUser user, string password)
    {
        return await _userManager.CreateAsync(user, password);
    }

    public async Task<ApplicationUser> GetUserByIdAsync(string userId)
    {
        return await _userManager.FindByIdAsync(userId);
    }

    public async Task UpdateAsync(ApplicationUser entity)
    {
        await _userManager.UpdateAsync(entity);
    }

    public async Task DeleteUserAsync(ApplicationUser user)
    {
        await _userManager.DeleteAsync(user);
    }

    public async Task<IEnumerable<ApplicationUser>> GetAllAsync()
    {
        return await _context.Users.ToListAsync();
    }

    public Task<ApplicationUser> GetByIdAsync(int id)
    {
        throw new System.NotImplementedException();
    }

    public Task AddAsync(ApplicationUser entity)
    {
        throw new System.NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new System.NotImplementedException();
    }
}
