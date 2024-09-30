using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using myapp.domain.repositories;
using myapp.infra.repository.memory.mappings;
using myapp.infra.repository.memory.repositories;

namespace myapp.infra.repository.memory;

public static class InjectionConfig
{
    public static void AddPersonRepository(this IServiceCollection services)
    {
        // Register the DbContext with an in-memory database
        services.AddDbContext<AppDbContext>(options =>
            options.UseInMemoryDatabase("PersonDb"), ServiceLifetime.Scoped);
        services.AddTransient<IPersonRepository,PersonRepository>();
        
        services.AddAutoMapper(typeof(PersonMapper.PersonProfile));
    }
}