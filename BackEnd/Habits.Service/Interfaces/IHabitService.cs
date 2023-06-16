using Habits.Domain.DTOs;
using Habits.Domain.Models;
using Habits.Domain.Responses;
using System.Collections.Generic;

namespace Habits.Service.Interfaces
{
    public interface IHabitService
    {
        public Task<IEnumerable<Habit>> GetAllHabits();
        public Task<Habit> GetHabitByCategory(string category);
        public Task<Habit> AddHabit(HabitDTO newHabit);
        public Task<Habit> UpgradeHabit(HabitDTO upgradedHabit);
        public Task<Habit> DeleteHabit(string id);
    }
}
