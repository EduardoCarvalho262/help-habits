using Habits.Domain.DTOs;
using Habits.Domain.Responses;

namespace Habits.Service.Interfaces
{
    public interface IHabitService
    {
        public Task<HabitResponse> GetAllHabits();
        public Task<HabitResponse> GetHabitByCategory(string category, string partition);
        public Task<HabitResponse> AddHabit(HabitDTO newHabit);
        public Task<HabitResponse> UpdateHabit(HabitDTO upgradedHabit);
        public Task<HabitResponse> DeleteHabit(string id, string category);
    }
}
