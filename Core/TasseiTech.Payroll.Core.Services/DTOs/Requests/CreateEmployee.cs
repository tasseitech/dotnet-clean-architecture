using System;

namespace TasseiTech.Sample.Core.Services.DTOs.Requests;

public class CreateEmployee
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string CompanyEmail { get; set; }
    public long CountryId { get; set; }
    public DateOnly StartDate { get; set; }
    public string JobTitle { get; set; }

}
