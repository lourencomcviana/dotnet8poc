using Microsoft.Extensions.DependencyInjection;
using myapp.business.services;
using myapp.domain.services;
using myapp.infra.proxy.weatherforecast.adapters;

namespace myapp.business;

public static class InjectionConfig
{
    public static void AddBusiness(this IServiceCollection services)
    {
        services.AddTransient<IPersonService,PersonService>();
        services.AddTransient<IWeatherForecastService, WeatherForecastService>();
    }
}