using myapp.domain.models;
using myapp.domain.proxys;
using myapp.domain.services;
using myapp.infra.proxy.weatherforecast.adapters;

namespace myapp.business.services
{
    internal class WeatherForecastService(IWeatherProxy weatherProxy) : IWeatherForecastService
    {
        public async Task<WeatherForecast> GetCurrentWeatherAsync(double latitude, double longitude, string current, string hourly)
        {
            WeatherForecast forecast = await weatherProxy.GetCurrentWeatherAsync(latitude, longitude, current, hourly);

            return forecast;
        }
    }
}
