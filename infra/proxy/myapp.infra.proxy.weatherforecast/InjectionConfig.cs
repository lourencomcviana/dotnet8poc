using Microsoft.Extensions.DependencyInjection;
using myapp.infra.proxy.weatherforecast.clients;
using Refit;

namespace myapp.infra.proxy.weatherforecast;

public static class InjectionConfig
{
    public static void AddWeatherForecastApi(this IServiceCollection services)
    {
        services.AddRefitClient<IWeatherApi>()
            .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://api.open-meteo.com"));

    }
}