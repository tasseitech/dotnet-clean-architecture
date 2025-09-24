using System;
using System.Linq;
using Microsoft.AspNetCore.Http;
using TasseiTech.Sample.Core.Domain;
using TasseiTech.Sample.Core.Domain.Enums;
using TasseiTech.Sample.Core.Domain.Exceptions;

namespace TasseiTech.Sample.Core.Services;

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
