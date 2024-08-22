using ExpenseTracker.Models.Entities;
using ExpenseTracker.Models;
using ExpenseTracker.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using ExpenseTracker.Models.DTOs;

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

    public async Task<IEnumerable<IncomeDTO>> GetIncomesByDateRange(string userId, DateTime startDate, DateTime endDate)
    {
        return await _context.Incomes
            .Where(i => i.ApplicationUserId == userId && i.IncomeDate >= startDate && i.IncomeDate <= endDate)
            .Select(i => new IncomeDTO
            {
                IncomeId = i.IncomeId,
                IncomeName = i.IncomeName,
                IncomeDescription = i.IncomeDescription,
                IncomeAmount = i.IncomeAmount,
                IncomeDate = (DateTime)i.IncomeDate
            })
            .ToListAsync();
    }
}
