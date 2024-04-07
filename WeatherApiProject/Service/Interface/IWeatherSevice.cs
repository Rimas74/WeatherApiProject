using WeatherApiProject.DTOs;

namespace WeatherApiProject.Service.Interface
    {
    public interface IWeatherSevice
        {
        Task<WeatherDto> GetWeatherByCityAsync(string city);
        }
    }
