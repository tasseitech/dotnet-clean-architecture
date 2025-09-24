using TasseiTech.Sample.Core.Domain.Abstractions;
using TasseiTech.Sample.Core.Domain.Entities;
using TasseiTech.Sample.Infrastructure.Sql;

namespace TasseiTech.Sample.Infrastructure.Sql.Implementation;

public class CompanyRepository(ApplicationContext context) : Repository<Company>(context), ICompanyRepository
{
}