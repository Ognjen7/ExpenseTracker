using AutoMapper;
using ExpenseTracker.Models.DTOs;
using ExpenseTracker.Models.Entities;
using ExpenseTracker.Repository.Interfaces;
using ExpenseTracker.Services.Interfaces;

namespace ExpenseTracker.Services;

public class IncomeService : BaseService<Income, IncomeDTO>, IIncomeService
{
    private readonly IIncomeRepository _incomeRepository;

    public IncomeService(IIncomeRepository repository, IMapper mapper)
        : base(repository, mapper)
    {
        _incomeRepository = repository;
    }

    public async Task<IEnumerable<IncomeDTO>> GetByUserIdAsync(string userId)
    {
        var incomes = await _incomeRepository.GetByUserIdAsync(userId);
        return _mapper.Map<IEnumerable<IncomeDTO>>(incomes);
    }
}
