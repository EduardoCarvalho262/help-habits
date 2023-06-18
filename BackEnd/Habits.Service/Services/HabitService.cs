using Habits.Domain.DTOs;
using Habits.Domain.Models;
using Habits.Domain.Responses;
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

        public async Task<HabitResponse> AddHabit(HabitDTO newHabit)
        {
            try
            {
                //TODO - Utitlizar AutoMapper
                var response = await _repository.AddAsync(new Habit());
                return new HabitResponse { Message = response.StatusCode.ToString()};
            }
            catch (Exception ex)
            {
                return new HabitResponse { Message = $"Erro: {ex.Message}" };
            }
            
        }

        public async Task<HabitResponse> DeleteHabit(string id)
        {
            try
            {
                var response = await _repository.DeleteAsync(id);
                return new HabitResponse { Message = response.StatusCode.ToString() };
            }
            catch (Exception ex)
            {
                return new HabitResponse { Message = $"Erro: {ex.Message}" };
            }
        }

        public async Task<HabitResponse> GetAllHabits()
        {
            try
            {
                var response = await _repository.GetAllAsync();
                return new HabitResponse { Message = "Ok"};
            }
            catch (Exception ex)
            {
                return new HabitResponse { Message = $"Erro: {ex.Message}" };
            }
        }

        public async Task<HabitResponse> GetHabitByCategory(string category)
        {
            try
            {
                var response = await _repository.GetByCategoryAsync(category);
                return new HabitResponse { Message = "Ok" };
            }
            catch (Exception ex)
            {
                return new HabitResponse { Message = $"Erro: {ex.Message}" };
            }

        }

        public async Task<HabitResponse> UpgradeHabit(HabitDTO upgradedHabit)
        {
            try
            {
                var response = await _repository.UpdateAsync(new Habit());
                return new HabitResponse { Message = "Ok" };
            }
            catch (Exception ex)
            {
                return new HabitResponse { Message = $"Erro: {ex.Message}" };
            }

        }
    }
}
