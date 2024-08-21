using ExpenseTracker.Models.Queries;

namespace ExpenseTracker.Repository.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
        Task<IEnumerable<T>> QueryAsync(TransactionQuery query);
    }
}
