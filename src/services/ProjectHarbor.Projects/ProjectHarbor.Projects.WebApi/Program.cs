using Microsoft.EntityFrameworkCore;
using ProjectHarbor.Projects.Persistence;
using ProjectHarbor.Projects.WebApi.DependencyInjection;
using System.Text.Json;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options => options.SuppressAsyncSuffixInActionNames = false)
    .AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase)));

builder.Services.AddWebApi(builder.Configuration);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.UseWebApi();

if (IsRunningInContainer())
    MigrateDatabase(app);

app.Run();

static bool IsRunningInContainer()
{
    var isRunningInContainer = Environment.GetEnvironmentVariable("DOTNET_RUNNING_IN_CONTAINER") ?? "false";
    return bool.Parse(isRunningInContainer);
}

static void MigrateDatabase(WebApplication app)
{
    using var serviceScope = app.Services.CreateScope();
    var databaseContext = serviceScope.ServiceProvider.GetRequiredService<DatabaseContext>();
    databaseContext.Database.Migrate();
}
