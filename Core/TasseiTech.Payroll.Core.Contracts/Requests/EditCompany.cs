
namespace TasseiTech.Payroll.Core.Contracts.Requests;

public class EditCompany : BaseEntityModel
{
    public string Code { get; set; }
    public string Name { get; set; }
}
