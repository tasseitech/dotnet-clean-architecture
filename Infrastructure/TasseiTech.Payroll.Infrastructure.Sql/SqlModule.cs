using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TasseiTech.Sample.Core.Domain.Abstractions;
using TasseiTech.Sample.Infrastructure.Sql.Implementation;

namespace TasseiTech.Sample.Infrastructure.Sql;
public static class SqlModule
{
    public static void AddSqlModule(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        services.AddScoped<ICompanyRepository, CompanyRepository>();

    }
}
