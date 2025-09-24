using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using TasseiTech.Sample.Core.Domain.Enums;

namespace TasseiTech.Sample.Core.Domain.Entities;

public class Employee : BaseEntity
{
    public string Code { get; set; }
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public string LastName { get; set; }
    public GenderEnum? Gender { get; set; }
    public string CompanyEmail { get; set; }
    public string PersonalEmail { get; set; }
    public string MobileNo { get; set; }
    public DateOnly? DateOfBirth { get; set; }
    public virtual Company Company { get; set; }

    public bool Initialize(string firstName, string lastName, string companyEmail, string jobTitle,
        out List<ErrorCodeEnum> errors)
    {
        errors = [];
        CommonValidation(firstName, lastName, companyEmail, errors);

        if (errors.Any())
            return false;

        return true;
    }

    public bool EditDetails(string code, string firstName, string middleName, string lastName,
        GenderEnum? gender, string companyEmail, DateOnly? dateOfBirth, out List<ErrorCodeEnum> errors)
    {
        errors = [];
        CommonValidation(firstName, lastName, companyEmail, errors);

        if (middleName is { Length: > 50 })
            errors.Add(ErrorCodeEnum.MiddleNameLength50);
        if (code is { Length: > 10 })
            errors.Add(ErrorCodeEnum.CodeLength10);
        if (errors.Any())
            return false;

        Gender = gender;
        DateOfBirth = dateOfBirth;
        Code = code;
        MiddleName = middleName;

        return true;
    }

    private void CommonValidation(string firstName, string lastName, string companyEmail, List<ErrorCodeEnum> errors)
    {
        if (string.IsNullOrEmpty(firstName))
            errors.Add(ErrorCodeEnum.FirstNameRequired);
        if (firstName is { Length: > 50 })
            errors.Add(ErrorCodeEnum.FirstNameLength50);
        if (string.IsNullOrEmpty(lastName))
            errors.Add(ErrorCodeEnum.LastNameRequired);
        if (lastName is { Length: > 50 })
            errors.Add(ErrorCodeEnum.LastNameLength50);
        if (companyEmail is { Length: > 255 })
            errors.Add(ErrorCodeEnum.CompanyEmailLength255);
        if (string.IsNullOrEmpty(companyEmail))
            errors.Add(ErrorCodeEnum.CompanyEmailRequired);
        else
        {
            if (!IsValidEmail(companyEmail))
                errors.Add(ErrorCodeEnum.InvalidCompanyEmailAddress);
        }

        if (errors.Any()) return;

        FirstName = firstName;
        LastName = lastName;
        CompanyEmail = companyEmail;
    }

    private bool IsValidEmail(string email)
    {
        return new EmailAddressAttribute().IsValid(email);
    }
}