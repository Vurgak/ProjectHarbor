using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("ocelot.json", false, true);

builder.Services.AddOcelot();

var app = builder.Build();

app.UseHttpsRedirection();

await app.UseOcelot();

app.Run();
