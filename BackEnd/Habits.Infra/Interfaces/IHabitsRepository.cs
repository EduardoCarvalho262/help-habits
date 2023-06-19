using Habits.Domain.Models;

namespace Habits.Infra.Interfaces
{
    public interface IHabitsRepository<T> : IRepository<T> where T : Habit
    {
    }
}
