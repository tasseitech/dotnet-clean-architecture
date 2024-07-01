using TasseiTech.Payroll.Core.Domain.Abstractions;
using TasseiTech.Payroll.Core.Domain.Entities;

namespace TasseiTech.Payroll.Infrastructure.Sql.Implementation;

public class EmployeeRepository(ApplicationContext context) : Repository<Employee>(context), IEmployeeRepository
{

}