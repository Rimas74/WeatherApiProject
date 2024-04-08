namespace WeatherApiProject.Models
    {
    public class Weather
        {
        public int Id { get; set; }
        public double Temperature { get; set; }
        public required string City { get; set; }
        public required string Region { get; set; }
        }
    }
