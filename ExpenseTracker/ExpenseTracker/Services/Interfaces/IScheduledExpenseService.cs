using ExpenseTracker.Models.DTOs;
using ExpenseTracker.Models.Entities;

namespace ExpenseTracker.Services.Interfaces;

public interface IScheduledExpenseService : IBaseService<ScheduledExpenseDTO, int>
{
    Task ScheduledExpenseAsync(ScheduledExpense scheduledExpense);
    Task ProcessScheduledExpenseAsync(int scheduledExpenseId);

}
