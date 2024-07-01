using TasseiTech.Payroll.Core.Contracts.Requests;
using TasseiTech.Payroll.Core.Contracts.Responses;

namespace TasseiTech.Payroll.Core.Services.Abstractions.Services;
public interface IEmployeeService
{
    Task<EmployeeResponse> GetByIdAsync(long id);
    Task<IList<EmployeeListResponse>> GetAllAsync();
    Task InsertAsync(CreateEmployee request);
    Task UpdateAsync(EditEmployee request);
    Task DeleteAsync(long id);
}
