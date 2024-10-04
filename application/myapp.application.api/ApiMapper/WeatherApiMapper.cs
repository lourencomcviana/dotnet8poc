using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using myapp.application.api.resources;
using myapp.domain.models;
using myapp.domain.proxys;
using myapp.domain.services;
using System.Runtime.CompilerServices;

namespace myapp.application.api.apiMapper
{
    public static class WeatherApiMapper
    {
        public static void MapWeatherApi(this WebApplication app)
        {
            app.MapGet("/weatherforecast", async ([FromServices] IWeatherForecastService weatherForecastService, [FromServices] IMapper mapper) =>
            {
                // 
                var forecast = await weatherForecastService.GetCurrentWeatherAsync(-23.6354044, -46.6449888, "temperature_2m,wind_speed_10m", "temperature_2m,relative_humidity_2m,wind_speed_10m");

                return forecast != null ? mapper.Map<WeatherBody>(forecast) : null;
            })
            .WithName("GetWeatherForecast")
            .WithOpenApi();
        }
    }
}
