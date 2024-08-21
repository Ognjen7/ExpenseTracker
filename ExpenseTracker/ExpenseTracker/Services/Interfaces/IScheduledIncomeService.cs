using ExpenseTracker.Models.DTOs;
using ExpenseTracker.Models.Entities;

namespace ExpenseTracker.Services.Interfaces;

public interface IScheduledIncomeService : IBaseService<ScheduledIncomeDTO, int>
{
    Task ScheduleIncomeAsync(ScheduledIncome scheduledIncome);
    Task ProcessScheduledIncomeAsync(int scheduledIncomeId);
}
