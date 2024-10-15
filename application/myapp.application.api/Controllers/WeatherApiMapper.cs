using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using myapp.application.api.resources;
using myapp.domain.configurations;
using myapp.domain.services;

namespace myapp.application.api.Controllers
{
    public static class WeatherApiMapper
    {
        public static void MapWeatherApi(this WebApplication app)
        {
            app.MapGet("/weatherforecast", async (
                    [FromServices] IWeatherForecastService weatherForecastService,
                    [FromServices] IMapper mapper,
                    [FromServices]IOptions<WeatherForecastOptions> options
                    ) => {
                var weatherForecastoptions = options.Value;

                var forecast = await weatherForecastService.GetCurrentWeatherAsync(
                    weatherForecastoptions.Latitude, weatherForecastoptions.Longitude,weatherForecastoptions.Current, weatherForecastoptions.Hourly
                );

                return forecast != null ? mapper.Map<WeatherBody>(forecast) : null;
            })
            .WithName("GetWeatherForecast")
            .WithOpenApi();
        }
    }
}
