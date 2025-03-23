using MediatR;

namespace MyProjectTemplate.Application.Messaging;

public interface IQuery<out TResponse> : IRequest<TResponse>
{
    
}