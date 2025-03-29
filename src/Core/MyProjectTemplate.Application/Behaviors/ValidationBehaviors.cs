using FluentValidation;
using FluentValidation.Results;
using MediatR;
using MyProjectTemplate.Application.Messaging;
using MyProjectTemplate.Domain.Exceptions;

namespace MyProjectTemplate.Application.Behaviors;

public sealed class ValidationBehaviors<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : class, ICommand<TResponse>
{
    private readonly IEnumerable<IValidator<TResponse>> _validators;

    public ValidationBehaviors(IEnumerable<IValidator<TResponse>> validators)
    {
        _validators = validators;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        if (!_validators.Any())
            return await next();

        var context = new ValidationContext<TRequest>(request);
        var errorDictionary = _validators.Select(x => x.Validate(context))
            .SelectMany(x => x.Errors)
            .Where(x => x is not null)
            .GroupBy(x => x.PropertyName, x => x.ErrorMessage, (propertyName, errorMessage) => new
            {
                Key = propertyName,
                Values = errorMessage.Distinct().ToArray()
            })
            .ToDictionary(x => x.Key, x => x.Values[0]);

        if (errorDictionary.Any())
            throw new BadRequestException("400", errorDictionary.First().Value);

        return await next();
    }
}