using WeatherApiProject.Models;
using WeatherApiProject.Repository.Interface;

namespace WeatherApiProject.Repository
    {
    public class WeatherRepository : IWeatherRepository
        {
        private readonly WeatherDbContext _dbContext;
        private readonly ILogger<WeatherRepository> _logger;

        public WeatherRepository(WeatherDbContext dContext, ILogger<WeatherRepository> logger)
            {
            _dbContext = dContext;
            _logger = logger;
            }
        public async Task AddWeatherAsync(Weather weather)
            {
            try
                {
                await _dbContext.Weathers.AddAsync(weather);
                await _dbContext.SaveChangesAsync();
                }
            catch (Exception ex)
                {
                _logger.LogError(ex, "rror occured while saving weather data");
                }
            }
        }
    }
