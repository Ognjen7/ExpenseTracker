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

    public async Task<IEnumerable<IncomeDTO>> GetIncomesForLastWeek(string userId)
    {
        var oneWeekAgo = DateTime.Now.AddDays(-7);
        return await _incomeRepository.GetIncomesByDateRange(userId, oneWeekAgo, DateTime.Now);
    }

    public async Task<IEnumerable<IncomeDTO>> GetIncomesForLastMonth(string userId)
    {
        var oneMonthAgo = DateTime.Now.AddMonths(-1);
        return await _incomeRepository.GetIncomesByDateRange(userId, oneMonthAgo, DateTime.Now);
    }
}
