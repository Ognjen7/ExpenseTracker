using ExpenseTracker.Models;
using ExpenseTracker.Models.Entities;
using ExpenseTracker.Repository.Interfaces;

namespace ExpenseTracker.Repository;

public class ScheduledExpenseRepository : BaseRepository<ScheduledExpense>, IScheduledExpenseRepository
{
    public ScheduledExpenseRepository(AppDbContext context) : base(context) { }
}
