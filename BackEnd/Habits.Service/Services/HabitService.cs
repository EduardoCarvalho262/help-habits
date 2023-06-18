using AutoMapper;
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
        private readonly IMapper _mapper;
        public HabitService(IRepository<Habit> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<HabitResponse> AddHabit(HabitDTO newHabit)
        {
            try
            {
                var teste = _mapper.Map<Habit>(newHabit);
                var response = await _repository.AddAsync(teste);
                var result = _mapper.Map<HabitDTO>(response.Resource);
                return new HabitResponse { Message = response.StatusCode.ToString(), response = new List<HabitDTO> { result } };
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
                var result = _mapper.Map<List<HabitDTO>>(response.ToList());
                return new HabitResponse { Message = "Ok", response = result};
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
