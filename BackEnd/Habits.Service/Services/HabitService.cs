using Habits.Domain.DTOs;
using Habits.Domain.Responses;
using Habits.Service.Interfaces;

namespace Habits.Service.Services
{
    public class HabitService : IHabitService
    {
        public Task<HabitResponse> AddHabit(HabitDTO newHabit)
        {
            throw new NotImplementedException();
        }

        public Task<HabitResponse> DeleteHabit(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<HabitResponse> GetAllHabits()
        {
            throw new NotImplementedException();
        }

        public Task<HabitResponse> GetHabitById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<HabitResponse> UpgradeHabit(HabitDTO upgradedHabit)
        {
            throw new NotImplementedException();
        }
    }
}
