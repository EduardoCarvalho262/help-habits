using Habits.Domain.Models;
using Habits.Infra.Interfaces;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;
using System.Linq.Expressions;
using System.Net;

namespace Habits.Infra.Repositories
{
    public class CosmosDbRepository : ICosmosDBContext
    { 
        private readonly Database _cosmosDatabase;
        private readonly IDictionary<Type, Container> _dbContainer;

        public CosmosDbRepository(string database, CosmosClient client)
        {
            _cosmosDatabase = client.GetDatabase(database);
            _dbContainer = new Dictionary<Type, Container>();
        }

        public Container GetEntityContainer<TEntity>() where TEntity : class
        {
            return !_dbContainer.TryGetValue(typeof(TEntity), out var container)
                ? RetrieveContainer<TEntity>()
                : container;
        }

        private Container RetrieveContainer<T>()
        {
            var name = RetrieveEntityContainerName(typeof(TEntity));
            var container = _cosmosDatabase.GetContainer(name);
            _dbContainer.Add(typeof(T), container);
            return container;
        }
    }
}
