using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using TasseiTech.Sample.Core.Domain.Abstractions;
using TasseiTech.Sample.Core.Domain.Entities;
using TasseiTech.Sample.Core.Domain.Enums;
using TasseiTech.Sample.Core.Domain.Exceptions;
using TasseiTech.Sample.Core.Services.Abstractions;
using TasseiTech.Sample.Core.Services.DTOs.Requests;
using TasseiTech.Sample.Core.Services.DTOs.Responses;

namespace TasseiTech.Sample.Core.Services.Services;
public class EmployeeService(IEmployeeRepository employeeRepository,
    ILogger<EmployeeService> logger) : IEmployeeService
{
    public async Task<EmployeeResponse> GetByIdAsync(long id)
    {
        var employee = await employeeRepository.GetByIdAsync(id)
                       ?? throw new BusinessRuleException(1, ErrorCodeEnum.RecordNotFound.ToJsonString());
        var response = new EmployeeResponse
        {
            Id = employee.Id,
            Code = employee.Code,
            FirstName = employee.FirstName,
            MiddleName = employee.MiddleName,
            LastName = employee.LastName,
            Gender = employee.Gender,
            CompanyEmail = employee.CompanyEmail,
            PersonalEmail = employee.PersonalEmail,
            MobileNo = employee.MobileNo,
            DateOfBirth = employee.DateOfBirth,
        };
        logger.LogInformation("Retrieved employee by Id: {id}", id);
        return response;
    }

    public async Task<IList<EmployeeListResponse>> GetAllAsync()
    {
        var employees = await employeeRepository.GetAllAsync()
                        ?? throw new BusinessRuleException(1, ErrorCodeEnum.RecordNotFound.ToJsonString());
        var responses = employees.Select(e => new EmployeeListResponse
        {
            Id = e.Id,
            Code = e.Code,
            FirstName = e.FirstName,
            LastName = e.LastName,
        }).ToList();
        logger.LogInformation("Retrieved all employees.");
        return responses;
    }

    public async Task InsertAsync(CreateEmployee request)
    {
        var employee = new Employee();

        var isSuccess = employee.Initialize(request.FirstName, request.LastName,
            request.CompanyEmail, request.JobTitle,
            out var errors);
        if (isSuccess)
        {
            await employeeRepository.InsertAsync(employee);
            logger.LogInformation("Inserted new employee with Id: {EmployeeId}", employee.Id);
        }
        else
            throw new BusinessRuleException(1, errors.ToJsonArray());
    }

    public async Task UpdateAsync(EditEmployee request)
    {
        var employee = await employeeRepository.GetByIdAsync(request.Id)
            ?? throw new BusinessRuleException(1, ErrorCodeEnum.InvalidEmployee.ToJsonString());

        var isSuccess = employee.EditDetails(request.Code, request.FirstName, request.MiddleName, request.LastName, request.Gender, request.CompanyEmail, request.DateOfBirth, out var errors);

        if (isSuccess)
        {
            await employeeRepository.UpdateAsync(employee);
            logger.LogInformation("Updated employee with Id: {id}", employee.Id);
        }
        else
            throw new BusinessRuleException(1, errors.ToJsonArray());
    }

    public async Task DeleteAsync(long id)
    {
        var employee = await employeeRepository.GetByIdAsync(id)
            ?? throw new BusinessRuleException(1, ErrorCodeEnum.InvalidEmployee.ToJsonString());

        await employeeRepository.DeleteAsync(employee);
        logger.LogInformation("Deleted employee with Id: {id}", id);
    }
}

