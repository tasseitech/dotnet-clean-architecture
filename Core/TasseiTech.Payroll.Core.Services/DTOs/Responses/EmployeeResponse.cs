using System;
using TasseiTech.Sample.Core.Domain.Enums;

namespace TasseiTech.Sample.Core.Services.DTOs.Responses;

public class EmployeeResponse
{
    public long Id { get; set; }
    public string Code { get; set; }
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public string LastName { get; set; }
    public GenderEnum? Gender { get; set; }
    public string CompanyEmail { get; set; }
    public string PersonalEmail { get; set; }
    public string MobileNo { get; set; }
    public DateOnly? DateOfBirth { get; set; }
}
