using FluentValidation;
using MediatR;
using myapp.util.exceptions;

namespace myapp.business.Behaviours;

public class ExceptionToHettpHandlerBehaviour<TRequest, TResponse>(IEnumerable<IValidator<TRequest>> validators)
    : IPipelineBehavior<TRequest, TResponse>
{


    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        try
        {
            return await next();
        }
        catch (ValidationException ex)
        {
            throw new InvalidParametersException(ex.Message, ex, 400);
        }
        catch (Exception ex)
        {
            throw new InvalidParametersException(ex.Message, ex, 500);
        }
    }
}