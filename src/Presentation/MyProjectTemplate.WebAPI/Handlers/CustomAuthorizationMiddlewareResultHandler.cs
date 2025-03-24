using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Policy;
using MyProjectTemplate.Domain.Results;

namespace MyProjectTemplate.WebAPI.Handlers;

public class CustomAuthorizationMiddlewareResultHandler : IAuthorizationMiddlewareResultHandler
{

    public async Task HandleAsync(RequestDelegate next, HttpContext context, AuthorizationPolicy policy,
        PolicyAuthorizationResult authorizeResult)
    {
        if (authorizeResult.Forbidden && authorizeResult.AuthorizationFailure!.FailureReasons.Count() > 0)
        {
            context.Response.StatusCode = 403;
            await context.Response.WriteAsJsonAsync(
                Result.Failure(Error.AccessForbidden("4030001", "Erişim İzniniz Yok.")));
            return;
        }

        if (!authorizeResult.Succeeded)
        {
            context.Response.StatusCode = 401;
            await context.Response.WriteAsJsonAsync(
                Result.Failure(Error.AccessUnAuthorized("4010001", "Giriş Yapılmalı.")));
            return;
        }

        if (authorizeResult.Succeeded)
            await next(context);
    }
}