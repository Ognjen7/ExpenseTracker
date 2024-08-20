using ExpenseTracker.Models.Entities;

namespace ExpenseTracker.Repository.Interfaces;

public interface IIncomeRepository : IBaseRepository<Income>
{
    Task<IEnumerable<Income>> GetByUserIdAsync(string userId);
}
