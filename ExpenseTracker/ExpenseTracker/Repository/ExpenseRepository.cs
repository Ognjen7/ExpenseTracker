using ExpenseTracker.Models.DTOs;
using ExpenseTracker.Models.Entities;
using ExpenseTracker.Models;
using ExpenseTracker.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.Repository
{
    public class ExpenseRepository : BaseRepository<Expense>, IExpenseRepository
    {
        public ExpenseRepository(AppDbContext context) : base(context)
        {
        }
        public async Task<IEnumerable<Expense>> GetByUserIdAsync(string userId)
        {
            return await _context.Expenses.Where(i => i.ApplicationUserId == userId).ToListAsync();
        }
    }
}
