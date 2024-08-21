using ExpenseTracker.Models;
using ExpenseTracker.Models.Entities;

namespace ExpenseTracker.Repository;

public class ScheduledIncomeRepository : BaseRepository<ScheduledIncome>
{
    public ScheduledIncomeRepository(AppDbContext context) : base(context) { }
}
