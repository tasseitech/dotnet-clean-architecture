using System.Collections.Generic;
using System.Threading.Tasks;
using TasseiTech.Sample.Core.Domain.Entities;

namespace TasseiTech.Sample.Core.Domain.Abstractions;

public interface IEmployeeRepository : IRepository<Employee>
{
}