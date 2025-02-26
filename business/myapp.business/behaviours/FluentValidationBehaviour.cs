using FluentValidation;
using MediatR;

namespace myapp.business.Behaviours;

public class FluentValidationBehaviour<TRequest, TResponse>(IEnumerable<IValidator<TRequest>> validators)
    : IPipelineBehavior<TRequest, TResponse>
{


    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        
        var context = new ValidationContext<TRequest>(request);
        var failures = validators
            .Select(v => v.Validate(context))
            .SelectMany(result => result.Errors)
            .Where(error => error != null)
            .ToList();
        if (failures.Any())
        {
            throw new ValidationException(failures);
        }
        return await next();
    }
}