
using MK.RequirementsApp.BlazorUI.Interfaces;
using MK.RequirementsApp.BlazorUI.Services;

namespace MK.RequirementsApp.BlazorUI.Extensions
{
    public static class Registrator
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICompanyService, CompanyService>();
            return services;
        }
    }
}
