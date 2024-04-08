using AutoMapper;
using Newtonsoft.Json;
using WeatherApiProject.DTOs;
using WeatherApiProject.Models;
using WeatherApiProject.Repository.Interface;
using WeatherApiProject.Service.Interface;

namespace WeatherApiProject.Service
    {
    public class WeatherService : IWeatherSevice
        {
        private readonly IWeatherRepository _weatherRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<WeatherService> _logger;
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public WeatherService(IWeatherRepository weatherRepository, IMapper mapper, ILogger<WeatherService> logger, HttpClient httpClient, IConfiguration configuration)
            {
            _weatherRepository = weatherRepository;
            _mapper = mapper;
            _logger = logger;
            _httpClient = httpClient;
            _configuration = configuration;
            }

        public async Task<WeatherDto> GetWeatherByCityAsync(string city)
            {
            try
                {
                var apiKey = _configuration.GetValue<string>("WeatherApi:ApiKey"); //var apiKey = _configuration["WeatherApi:ApiKey"]; 
                var apiUrl = $"https://weather.visualcrossing.com/VisualCrossingWebServices/rest/services/timeline/{city}?unitGroup=metric&key={apiKey}&contentType=json";

                var response = await _httpClient.GetAsync(apiUrl);
                if (!response.IsSuccessStatusCode)
                    {
                    _logger.LogWarning($"Request to weather API failed for city {city}: {response.ReasonPhrase}");
                    return null;
                    }

                var responseContent = await response.Content.ReadAsStringAsync();
                var weatherApiResponse = JsonConvert.DeserializeObject<WeatherApiResponse>(responseContent);

                if (weatherApiResponse == null || weatherApiResponse.Days == null || !weatherApiResponse.Days.Any())
                    {
                    _logger.LogWarning($"Deserialization of API response failed or no data for city: {city}");
                    return null;
                    }


                var addressParts = weatherApiResponse.ResolvedAddress.Split(',');
                var extractedCity = addressParts.Length > 0 ? addressParts[0].Trim() : string.Empty;
                var extractedRegion = addressParts.Length > 2 ? addressParts[1].Trim() : string.Empty;

                var currentDayWeather = weatherApiResponse.Days.First();
                var weather = new Weather
                    {
                    Temperature = currentDayWeather.Temperature,
                    City = extractedCity,
                    Region = extractedRegion
                    };

                await _weatherRepository.AddWeatherAsync(weather);
                _logger.LogInformation($"The information about the weather in {extractedCity} was added to the database on [{DateTime.Now}].");

                return _mapper.Map<WeatherDto>(weather);
                }
            catch (Exception ex)
                {
                _logger.LogError(ex, $"Error occurred while getting weather data for city: {city}");
                return null;
                }
            }
        }
    }
