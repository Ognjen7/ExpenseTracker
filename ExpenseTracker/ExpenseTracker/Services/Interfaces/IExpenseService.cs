using ExpenseTracker.Models.DTOs;

namespace ExpenseTracker.Services.Interfaces
{
    public interface IExpenseService : IBaseService<ExpenseDTO, int>
    {
        Task<IEnumerable<ExpenseDTO>> GetByUserIdAsync(string userId);
        Task<IEnumerable<ExpenseDTO>> GetExpensesForLastWeek(string userId);
        Task<IEnumerable<ExpenseDTO>> GetExpensesForLastMonth(string userId);
        Task<double?> GetTotalExpensesForGroupAsync(int expenseGroupId);
    }
}
