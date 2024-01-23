using FluentValidation.AspNetCore;
using ProjectHarbor.Projects.Application.DependencyInjection;
using ProjectHarbor.Projects.WebApi.Middlewares;

namespace ProjectHarbor.Projects.WebApi.DependencyInjection;

internal static class ServiceCollectionExtensions
{
    public static IServiceCollection AddWebApi(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddFluentValidationAutoValidation();

        services.AddScoped<ExceptionHandlerMiddleware>();

        services.AddApplication(configuration);

        return services;
    }
}