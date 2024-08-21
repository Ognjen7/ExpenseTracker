using AutoMapper;
using ExpenseTracker.Models.DTOs;
using ExpenseTracker.Models.Entities;
using ExpenseTracker.Repository.Interfaces;

namespace ExpenseTracker.Services
{
    public class ScheduledIncomeService : BaseService<ScheduledIncome, ScheduledIncomeDTO>
    {
        public ScheduledIncomeService(IScheduledIncomeRepository repository, IMapper mapper) : base(repository, mapper) { }
    }
}
