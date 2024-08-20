using ExpenseTracker.Models.Entities;
using ExpenseTracker.Models;
using ExpenseTracker.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.Repository;

public class IncomeRepository : BaseRepository<Income>, IIncomeRepository
{
    public IncomeRepository(AppDbContext context) : base(context)
    {
    }
    public async Task<IEnumerable<Income>> GetByUserIdAsync(string userId)
    {
        return await _context.Incomes.Where(i => i.ApplicationUserId == userId).ToListAsync();
    }
}
