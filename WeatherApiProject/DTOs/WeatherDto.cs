namespace WeatherApiProject.DTOs
    {
    public class WeatherDto
        {
        public double Temperature { get; set; }
        public required string Country { get; set; }
        public required string Region { get; set; }

        }
    }
