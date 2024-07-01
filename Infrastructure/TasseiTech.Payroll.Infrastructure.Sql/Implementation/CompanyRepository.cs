using TasseiTech.Payroll.Core.Domain.Abstractions;
using TasseiTech.Payroll.Core.Domain.Entities;

namespace TasseiTech.Payroll.Infrastructure.Sql.Implementation;

public class CompanyRepository(ApplicationContext context) : Repository<Company>(context), ICompanyRepository
{
}