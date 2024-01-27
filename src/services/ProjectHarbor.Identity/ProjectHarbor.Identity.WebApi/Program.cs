using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ProjectHarbor.Identity.WebApi.Models;
using ProjectHarbor.Identity.WebApi.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(IdentityConstants.ApplicationScheme)
	.AddIdentityCookies();
builder.Services.AddAuthorizationBuilder();

var databaseConnectionString = builder.Configuration.GetConnectionString("Database");
builder.Services.AddDbContext<DatabaseContext>(
	options => options.UseSqlServer(databaseConnectionString));

builder.Services.AddIdentityCore<User>()
	.AddEntityFrameworkStores<DatabaseContext>()
	.AddApiEndpoints();

builder.Services.AddControllers();

builder.Services.AddCors(options => options.AddPolicy("AllowAll", builder => builder
		.SetIsOriginAllowed(_ => true)
		.AllowAnyMethod()
		.AllowAnyHeader()
		.AllowCredentials()));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.MapIdentityApi<User>();

app.UseCors("AllowAll");

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
