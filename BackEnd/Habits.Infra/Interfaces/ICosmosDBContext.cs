using Microsoft.Azure.Cosmos;

namespace Habits.Infra.Interfaces
{
    public interface ICosmosDBContext
    {
        public Container GetEntityContainer<TEntity>() where TEntity : class;
    }
}
