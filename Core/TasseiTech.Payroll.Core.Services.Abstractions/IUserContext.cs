
namespace TasseiTech.Payroll.Core.Services.Abstractions;

public interface IUserContext
{
    public long UserId { get; }
    public long CompanyId { get; }
}
