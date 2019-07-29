using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BettyAppAPI.Models;
using BettyAppAPI.Dtos;
using AutoMapper;

namespace BettyAppAPI.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
            CreateMap<Meal, MealDto>();
            CreateMap<MealDto, Meal>();
        }
    }
}
