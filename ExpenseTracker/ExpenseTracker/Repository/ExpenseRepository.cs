using ExpenseTracker.Models.DTOs;
using ExpenseTracker.Models.Entities;
using ExpenseTracker.Models;
using ExpenseTracker.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.Repository;

public class ExpenseRepository : BaseRepository<Expense>, IExpenseRepository
{
    public ExpenseRepository(AppDbContext context) : base(context)
    {
    }
    public async Task<IEnumerable<Expense>> GetByUserIdAsync(string userId)
    {
        return await _context.Expenses.Where(i => i.ApplicationUserId == userId).ToListAsync();
    }

    public async Task<IEnumerable<ExpenseDTO>> GetExpensesByDateRange(string userId, DateTime startDate, DateTime endDate)
    {
        return await _context.Expenses
            .Where(e => e.ApplicationUserId == userId && e.ExpenseDate >= startDate && e.ExpenseDate <= endDate)
            .Select(e => new ExpenseDTO
            {
                ExpenseId = e.ExpenseId,
                ExpenseName = e.ExpenseName,
                ExpenseDescription = e.ExpenseDescription,
                ExpenseAmount = e.ExpenseAmount,
                ExpenseDate = e.ExpenseDate
            })
            .ToListAsync();
    }
}
