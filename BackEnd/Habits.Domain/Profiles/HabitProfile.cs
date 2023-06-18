using AutoMapper;
using Habits.Domain.DTOs;
using Habits.Domain.Models;

namespace Habits.Domain.Profiles
{
    public class HabitProfile : Profile
    {
        public HabitProfile()
        {
            CreateMap<Habit, HabitDTO>();
            CreateMap<HabitDTO, Habit>();
        }
    }
}
