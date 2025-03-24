using Microsoft.AspNetCore.Diagnostics;
using MyProjectTemplate.Domain.Results;

namespace MyProjectTemplate.WebAPI.Handlers;

public class ExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        //bilinmeyen hata
        
        httpContext.Response.StatusCode = 500;
        await httpContext.Response.WriteAsJsonAsync(ResultT<string>.Failure(Error.Failure("500001", exception.Message)));
        return true;
    }
}