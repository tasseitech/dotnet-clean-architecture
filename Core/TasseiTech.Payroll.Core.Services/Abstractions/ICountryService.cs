using System.Collections.Generic;
using System.Threading.Tasks;
using TasseiTech.Sample.Core.Services.DTOs.Responses;

namespace TasseiTech.Sample.Core.Services.Abstractions;

public interface ICountryService
{
    Task<IList<ListItem>> GetAllAsync();
}
