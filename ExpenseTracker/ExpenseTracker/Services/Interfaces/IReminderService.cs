using ExpenseTracker.Models.DTOs;
using ExpenseTracker.Models.Entities;

namespace ExpenseTracker.Services.Interfaces
{
    public interface IReminderService
    {
        Task ScheduleWeeklyReminderAsync(WeeklyReminderDTO weeklyReminderDto);
        Task ScheduleMonthlyReminderAsync(MonthlyReminderDTO monthlyReminderDto);
        Task<IEnumerable<Reminder>> GetRemindersByUserIdAsync(string userId);
        Task<IEnumerable<Reminder>> GetAllRemindersAsync();
    }
}
