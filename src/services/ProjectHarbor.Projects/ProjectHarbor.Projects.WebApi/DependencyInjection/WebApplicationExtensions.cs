using ProjectHarbor.Projects.WebApi.Middlewares;

namespace ProjectHarbor.Projects.WebApi.DependencyInjection;

public static class WebApplicationExtensions
{
    public static void UseWebApi(this WebApplication app)
    {
        app.UseMiddleware<ExceptionHandlerMiddleware>();
    }
}
