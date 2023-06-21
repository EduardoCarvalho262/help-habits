using AutoMapper;
using Habits.Domain.DTOs;
using Habits.Domain.Models;
using Habits.Domain.Responses;
using Habits.Infra.Interfaces;
using Habits.Service.Interfaces;
using Serilog;

namespace Habits.Service.Services
{
    public class HabitService : IHabitService
    {
        private readonly IHabitsRepository _repository;
        private readonly IMapper _mapper;
        public HabitService(IHabitsRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<HabitResponse> AddHabit(HabitDTO newHabit)
        {
            try
            {
                var teste = _mapper.Map<Habit>(newHabit);
                Log.Debug($"ADD Request: {teste}");
                var response = await _repository.AddAsync(teste);
                Log.Debug($"Add Response: {response}");
                var result = _mapper.Map<HabitDTO>(response.Resource);
                return new HabitResponse { Message = response.StatusCode.ToString(), response = new List<HabitDTO> { result } };
            }
            catch (Exception ex)
            {
                Log.Debug($"Erro: {ex.Message}");
                return new HabitResponse { Message = $"Erro: {ex.Message}" };
            }
            
        }

        public async Task<HabitResponse> DeleteHabit(string id, string category)
        {
            try
            {
                Log.Debug($"Delete Request: Id:{id} - PartitionKey:{category}");
                var response = await _repository.DeleteAsync(id,category);
                Log.Debug($"Delete Response: {response}");
                return new HabitResponse { Message = response.StatusCode.ToString() };
            }
            catch (Exception ex)
            {
                Log.Debug($"Erro: {ex.Message}");
                return new HabitResponse { Message = $"Erro: {ex.Message}" };
            }
        }

        public async Task<HabitResponse> GetAllHabits()
        {
            try
            {
                var response = await _repository.GetAllAsync();
                Log.Debug($"GetAll Response: {response}");
                var result = _mapper.Map<List<HabitDTO>>(response.ToList());
                return new HabitResponse { Message = "Ok", response = result};
            }
            catch (Exception ex)
            {
                Log.Debug($"Erro: {ex.Message}");
                return new HabitResponse { Message = $"Erro: {ex.Message}" };
            }
        }

        public async Task<HabitResponse> GetHabitByCategory(string id, string partiton)
        {
            try
            {
                Log.Debug($"GetById Request: Id:{id} - PartitionKey:{partiton}");
                var response = await _repository.GetByIdAsync(id, partiton);
                var result = new List<HabitDTO> { _mapper.Map<HabitDTO>(response) };
                Log.Debug($"GetById Response: {response}");
                return new HabitResponse { Message = "Ok", response = result };
            }
            catch (Exception ex)
            {
                Log.Debug($"Erro: {ex.Message}");
                return new HabitResponse { Message = $"Erro: {ex.Message}" };
            }

        }

        public async Task<HabitResponse> UpdateHabit(HabitDTO upgradedHabit)
        {
            try
            {
                var teste = _mapper.Map<Habit>(upgradedHabit);
                Log.Debug($"Upgrade Request: {teste}");
                var response = await _repository.UpdateAsync(teste);
                Log.Debug($"Add Response: {response}");
                var result = _mapper.Map<HabitDTO>(response.Resource);
                return new HabitResponse { Message = response.StatusCode.ToString(), response = new List<HabitDTO> { result } };
            }
            catch (Exception ex)
            {
                Log.Debug($"Erro: {ex.Message}");
                return new HabitResponse { Message = $"Erro: {ex.Message}" };
            }

        }
    }
}
