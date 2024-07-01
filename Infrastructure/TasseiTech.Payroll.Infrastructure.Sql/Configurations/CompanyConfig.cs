using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TasseiTech.Payroll.Core.Domain.Entities;

namespace TasseiTech.Payroll.Infrastructure.Sql.Configurations;

public class CompanyConfig
{
    public CompanyConfig(EntityTypeBuilder<Company> entityBuilder)
    {
        entityBuilder.Property(p => p.Code).IsRequired();
        entityBuilder.Property(p => p.Name).IsRequired();
    }
}
