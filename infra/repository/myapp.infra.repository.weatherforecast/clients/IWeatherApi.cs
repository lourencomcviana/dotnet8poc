using myapp.infra.repository.weatherforecast.resources;

namespace myapp.infra.repository.weatherforecast.clients;

using Refit;
using System.Threading.Tasks;

public interface IWeatherApi
{
    [Get("/v1/forecast")]
    Task<WeatherResponse> GetWeatherForecastAsync(
        [Query] double latitude,
        [Query] double longitude,
        [Query] string current,
        [Query] string hourly);
}
