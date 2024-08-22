using ExpenseTracker.Models.Entities;

namespace ExpenseTracker.Repository.Interfaces
{
    public interface IReminderRepository : IBaseRepository<Reminder>
    {
        Task<IEnumerable<Reminder>> GetRemindersByUserIdAsync(string userId);
    }
}
