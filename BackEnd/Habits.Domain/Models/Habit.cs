using Newtonsoft.Json;

namespace Habits.Domain.Models
{
    public class Habit
    {
        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsClosed { get; set; }
        public string Objective { get; set; }
        public string Category { get; set; }
    }
}
