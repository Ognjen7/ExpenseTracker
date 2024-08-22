using ExpenseTracker.Models.DTOs;
using ExpenseTracker.Models.Entities;

namespace ExpenseTracker.Repository.Interfaces;

public interface IExpenseRepository : IBaseRepository<Expense>
{
    Task<IEnumerable<Expense>> GetByUserIdAsync(string userId);
    Task<IEnumerable<ExpenseDTO>> GetExpensesByDateRange(string userId, DateTime startDate, DateTime endDate);
}
