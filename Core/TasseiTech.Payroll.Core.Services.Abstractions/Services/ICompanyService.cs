using TasseiTech.Payroll.Core.Contracts.Requests;
using TasseiTech.Payroll.Core.Contracts.Responses;

namespace TasseiTech.Payroll.Core.Services.Abstractions.Services;
public interface ICompanyService
{
    Task<CompanyResponse> GetByIdAsync(long id);
    Task<IList<CompanyListResponse>> GetAllAsync();
    Task InsertAsync(CreateCompany request);
    Task UpdateAsync(EditCompany request);
    Task DeleteAsync(long id);
}
