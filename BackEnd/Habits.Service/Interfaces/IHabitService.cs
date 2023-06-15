using Habits.Domain.DTOs;
using Habits.Domain.Models;
using Habits.Domain.Responses;
using System.Collections.Generic;

namespace Habits.Service.Interfaces
{
    public interface IHabitService
    {
        public Task<IEnumerable<Habit>> GetAllHabits();
        public Task<HabitResponse> GetHabitById(Guid id);
        public Task<HabitResponse> AddHabit(HabitDTO newHabit);
        public Task<HabitResponse> UpgradeHabit(HabitDTO upgradedHabit);
        public Task<HabitResponse> DeleteHabit(Guid id);
    }
}
