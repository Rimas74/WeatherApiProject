using Newtonsoft.Json;

namespace WeatherApiProject.Models
    {
    public class WeatherApiResponse
        {
        [JsonProperty("resolvedAddress")]
        public required string ResolvedAddress { get; set; }

        [JsonProperty("days")]
        public required List<DayWeather> Days { get; set; }
        }

    public class DayWeather
        {
        [JsonProperty("temp")]
        public double Temperature { get; set; }

        [JsonProperty("datetime")]
        public required string DateTime { get; set; }
        }
    }
