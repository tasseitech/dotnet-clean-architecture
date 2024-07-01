using TasseiTech.Payroll.Core.Contracts.Responses;

namespace TasseiTech.Payroll.Core.Services.Abstractions.Services;

public interface ICountryService
{
    Task<IList<ListItem>> GetAllAsync();
}
