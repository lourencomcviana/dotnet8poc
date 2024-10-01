using Microsoft.Extensions.DependencyInjection;
using myapp.business.services;
using myapp.domain.services;

namespace myapp.business;

public static class InjectionConfig
{
    public static void AddBusiness(this IServiceCollection services)
    {
        services.AddTransient<IPersonService,PersonService>();
    }
}