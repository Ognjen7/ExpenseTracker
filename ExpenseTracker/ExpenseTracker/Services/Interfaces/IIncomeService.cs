using ExpenseTracker.Models.DTOs;

namespace ExpenseTracker.Services.Interfaces
{
    public interface IIncomeService : IBaseService<IncomeDTO, int>
    {
        Task<IEnumerable<IncomeDTO>> GetByUserIdAsync(string userId);
    }
}
