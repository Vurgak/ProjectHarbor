using FluentValidation;
using ProjectHarbor.Projects.WebApi.ViewModels;
using System.Net;

namespace ProjectHarbor.Projects.WebApi.Middlewares;

internal class ExceptionHandlerMiddleware(ILogger<ExceptionHandlerMiddleware> logger) : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception exception)
        {
            logger.LogError(exception, "Unhandled exception");

            switch (exception)
            {
                case ValidationException:
                    throw;

                default:
                    await WriteErrorResponseAsync(context, HttpStatusCode.InternalServerError, "Internal server error");
                    break;
            };
        }
    }

    private async Task WriteErrorResponseAsync(HttpContext context, HttpStatusCode statusCode, string message)
    {
        context.Response.StatusCode = (int)statusCode;
        await context.Response.WriteAsJsonAsync(new ErrorViewModel(message));
    }
}
