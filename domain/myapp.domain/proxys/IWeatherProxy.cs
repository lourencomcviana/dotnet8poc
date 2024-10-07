using myapp.domain.models;

namespace myapp.domain.proxys
{
    public interface IWeatherProxy
    {
        public Task<WeatherForecast?> GetCurrentWeatherAsync(double latitude, double longitude, string current, string hourly);
    }
}
