using MediatR;

namespace MyProjectTemplate.Application.Messaging;

public interface ICommand<out TResponse> : IRequest<TResponse>
{
    
}

public interface ICommand : IRequest
{
    
}