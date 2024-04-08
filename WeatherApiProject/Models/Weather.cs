using System.ComponentModel.DataAnnotations.Schema;

namespace WeatherApiProject.Models
    {
    public class Weather
        {
        public int Id { get; set; }
        public double Temperature { get; set; }
        public required string City { get; set; }
        public required string Region { get; set; }
        //public DateTime Date { get; set; }
        //[Column(TypeName = "DateTime2(0)")]
        public DateTime Date { get; set; }
        }
    }
