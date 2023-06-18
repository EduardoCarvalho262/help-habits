using Habits.Domain.DTOs;
using Habits.Domain.Responses;

namespace Habits.Service.Interfaces
{
    public interface IHabitService
    {
        public Task<HabitResponse> GetAllHabits();
        public Task<HabitResponse> GetHabitByCategory(string category);
        public Task<HabitResponse> AddHabit(HabitDTO newHabit);
        public Task<HabitResponse> UpgradeHabit(HabitDTO upgradedHabit);
        public Task<HabitResponse> DeleteHabit(string id);
    }
}
