using Microsoft.AspNetCore.Mvc;
using TasseiTech.Sample.Core.Services.Abstractions;
using TasseiTech.Sample.Core.Services.DTOs.Responses;

namespace TasseiTech.Sample.Apps.Api.Controllers;


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
