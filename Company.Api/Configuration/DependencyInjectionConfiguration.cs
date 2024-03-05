using CompanyApi.Data.Configuration;
using CompanyApi.Data.Interface;
using CompanyApi.Data.Repositiorio;
using CompanyApi.Service.Interface;
using CompanyApi.Service.Service;

namespace CompanyApi.Api.Configuration
{
    public static class DependencyInjectionConfiguration
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<ApplicationDbContext>();


            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<ICompanyService, CompanyService>();



            return services;
        }
    }
}
