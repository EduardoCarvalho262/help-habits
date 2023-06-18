using Microsoft.Azure.Cosmos;
using System.Linq.Expressions;

namespace Habits.Infra.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
        Task<T> GetByIdAsync(string id);
        Task<ItemResponse<T>> AddAsync(T entity);
        Task<ItemResponse<T>> UpdateAsync(T entity);
        Task<ItemResponse<T>> DeleteAsync(string id, string category);
    }
}
