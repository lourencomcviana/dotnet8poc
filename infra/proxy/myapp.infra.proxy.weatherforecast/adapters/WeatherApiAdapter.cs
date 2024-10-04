using AutoMapper;
using Microsoft.Extensions.Logging;
using myapp.domain.models;
using myapp.domain.services;
using myapp.infra.proxy.weatherforecast.clients;
using myapp.infra.proxy.weatherforecast.resources;
using map = myapp.infra.proxy.weatherforecast.mappings;
namespace myapp.infra.proxy.weatherforecast.adapters;

public class WeatherApiAdapter(ILogger<WeatherApiAdapter> log, IMapper mapper, IWeatherApi weatherApi) : IWeatherApiAdapter
{
    public async Task<WeatherForecast> GetCurrentWeatherAsync(double latitude, double longitude, string current, string hourly)
    {
        WeatherResponse forecast = await weatherApi.GetWeatherForecastAsync(latitude, longitude, current, hourly);
        return forecast != null && forecast.Current != null ? mapper.Map<WeatherForecast>(forecast.Current) : null;
    }
}