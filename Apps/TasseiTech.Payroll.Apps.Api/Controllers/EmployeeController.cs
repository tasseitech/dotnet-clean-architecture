using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TasseiTech.Payroll.Core.Contracts.Requests;
using TasseiTech.Payroll.Core.Contracts.Responses;
using TasseiTech.Payroll.Core.Services.Abstractions;
using TasseiTech.Payroll.Core.Services.Abstractions.Services;

namespace TasseiTech.Payroll.Apps.Api.Controllers;


/// <summary>
/// Represents an API controller for managing employees.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class EmployeeController(IEmployeeService employeeService) : ControllerBase
{
    /// <summary>
    /// Gets a list of all employees.
    /// </summary>
    /// <returns>The list of employees.</returns>
    /// <response code="200">Returns the list of employees.</response>
    [HttpGet]
    [ProducesResponseType(typeof(IList<EmployeeListResponse>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllAsync()
    {
        var employees = await employeeService.GetAllAsync();
        return Ok(employees);
    }
}
