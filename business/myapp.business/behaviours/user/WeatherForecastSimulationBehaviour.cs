using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;
using myapp.business.Commands;
using myapp.domain.models;
using myapp.domain.services;
using ValidationException = System.ComponentModel.DataAnnotations.ValidationException;

namespace myapp.business.Behaviours;

public class WeatherForecastSimulationBehaviour<TRequest, TResponse>(IWeatherForecastService wheatherForecastService, ILogger<WeatherForecastSimulationBehaviour<TRequest, TResponse>> logger)
    : IPipelineBehavior<CreateUserCommand, TResponse>
{


    public async Task<TResponse> Handle(CreateUserCommand request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        try
        {
            var res = await wheatherForecastService.GetCurrentWeatherAsync(-23.6354044, -46.6449888,
                "temperature_2m,wind_speed_10m", "temperature_2m,relative_humidity_2m,wind_speed_10m");
            logger.LogInformation("testing logging forecast as behaviour, need good forecast to create a user " +
                                  res.TemperatureF);

            if (res.TemperatureF < -50)
            {
                throw new ValidationException("it is too cold to create a user");
            }

            if (res.TemperatureF > 300)
            {
                throw new ValidationException("it is too hot to create a user");
            }
        }
        catch (Refit.ApiException e)
        {
            request.Validation = "could not evaluate time correctly...";
        }
        return await next();
    }
}