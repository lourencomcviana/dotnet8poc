using Microsoft.Extensions.DependencyInjection;
using myapp.infra.proxy.weatherforecast.adapters;
using myapp.infra.proxy.weatherforecast.clients;
using myapp.infra.proxy.weatherforecast.mappings;
using Refit;

namespace myapp.infra.proxy.weatherforecast;

public static class InjectionConfig
{
    public static void AddWeatherForecastApi(this IServiceCollection services)
    {
        services.AddRefitClient<IWeatherApi>()
            .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://api.open-meteo.com"));

        services.AddTransient<IWeatherApiAdapter, WeatherApiAdapter>();

        services.AddAutoMapper(typeof(WeatherMapper.WeatherProfile));
    }
}