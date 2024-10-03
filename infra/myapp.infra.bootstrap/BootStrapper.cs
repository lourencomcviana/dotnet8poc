using Microsoft.Extensions.DependencyInjection;
using myapp.business;
using myapp.infra.proxy.weatherforecast;
using myapp.infra.repository.memory;

namespace myapp.infra.bootstrap;

public static class BootStrapper
{
    public static void ConfigureServices(this IServiceCollection services)
    {
        services.AddBusiness();
        services.AddPersonRepository();
        services.AddWeatherForecastApi();
    }

}
