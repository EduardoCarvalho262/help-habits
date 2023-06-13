using Habits.Domain.DTOs;

namespace Habits.Domain.Responses
{
    public class HabitResponse
    {
        public string Message { get; set; }
        public IList<HabitDTO> response { get; set; }
    }
}
