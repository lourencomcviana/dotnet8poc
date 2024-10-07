using myapp.domain.models;

namespace myapp.infra.proxy.weatherforecast.adapters
{
    public interface IWeatherApiAdapter
    {
        public Task<WeatherForecast?> GetCurrentWeatherAsync(double latitude, double longitude, string current, string hourly);
    }
}
