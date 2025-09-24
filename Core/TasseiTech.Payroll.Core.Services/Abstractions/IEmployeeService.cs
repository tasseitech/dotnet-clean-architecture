using System.Collections.Generic;
using System.Threading.Tasks;
using TasseiTech.Sample.Core.Services.DTOs.Requests;
using TasseiTech.Sample.Core.Services.DTOs.Responses;

namespace TasseiTech.Sample.Core.Services.Abstractions;
public interface IEmployeeService
{
    Task<EmployeeResponse> GetByIdAsync(long id);
    Task<IList<EmployeeListResponse>> GetAllAsync();
    Task InsertAsync(CreateEmployee request);
    Task UpdateAsync(EditEmployee request);
    Task DeleteAsync(long id);
}
