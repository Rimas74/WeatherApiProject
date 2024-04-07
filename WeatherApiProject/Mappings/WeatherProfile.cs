using AutoMapper;
using WeatherApiProject.DTOs;
using WeatherApiProject.Models;

namespace WeatherApiProject.Mappings
    {
    public class WeatherProfile : Profile
        {
        public WeatherProfile()
            {
            CreateMap<Weather, WeatherDto>();
            }
        }
    }
