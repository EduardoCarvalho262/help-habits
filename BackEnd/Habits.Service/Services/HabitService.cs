using Habits.Domain.DTOs;
using Habits.Domain.Models;
using Habits.Domain.Responses;
using Habits.Infra.Interfaces;
using Habits.Service.Interfaces;
using System.Xml;

namespace Habits.Service.Services
{
    public class HabitService : IHabitService
    {
        private readonly IRepository<Habit> _repository;

        public HabitService(IRepository<Habit> repository)
        {
            _repository = repository;
        }

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
