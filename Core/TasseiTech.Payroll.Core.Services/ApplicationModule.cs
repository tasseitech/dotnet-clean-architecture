using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TasseiTech.Payroll.Core.Services.Abstractions.Services;
using TasseiTech.Payroll.Core.Services.Services;

namespace TasseiTech.Payroll.Core.Services
{
    public static class ApplicationModule
    {
        public static void AddApplicationModule(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<ICompanyService, CompanyService>();

        }
    }
}
