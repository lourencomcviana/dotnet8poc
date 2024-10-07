using myapp.domain.models;

namespace myapp.domain.services
{
    public interface IWeatherForecastService
    {
        Task<WeatherForecast?> GetCurrentWeatherAsync(double latitude, double longitude, string current, string hourly);
    }
}
