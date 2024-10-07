using AutoMapper;
using myapp.domain.models;
using myapp.domain.proxys;
using myapp.infra.proxy.weatherforecast.clients;
using myapp.infra.proxy.weatherforecast.resources;

namespace myapp.infra.proxy.weatherforecast.adapters;

public class WeatherProxy(IMapper mapper, IWeatherApi weatherApi) : IWeatherProxy
{
    public async Task<WeatherForecast?> GetCurrentWeatherAsync(double latitude, double longitude, string current, string hourly)
    {
        WeatherResponse? forecast = await weatherApi.GetWeatherForecastAsync(latitude, longitude, current, hourly);
        return forecast != null && forecast.Current != null ? mapper.Map<WeatherForecast>(forecast.Current) : null;
    }
}