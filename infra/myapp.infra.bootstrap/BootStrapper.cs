using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using myapp.business;
using myapp.domain.configurations;
using myapp.infra.proxy.weatherforecast;
using myapp.infra.repository.memory;
using myapp.util.exceptions;

namespace myapp.infra.bootstrap;

public static class BootStrapper
{
    public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
    {
        // add Configuration as a dependency
        services.Configure<WeatherForecastOptions>(
            WeatherForecastOptions.GetConfigurationHelper()
                .GetSection(configuration)
                .OrElseThrow(() => new InvalidConfigurationException(typeof(WeatherForecastOptions))
            ));
        services.AddBusiness();
        services.AddPersonRepository();
        services.AddWeatherForecastApi(configuration);
    }
}
