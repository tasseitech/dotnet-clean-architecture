using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TasseiTech.Sample.Core.Domain.Entities;

namespace TasseiTech.Sample.Infrastructure.Sql.Configurations;
public class EmployeeConfig
{
    public EmployeeConfig(EntityTypeBuilder<Employee> entityBuilder)
    {
        entityBuilder.ToTable("Employee", "Employee");
        entityBuilder.Property(p => p.MiddleName).IsRequired(false);
        entityBuilder.Property(p => p.Gender).IsRequired(false).HasConversion<int>();
    }
}
