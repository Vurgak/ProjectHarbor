using Microsoft.EntityFrameworkCore;
using ProjectHarbor.Projects.Persistence.Entities;

namespace ProjectHarbor.Projects.Persistence;

public class DatabaseContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<ProjectEntity> Projects { get; set; } = null!;

    public override int SaveChanges()
    {
        OnSaveChanges();
        return base.SaveChanges();
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken)
    {
        OnSaveChanges();
        return base.SaveChangesAsync(cancellationToken);
    }

    private void OnSaveChanges()
    {
        foreach (var entry in ChangeTracker.Entries<ProjectEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedAt = DateTime.Now;
                    break;

                case EntityState.Modified:
                    entry.Entity.ModifiedAt = DateTime.Now;
                    break;
            }
        }
    }
}
