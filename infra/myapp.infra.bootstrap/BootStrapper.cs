using Microsoft.Extensions.DependencyInjection;
using myapp.business.services;
using myapp.domain.services;

namespace myapp.infra.bootstrap;

public class BootStrapper
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddScoped<IPersonService, PersonService>();  
    }

}
