using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TasseiTech.Sample.Core.Services.Abstractions;
using TasseiTech.Sample.Core.Services.Services;

namespace TasseiTech.Sample.Core.Services
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
