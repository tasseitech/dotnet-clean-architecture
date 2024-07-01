using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using TasseiTech.Payroll.Core.Contracts.Utilites;
using TasseiTech.Payroll.Core.Domain.Enums;
using TasseiTech.Payroll.Core.Domain.Exceptions;
using TasseiTech.Payroll.Core.Services.Abstractions;

namespace TasseiTech.Payroll.Core.Services;

public class UserContext(IHttpContextAccessor httpContextAccessor) : IUserContext
{
    public long UserId
    {
        get
        {
            var userId = (httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == "UserId")?.Value)
                ?? throw new BusinessRuleException(1, ErrorCodeEnum.RecordNotFound.ToJsonString());
            return Convert.ToInt64(userId);
        }
    }
    public long CompanyId
    {
        get
        {
            var companyId = (httpContextAccessor.HttpContext.User.Claims
                .FirstOrDefault(c => c.Type == "CompanyId")?.Value)
                ?? throw new BusinessRuleException(1, ErrorCodeEnum.RecordNotFound.ToJsonString());
            return Convert.ToInt64(companyId);
        }
    }
}
