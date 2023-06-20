using Habits.Domain.Models;
using Habits.Infra.Interfaces;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;
using System.Linq.Expressions;

namespace Habits.Infra.Repositories
{
    public class HabitRepository : IHabitsRepository
    {
        private readonly Container _container;

        public HabitRepository(ICosmosDBContext dBContext)
        {
            _container = dBContext.GetEntityContainer<Habit>();
        }

        public async Task<ItemResponse<Habit>> AddAsync(Habit entity)
        {
            return await _container.CreateItemAsync(entity);
        }

        public async Task<ItemResponse<Habit>> DeleteAsync(string id, string category)
        {
            return await _container.DeleteItemAsync<Habit>(id, new PartitionKey(category));
        }

        public async Task<IEnumerable<Habit>> FindAsync(Expression<Func<Habit, bool>> predicate)
        {
            var query = _container.GetItemLinqQueryable<Habit>()
                .Where(predicate)
                .ToFeedIterator();

            var results = new List<Habit>();

            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();
                results.AddRange(response);
            }

            return results;
        }

        public async Task<IList<Habit>> GetAllAsync()
        {
            var query = _container.GetItemQueryIterator<Habit>();
            var results = new List<Habit>();

            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();
                results.AddRange(response.ToList());
            }

            return results;
        }

        public async Task<Habit> GetByIdAsync(string id, string partition)
        {
            try
            {
                ItemResponse<Habit> response = await _container.ReadItemAsync<Habit>(id, new PartitionKey(partition));
                return response.Resource;
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                throw;
            }
        }

        public async Task<ItemResponse<Habit>> UpdateAsync(Habit entity)
        {
            return await _container.ReplaceItemAsync(entity, entity.Id.ToString(), new PartitionKey(entity.Category));
        }
    }
}
