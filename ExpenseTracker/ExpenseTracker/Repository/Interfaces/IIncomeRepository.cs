using ExpenseTracker.Models.DTOs;
using ExpenseTracker.Models.Entities;

namespace ExpenseTracker.Repository.Interfaces;

public interface IIncomeRepository : IBaseRepository<Income>
{
    Task<IEnumerable<Income>> GetByUserIdAsync(string userId);
    Task<IEnumerable<IncomeDTO>> GetIncomesByDateRange(string userId, DateTime startDate, DateTime endDate);
}
