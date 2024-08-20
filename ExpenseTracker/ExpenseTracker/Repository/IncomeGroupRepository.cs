using ExpenseTracker.Models;
using ExpenseTracker.Models.Entities;
using ExpenseTracker.Repository.Interfaces;

namespace ExpenseTracker.Repository
{
    public class IncomeGroupRepository : BaseRepository<IncomeGroup>, IIncomeGroupRepository
    {
        public IncomeGroupRepository (AppDbContext context) : base(context) { }
    }
}
