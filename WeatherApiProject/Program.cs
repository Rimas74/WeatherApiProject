
using Microsoft.EntityFrameworkCore;
using WeatherApiProject.Repository;
using WeatherApiProject.Repository.Interface;
using WeatherApiProject.Service;
using WeatherApiProject.Service.Interface;

namespace WeatherApiProject
    {
    public class Program
        {
        public static void Main(string[] args)
            {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddHttpClient();
            builder.Services.AddAutoMapper(typeof(Program));

            builder.Services.AddScoped<IWeatherRepository, WeatherRepository>();
            builder.Services.AddScoped<IWeatherSevice, WeatherService>();


            builder.Services.AddDbContext<WeatherDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("WeatherDatabase")));



            builder.Logging.ClearProviders();
            builder.Logging.AddConsole();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
                {
                app.UseSwagger();
                app.UseSwaggerUI();
                }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
            }
        }
    }
