using AutoMapper;
using ExpenseTracker.Models.DTOs;
using ExpenseTracker.Models.Entities;
using ExpenseTracker.Repository.Interfaces;
using ExpenseTracker.Services.Interfaces;

namespace ExpenseTracker.Services;

public class ExpenseGroupService : BaseService<ExpenseGroup, ExpenseGroupDTO>, IExpenseGroupService
{
    public ExpenseGroupService(IExpenseGroupRepository repository, IMapper mapper) : base(repository, mapper) { }
}
