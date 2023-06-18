﻿using Habits.Infra.Interfaces;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;
using System.Linq.Expressions;

namespace Habits.Infra.Repositories
{
    public class CosmosDbRepository<T> : IRepository<T> where T : class
    {
        private readonly Container _container;

        public CosmosDbRepository()
        {
            var cosmosClient = new CosmosClient("AccountEndpoint=https://localhost:8081/;AccountKey=C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==");
            var database = cosmosClient.GetDatabase("HelpHabits");
            _container = database.GetContainer("Habits");
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var query = new QueryDefinition("SELECT * FROM c");
            var iterator = _container.GetItemQueryIterator<T>(query);
            var results = new List<T>();

            while (iterator.HasMoreResults)
            {
                var response = await iterator.ReadNextAsync();
                results.AddRange(response.ToList());
            }

            return results;
        }


        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            var query = _container.GetItemLinqQueryable<T>()
                .Where(predicate)
                .ToFeedIterator();

            var results = new List<T>();
            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();
                results.AddRange(response.ToList());
            }
            return results;
        }

        public async Task<T> GetByCategoryAsync(string id)
        {
            try
            {
                var response = await _container.ReadItemAsync<T>(id, new PartitionKey(id));
                return response.Resource;
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                throw;
            }
        }

        public async Task<ItemResponse<T>> AddAsync(T entity)
        {
            return await _container.CreateItemAsync(entity);
        }

        public async Task<ItemResponse<T>> UpdateAsync(T entity)
        {
            return await _container.UpsertItemAsync(entity);
        }

        public async Task<ItemResponse<T>> DeleteAsync(string id)
        {
            return await _container.DeleteItemAsync<T>(id, new PartitionKey(id));
        }
    }
}
