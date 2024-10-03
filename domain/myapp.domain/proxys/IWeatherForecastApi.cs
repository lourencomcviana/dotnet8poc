using myapp.domain.models;

namespace myapp.domain.proxys;

public interface IWeatherForecastApi
{
   public WeatherForecast GetCurrentWeather();
}