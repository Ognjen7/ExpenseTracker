using ExpenseTracker.Models;
using ExpenseTracker.Models.Entities;
using ExpenseTracker.Models.Queries;
using ExpenseTracker.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.Repository;

public class BaseRepository<T> : IBaseRepository<T> where T : class
{
    protected readonly AppDbContext _context;
    private readonly DbSet<T> _dbSet;

    public BaseRepository(AppDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(T entity)
    {
        _dbSet.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _dbSet.FindAsync(id);
        if (entity != null)
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<T>> QueryAsync(TransactionQuery query)
    {
        var queryable = _dbSet.AsQueryable();

        if (typeof(T) == typeof(Income))
        {
            var incomes = queryable as IQueryable<Income>;

            if (query.GroupId.HasValue)
            {
                incomes = incomes.Where(i => i.IncomeGroupId == query.GroupId.Value);
            }

            if (query.MinAmount.HasValue)
            {
                incomes = incomes.Where(i => i.IncomeAmount >= query.MinAmount.Value);
            }

            if (query.MaxAmount.HasValue)
            {
                incomes = incomes.Where(i => i.IncomeAmount <= query.MaxAmount.Value);
            }

            if (query.DateFrom.HasValue)
            {
                incomes = incomes.Where(i => i.IncomeDate >= query.DateFrom.Value);
            }

            if (query.DateTo.HasValue)
            {
                incomes = incomes.Where(i => i.IncomeDate.Value <= query.DateTo.Value);
            }

            incomes = ApplySorting(incomes, query.SortBy, query.SortDirection);

            incomes = incomes.Skip((query.PageNumber - 1) * query.PageSize)
                           .Take(query.PageSize);

            return await incomes.ToListAsync() as IEnumerable<T>;
        }

        if (typeof(T) == typeof(Expense))
        {
            var expenses = queryable as IQueryable<Expense>;

            if (query.GroupId.HasValue)
            {
                expenses = expenses.Where(i => i.ExpenseGroupId == query.GroupId.Value);
            }

            if (query.MinAmount.HasValue)
            {
                expenses = expenses.Where(i => i.ExpenseAmount >= query.MinAmount.Value);
            }

            if (query.MaxAmount.HasValue)
            {
                expenses = expenses.Where(i => i.ExpenseAmount <= query.MaxAmount.Value);
            }

            if (query.DateFrom.HasValue)
            {
                expenses = expenses.Where(i => i.ExpenseDate >= query.DateFrom.Value);
            }

            if (query.DateTo.HasValue)
            {
                expenses = expenses.Where(i => i.ExpenseDate <= query.DateTo.Value);
            }

            expenses = ApplySorting(expenses, query.SortBy, query.SortDirection);

            expenses = expenses.Skip((query.PageNumber - 1) * query.PageSize)
                           .Take(query.PageSize);

            return await expenses.ToListAsync() as IEnumerable<T>;
        }

        return new List<T>();
    }

    private IQueryable<Income> ApplySorting(IQueryable<Income> source, string sortBy, string sortDirection)
    {
        if (string.IsNullOrEmpty(sortBy)) return source;

        switch (sortBy)
        {
            case "IncomeDate":
                return sortDirection.ToLower() == "desc" ? source.OrderByDescending(e => e.IncomeDate) : source.OrderBy(e => e.IncomeDate);
            case "IncomeAmount":
                return sortDirection.ToLower() == "desc" ? source.OrderByDescending(e => e.IncomeAmount) : source.OrderBy(e => e.IncomeAmount);
            case "IncomeGroupId":
                return sortDirection.ToLower() == "desc" ? source.OrderByDescending(e => e.IncomeGroupId) : source.OrderBy(e => e.IncomeGroupId);
            default:
                return source;
        }
    }

    private IQueryable<Expense> ApplySorting(IQueryable<Expense> source, string sortBy, string sortDirection)
    {
        if (string.IsNullOrEmpty(sortBy)) return source;

        switch (sortBy)
        {
            case "ExpenseDate":
                return sortDirection.ToLower() == "desc" ? source.OrderByDescending(e => e.ExpenseDate) : source.OrderBy(e => e.ExpenseDate);
            case "ExpenseAmount":
                return sortDirection.ToLower() == "desc" ? source.OrderByDescending(e => e.ExpenseAmount) : source.OrderBy(e => e.ExpenseAmount);
            case "ExpenseGroupId":
                return sortDirection.ToLower() == "desc" ? source.OrderByDescending(e => e.ExpenseGroupId) : source.OrderBy(e => e.ExpenseGroupId);
            default:
                return source;
        }
    }
}
