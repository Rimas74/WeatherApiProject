using Newtonsoft.Json;

namespace WeatherApiProject.Models
    {
    public class WeatherApiResponse
        {
        [JsonProperty("currentConditions")]
        public CurrentWeather CurrentConditions { get; set; }

        [JsonProperty("resolvedAddress")]
        public required string ResolvedAddress { get; set; }



        }
    public class CurrentWeather
        {
        [JsonProperty("datetime")]
        public string DateTime { get; set; }

        [JsonProperty("temp")]
        public double Temperature { get; set; }


        }
    }