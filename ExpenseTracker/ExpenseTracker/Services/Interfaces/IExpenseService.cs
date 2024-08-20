using ExpenseTracker.Models.DTOs;

namespace ExpenseTracker.Services.Interfaces
{
    public interface IExpenseService : IBaseService<ExpenseDTO, int>
    {
        Task<IEnumerable<ExpenseDTO>> GetByUserIdAsync(string userId);
    }
}
