using System.Collections.Generic;
using System.Threading.Tasks;
using TasseiTech.Sample.Core.Services.DTOs.Requests;
using TasseiTech.Sample.Core.Services.DTOs.Responses;

namespace TasseiTech.Sample.Core.Services.Abstractions;
public interface ICompanyService
{
    Task<CompanyResponse> GetByIdAsync(long id);
    Task<IList<CompanyListResponse>> GetAllAsync();
    Task InsertAsync(CreateCompany request);
    Task UpdateAsync(EditCompany request);
    Task DeleteAsync(long id);
}
