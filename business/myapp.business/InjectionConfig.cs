using System.Reflection;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using myapp.business.Behaviours;
using myapp.business.Commands;
using myapp.business.mappings;
using myapp.business.services;
using myapp.business.validations;
using myapp.domain.services;

namespace myapp.business;

public static class InjectionConfig
{
    public static void AddBusiness(this IServiceCollection services)
    {
        services.AddTransient<IPersonService,PersonService>();
        services.AddTransient<IWeatherForecastService, WeatherForecastService>();
        
        services.AddAutoMapper(typeof(CreateUserToPerson));
        
        // mediatr
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        
        // fluent validations
        services.AddScoped<IValidator<CreateUserCommand>, GeneralCreateUserCommandValidator>();
        
        // pipeline behaviour
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ExceptionToHettpHandlerBehaviour<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehaviour<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(FluentValidationBehaviour<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(WeatherForecastSimulationBehaviour<,>));
        
    }
}