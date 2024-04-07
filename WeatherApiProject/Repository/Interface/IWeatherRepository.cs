using WeatherApiProject.Models;

namespace WeatherApiProject.Repository.Interface
    {
    public interface IWeatherRepository
        {
        Task AddWeatherAsync(Weather weather);
        }
    }
