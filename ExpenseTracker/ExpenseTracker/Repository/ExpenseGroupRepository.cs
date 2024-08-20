using ExpenseTracker.Models;
using ExpenseTracker.Models.Entities;
using ExpenseTracker.Repository.Interfaces;

namespace ExpenseTracker.Repository
{
    public class ExpenseGroupRepository : BaseRepository<ExpenseGroup>, IExpenseGroupRepository
    {
        public ExpenseGroupRepository(AppDbContext context) : base(context) { }
    }
}
