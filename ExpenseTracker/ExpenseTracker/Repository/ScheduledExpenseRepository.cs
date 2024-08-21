using ExpenseTracker.Models;
using ExpenseTracker.Models.Entities;

namespace ExpenseTracker.Repository;

public class ScheduledExpenseRepository : BaseRepository<ScheduledExpense>
{
    public ScheduledExpenseRepository(AppDbContext context) : base(context) { }
}
