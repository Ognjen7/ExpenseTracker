using ExpenseTracker.Models;
using ExpenseTracker.Models.Entities;
using ExpenseTracker.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.Repository
{
    public class ReminderRepository : BaseRepository<Reminder>, IReminderRepository
    {
        public ReminderRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<Reminder>> GetRemindersByUserIdAsync(string userId)
        {
            return await _context.Reminders
                .Where(r => r.ApplicationUserId == userId)
                .ToListAsync();
        }
    }
}
