using myapp.domain.models;
using myapp.domain.services;
using myapp.infra.proxy.weatherforecast.adapters;

namespace myapp.business.services
{
    internal class WeatherForecastService(IWeatherApiAdapter weatherApiAdapter) : IWeatherForecastService
    {
        public async Task<WeatherForecast> GetCurrentWeatherAsync(double latitude, double longitude, string current, string hourly)
        {
            WeatherForecast forecast = await weatherApiAdapter.GetCurrentWeatherAsync(latitude, longitude, current, hourly);

            return forecast;
        }
    }
}
