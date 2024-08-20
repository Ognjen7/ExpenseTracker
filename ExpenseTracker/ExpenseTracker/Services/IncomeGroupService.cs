using AutoMapper;
using ExpenseTracker.Models.DTOs;
using ExpenseTracker.Models.Entities;
using ExpenseTracker.Repository.Interfaces;
using ExpenseTracker.Services.Interfaces;

namespace ExpenseTracker.Services;

public class IncomeGroupService : BaseService<IncomeGroup, IncomeGroupDTO>, IIncomeGroupService
{
    public IncomeGroupService(IIncomeGroupRepository repository, IMapper mapper) : base(repository, mapper) { }
}
