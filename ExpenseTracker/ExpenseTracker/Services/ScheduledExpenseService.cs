using AutoMapper;
using ExpenseTracker.Models;
using ExpenseTracker.Models.DTOs;
using ExpenseTracker.Models.Entities;
using ExpenseTracker.Repository.Interfaces;

namespace ExpenseTracker.Services
{
    public class ScheduledExpenseService : BaseService<ScheduledExpense, ScheduledExpenseDTO>
    {
        public ScheduledExpenseService(IScheduledExpenseRepository repository, IMapper mapper) : base(repository, mapper) { }
    }
}
