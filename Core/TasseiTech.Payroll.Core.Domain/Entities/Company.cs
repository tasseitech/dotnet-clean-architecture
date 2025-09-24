using System.Collections.Generic;
using System.Linq;
using TasseiTech.Sample.Core.Domain.Enums;

namespace TasseiTech.Sample.Core.Domain.Entities;
public class Company : BaseEntity
{
    public Company()
    {
        Employees = new HashSet<Employee>();
    }

    public string Code { get; set; }
    public string Name { get; set; }
    public virtual ICollection<Employee> Employees { get; set; }
    public bool Initialize(string code, string name, out List<ErrorCodeEnum> errors)
    {
        errors = [];
        if (string.IsNullOrEmpty(code))
            errors.Add(ErrorCodeEnum.CodeRequired);
        if (code is { Length: > 10 })
            errors.Add(ErrorCodeEnum.CodeLength10);
        if (string.IsNullOrEmpty(name))
            errors.Add(ErrorCodeEnum.FirstNameRequired);
        if (name is { Length: > 50 })
            errors.Add(ErrorCodeEnum.LastNameLength50);

        if (errors.Any())
            return false;

        Code = code;
        Name = name;

        return true;
    }
}
