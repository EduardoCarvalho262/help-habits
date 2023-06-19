using Habits.Domain.Models;
using Habits.Infra.Interfaces;
using Microsoft.Azure.Cosmos;
using System.Linq.Expressions;

namespace Habits.Infra.Repositories
{
    public class HabitRepository<T> : IHabitsRepository<T> where T : Habit
    {
        public Task<ItemResponse<T>> AddAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<ItemResponse<T>> DeleteAsync(string id, string category)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<T> GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<ItemResponse<T>> UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
