using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using myapp.business.services;
using myapp.domain.services;
using myapp.infra.repository.memory;

namespace myapp.infra.bootstrap;

public static class BootStrapper
{
    public static void ConfigureServices(this IServiceCollection services)
    {
        services.AddTransient<IPersonService,PersonService>();
        services.AddPersonRepository();
    }

}
