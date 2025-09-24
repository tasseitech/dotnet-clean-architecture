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
public class CompanyService(ICompanyRepository companyRepository,
    ILogger<CompanyService> logger) : ICompanyService
{
    public async Task<CompanyResponse> GetByIdAsync(long id)
    {
        var company = await companyRepository.GetByIdAsync(id)
                      ?? throw new BusinessRuleException(1, ErrorCodeEnum.RecordNotFound.ToJsonString());
        var response = new CompanyResponse
        {
            Id = company.Id,
            Code = company.Code,
            Name = company.Name
        };
        logger.LogInformation("Retrieved company by Id: {id}", id);
        return response;
    }

    public async Task<IList<CompanyListResponse>> GetAllAsync()
    {
        var companies = await companyRepository.GetAllAsync()
                        ?? throw new BusinessRuleException(1, ErrorCodeEnum.RecordNotFound.ToJsonString());
        var responses = companies.Select(c => new CompanyListResponse
        {
            Code = c.Code,
            Name = c.Name
        }).ToList();
        logger.LogInformation("Retrieved all companies.");
        return responses;
    }

    public async Task InsertAsync(CreateCompany request)
    {
        var company = new Company();
        var isSuccess = company.Initialize(request.Code, request.Name, out var errors);
        if (isSuccess)
        {
            await companyRepository.InsertAsync(company);
            logger.LogInformation("Inserted new company with Id: {id}", company.Id);
        }
        else
            throw new BusinessRuleException(1, errors.ToJsonArray());
    }

    public async Task UpdateAsync(EditCompany request)
    {
        var company = await companyRepository.GetByIdAsync(request.Id)
                      ?? throw new BusinessRuleException(1, ErrorCodeEnum.RecordNotFound.ToJsonString());
        var isSuccess = company.Initialize(request.Code, request.Name, out var errors);
        if (isSuccess)
        {
            await companyRepository.UpdateAsync(company);
            logger.LogInformation("Updated company with Id: {id}", company.Id);
        }
        else
            throw new BusinessRuleException(1, errors.ToJsonArray());
    }

    public async Task DeleteAsync(long id)
    {
        var company = await companyRepository.GetByIdAsync(id)
                      ?? throw new BusinessRuleException(1, ErrorCodeEnum.RecordNotFound.ToJsonString());
        await companyRepository.DeleteAsync(company);
        logger.LogInformation("Deleted Company with Id: {id}", id);
    }
}
