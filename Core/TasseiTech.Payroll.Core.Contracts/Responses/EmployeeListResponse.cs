namespace TasseiTech.Payroll.Core.Contracts.Responses;

public class EmployeeListResponse
{
    public long Id { get; set; }
    public string Code { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string JobTitle { get; set; }
}
