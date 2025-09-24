using Microsoft.AspNetCore.Mvc;
using TasseiTech.Sample.Core.Services.Abstractions;
using TasseiTech.Sample.Core.Services.DTOs.Requests;
using TasseiTech.Sample.Core.Services.DTOs.Responses;

namespace TasseiTech.Sample.Apps.Api.Controllers;

/// <summary>
/// Represents an API controller for managing companies.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class CompanyController(ICompanyService companyService) : ControllerBase
{
    /// <summary>
    /// Gets a list of all companies.
    /// </summary>
    /// <returns>A collection of companies.</returns>
    /// <response code="200">Returns the list of companies.</response>
    [HttpGet]
    [ProducesResponseType(typeof(IList<CompanyListResponse>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllAsync()
    {
        var companies = await companyService.GetAllAsync();
        return Ok(companies);
    }

    /// <summary>
    /// Gets a specific company by its ID.
    /// </summary>
    /// <param name="id">The ID of the company to retrieve.</param>
    /// <returns>The specified company.</returns>
    /// <response code="200">Returns the specified company.</response>
    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(CompanyResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetByIdAsync(long id)
    {
        var company = await companyService.GetByIdAsync(id);
        return Ok(company);
    }

    /// <summary>
    /// Inserts a new company.
    /// </summary>
    /// <param name="model">The data representing the new company.</param>
    /// <returns>The newly created company has been successfully inserted.</returns>
    /// <response code="200">The new company has been successfully inserted.</response>
    [HttpPost]
    [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
    public async Task<IActionResult> InsertAsync([FromBody] CreateCompany model)
    {
        await companyService.InsertAsync(model);
        return Ok();
    }

    /// <summary>
    /// Updates an existing company.
    /// </summary>
    /// <param name="model">The data representing the updated company.</param>
    /// <returns>The company has been successfully updated.</returns>
    /// <response code="200">The company has been successfully updated.</response>
    [HttpPut]
    [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
    public async Task<IActionResult> UpdateAsync([FromBody] EditCompany model)
    {
        await companyService.UpdateAsync(model);
        return Ok();
    }

    /// <summary>
    /// Deletes a company by its ID.
    /// </summary>
    /// <param name="id">The ID of the company to delete.</param>
    /// <returns>The company has been successfully deleted.</returns>
    /// <response code="200">The company has been successfully deleted.</response>
    [HttpDelete]
    [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
    public async Task<IActionResult> DeleteAsync(long id)
    {
        await companyService.DeleteAsync(id);
        return Ok();
    }
}
