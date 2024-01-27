using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjectHarbor.Identity.WebApi.Models;

namespace ProjectHarbor.Identity.WebApi.Persistence;

public class DatabaseContext(DbContextOptions options) : IdentityDbContext<User>(options);
