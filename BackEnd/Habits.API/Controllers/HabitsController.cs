using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Habits.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HabitsController : ControllerBase
    {

        //TODO - Obter todos os habitos
        [HttpGet]
        public string Get()
        {
            return "Hello World";
        }

        //TODO - Obter 1 hábito

        //TODO - Atualizar Hábito

        //TODO - Criar hábito

        //TODO - Deletar hábito


    }
}
