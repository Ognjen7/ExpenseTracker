using ExpenseTracker.Models;
using ExpenseTracker.Models.Entities;
using ExpenseTracker.Repository.Interfaces;

namespace ExpenseTracker.Repository;

public class ScheduledIncomeRepository : BaseRepository<ScheduledIncome>, IScheduledIncomeRepository
{
    public ScheduledIncomeRepository(AppDbContext context) : base(context) { }
}
