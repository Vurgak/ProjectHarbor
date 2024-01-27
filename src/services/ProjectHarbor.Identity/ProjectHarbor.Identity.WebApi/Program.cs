using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProjectHarbor.Identity.WebApi.Models;
using ProjectHarbor.Identity.WebApi.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(IdentityConstants.ApplicationScheme)
	.AddIdentityCookies();
builder.Services.AddAuthorizationBuilder();

builder.Services.AddDbContext<DatabaseContext>(
	options => options.UseSqlServer("Database"));

builder.Services.AddIdentityCore<User>()
	.AddEntityFrameworkStores<DatabaseContext>()
	.AddApiEndpoints();

builder.Services.AddControllers();

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

app.Run();
