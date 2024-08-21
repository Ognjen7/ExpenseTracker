using ExpenseTracker.Models.Queries;

namespace ExpenseTracker.Services.Interfaces
{
    public interface IBaseService<TDto, TKey>
    {
        Task<IEnumerable<TDto>> GetAllAsync();
        Task<TDto> GetByIdAsync(TKey id);
        Task AddAsync(TDto dto);
        Task UpdateAsync(TDto dto);
        Task DeleteAsync(TKey id);
        Task<IEnumerable<TDto>> QueryAsync(TransactionQuery query);
    }
}
