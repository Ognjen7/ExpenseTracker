using AutoMapper;
using ExpenseTracker.Models.DTOs;
using ExpenseTracker.Models.Entities;
using ExpenseTracker.Repository.Interfaces;
using ExpenseTracker.Services.Interfaces;

namespace ExpenseTracker.Services;

public class ExpenseService : BaseService<Expense, ExpenseDTO>, IExpenseService
{
    private readonly IExpenseRepository _expenseRepository;

    public ExpenseService(IExpenseRepository repository, IMapper mapper)
        : base(repository, mapper)
    {
        _expenseRepository = repository;
    }
    public async Task<IEnumerable<ExpenseDTO>> GetByUserIdAsync(string userId)
    {
        var expenses = await _expenseRepository.GetByUserIdAsync(userId);
        return _mapper.Map<IEnumerable<ExpenseDTO>>(expenses);
    }
}
