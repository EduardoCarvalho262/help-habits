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

            if(response.Message.Contains("Erro"))
                return BadRequest(response);

            return Ok(response);
        }

        [HttpGet("habit/{id:guid}/{partition}")]
        public async Task<IActionResult> GetByCategory(string id, string partition)
        {
            var response =  await _habitService.GetHabitByCategory(id,partition);

            if (response.Message.Contains("Erro"))
                return BadRequest(response);

            return Ok(response);
        }

        [HttpPut("habit")]
        public async Task<IActionResult> Put(HabitDTO upgradedHabit)
        {
            var response = await _habitService.UpgradeHabit(upgradedHabit);

            if (response.Message.Contains("Erro"))
                return BadRequest(response);

            return Ok(response);
        }

        [HttpPost("habit")]
        public async Task<IActionResult> Post(HabitDTO newHabit)
        {
            var response = await _habitService.AddHabit(newHabit);

            if (response.Message.Contains("Erro"))
                return BadRequest(response);

            return Ok(response);
        }

        [HttpDelete("habit/{id:guid}/{category}")]
        public async Task<IActionResult> Delete(string id, string category)
        {
            var response = await _habitService.DeleteHabit(id, category);

            if (response.Message.Contains("Erro"))
                return BadRequest(response);

            return Ok(response);
        }
    }
}
