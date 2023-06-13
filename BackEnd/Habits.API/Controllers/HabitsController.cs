using Habits.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Habits.API.Controllers
{
    [Route("api")]
    [ApiController]
    public class HabitsController : ControllerBase
    {

        //TODO - Obter todos os habitos
        [HttpGet("habits")]
        public IActionResult Get()
        {
            return Ok(new Habit { Id = Guid.NewGuid(), Name = "Estudar inglês"});
        }

        //TODO - Obter 1 hábito
        [HttpGet("habit")]
        public IActionResult GetById()
        {
            return Ok(new Habit { Id = Guid.NewGuid(), Name = "Estudar inglês" });
        }

        //TODO - Atualizar Hábito
        [HttpPut("habit")]
        public IActionResult Put()
        {
            return Ok(new Habit { Id = Guid.NewGuid(), Name = "Estudar inglês" });
        }

        //TODO - Criar hábito
        [HttpPost("habit")]
        public IActionResult Post()
        {
            return Ok(new Habit { Id = Guid.NewGuid(), Name = "Estudar inglês" });
        }

        //TODO - Deletar hábito
        [HttpDelete("habit")]
        public IActionResult Delete()
        {
            return Ok(new Habit { Id = Guid.NewGuid(), Name = "Estudar inglês" });
        }
    }
}
