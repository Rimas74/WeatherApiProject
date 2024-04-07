using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WeatherApiProject.Service;
using WeatherApiProject.Service.Interface;

namespace WeatherApiProject.Controllers
    {
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
        {
        private readonly ILogger<WeatherController> _logger;
        private readonly IWeatherSevice _weatherService;
        public WeatherController(ILogger<WeatherController> logger, IWeatherSevice weatherService)
            {
            _logger = logger;
            _weatherService = weatherService;
            }

        [HttpGet(Name = "GetWeatherByCity")]
        public async Task<IActionResult> Get(string city)
            {
            var weatherForecast = await _weatherService.GetWeatherByCityAsync(city);
            if (weatherForecast == null)
                {
                _logger.LogWarning($"Weather data not found for city: {city}");
                return NotFound($"Weather data for {city} not found.");
                }

            return Ok(weatherForecast);
            }
        }
    }
