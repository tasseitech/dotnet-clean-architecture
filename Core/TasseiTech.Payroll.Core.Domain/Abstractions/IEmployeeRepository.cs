using System.Collections.Generic;
using System.Threading.Tasks;
using TasseiTech.Payroll.Core.Domain.Entities;

namespace TasseiTech.Payroll.Core.Domain.Abstractions;

public interface IEmployeeRepository : IRepository<Employee>
{
}