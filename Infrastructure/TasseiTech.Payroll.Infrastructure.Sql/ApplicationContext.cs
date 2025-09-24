using Microsoft.EntityFrameworkCore;
using TasseiTech.Sample.Core.Domain.Entities;
using TasseiTech.Sample.Infrastructure.Sql.Configurations;

namespace TasseiTech.Sample.Infrastructure.Sql;
public class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
    }

    public new virtual DbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity
    {
        return base.Set<TEntity>();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        new EmployeeConfig(modelBuilder.Entity<Employee>());
    }
}
