using System;
using TasseiTech.Payroll.Core.Entities.Enums;

namespace TasseiTech.Payroll.Core.Contracts.Requests;

public class EditEmployee : BaseEntityModel
{
    public string Code { get; set; }
    public string FirstName { get; set; }
    public string? MiddleName { get; set; }
    public string LastName { get; set; }
    public GenderEnum? Gender { get; set; }
    public string CompanyEmail { get; set; }
    public string PersonalEmail { get; set; }
    public string? MobileNo { get; set; }
    public DateOnly? DateOfBirth { get; set; }
}
