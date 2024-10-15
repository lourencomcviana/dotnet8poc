using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using myapp.domain.configurations;
using myapp.infra.proxy.weatherforecast.adapters;
using myapp.infra.proxy.weatherforecast.clients;
using myapp.infra.proxy.weatherforecast.mappings;
using myapp.util;
using myapp.util.exceptions;
using Refit;

namespace myapp.infra.proxy.weatherforecast;

public static class InjectionConfig
{
    public static void AddWeatherForecastApi(this IServiceCollection services, IConfiguration configuration)
    {
        
        var options = WeatherForecastOptions
            .GetConfigurationHelper()
            .Get(configuration)
            .OrElseThrow(() => new InvalidConfigurationException(typeof(WeatherForecastOptions)));
        
        services.AddRefitClient<IWeatherApi>()
            .ConfigureHttpClient(c => c.BaseAddress = new Uri(options.Url));

        services.AddTransient<IWeatherApiAdapter, WeatherApiAdapter>();

        services.AddAutoMapper(typeof(WeatherMapper.WeatherProfile));
        
        
    }
}