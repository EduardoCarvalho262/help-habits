using Habits.Domain.DTOs;
using Habits.Domain.Models;
using Habits.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Habits.API.Controllers
{
    [Route("api")]
    [ApiController]
    public class HabitsController : ControllerBase
    {
        private readonly IHabitService _habitService;
        public HabitsController(IHabitService habitService)
        {
            _habitService = habitService;
        }

        [HttpGet("habits")]
        public async Task<IActionResult> Get()
        {
            var response = await _habitService.GetAllHabits();
            return Ok(response);
        }

        //TODO - Obter 1 hábito
        [HttpGet("habit")]
        public async Task<IActionResult> GetByCategory(string category)
        {
            var response =  await _habitService.GetHabitByCategory(category);
            return Ok(response);
        }

        //TODO - Atualizar Hábito
        [HttpPut("habit")]
        public async Task<IActionResult> Put(HabitDTO upgradedHabit)
        {
            var response = await _habitService.UpgradeHabit(upgradedHabit);
            return Ok(response);
        }

        //TODO - Criar hábito
        [HttpPost("habit")]
        public async Task<IActionResult> Post(HabitDTO newHabit)
        {
            var response = await _habitService.AddHabit(newHabit);
            return Ok(response);
        }

        //TODO - Deletar hábito
        [HttpDelete("habit")]
        public async Task<IActionResult> Delete(string id)
        {
            var response = await _habitService.DeleteHabit(id);
            return Ok(response);
        }
    }
}
