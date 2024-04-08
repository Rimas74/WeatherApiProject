namespace WeatherApiProject.DTOs
    {
    public class WeatherDto
        {
        public double Temperature { get; set; }
        public required string City { get; set; }
        public required string Region { get; set; }
        public DateTime Date { get; set; }

        }
    }
