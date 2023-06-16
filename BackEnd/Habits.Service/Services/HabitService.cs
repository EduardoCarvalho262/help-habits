using Habits.Domain.DTOs;
using Habits.Domain.Models;
using Habits.Infra.Interfaces;
using Habits.Service.Interfaces;

namespace Habits.Service.Services
{
    public class HabitService : IHabitService
    {
        private readonly IRepository<Habit> _repository;

        public HabitService(IRepository<Habit> repository)
        {
            _repository = repository;
        }

        public async Task<Habit> AddHabit(HabitDTO newHabit)
        {
            //TODO - Utitlizar AutoMapper
            var response = await _repository.AddAsync(new Habit());
            return response;
        }

        public async Task<Habit> DeleteHabit(string id)
        {
            var response = await _repository.DeleteAsync(id);
            return response;
        }

        public async Task<IEnumerable<Habit>> GetAllHabits()
        {
             var response =  await _repository.GetAllAsync();
            return response;
        }

        public async Task<Habit> GetHabitByCategory(string category)
        {
            var response = await _repository.GetByCategoryAsync(category);
            return response;
        }

        public async Task<Habit> UpgradeHabit(HabitDTO upgradedHabit)
        {
            //TODO - AutoMapper 
            var response = await _repository.UpdateAsync(new Habit());
            return response;
        }
    }
}
