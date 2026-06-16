using Tekus.Api.Middlewares;

namespace Tekus.Api.Extensions;

public static class MiddlewareExtensions
{
    public static IApplicationBuilder
        UseGlobalExceptionHandling(
            this IApplicationBuilder app)
    {
        return app.UseMiddleware<
            ExceptionHandlingMiddleware>();
    }
}