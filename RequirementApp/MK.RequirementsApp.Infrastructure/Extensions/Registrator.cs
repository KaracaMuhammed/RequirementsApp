using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MK.RequirementsApp.Application.Interfaces;
using MK.RequirementsApp.Infrastructure.Contexts;
using MK.RequirementsApp.Infrastructure.Repositories;
using MK.RequirementsApp.Infrastructure.UoW;

namespace MK.RequirementsApp.Infrastructure.Extensions
{
    public static class Registrator
    {
        public static IServiceCollection RegisterInfrastructure(this IServiceCollection services)
        {
            services.RegisterDbContext();
            services.RegisterRepositories();
            return services;
        }
        public static IServiceCollection RegisterDbContext(this IServiceCollection services)
        {
            services.AddDbContext<RequirementsContext>(options => 
                options.UseSqlServer("name=ConnectionStrings:RequirementsDatabase"));
            return services;
        }

        public static IServiceCollection RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<IProductsRepository, ProductsRepository>();
            services.AddScoped<ICompaniesRepository, CompaniesRepository>();
            services.AddScoped<IImagesRepository, ImagesRepository>();
            services.AddScoped<IUnitofWork, UnitofWork>();
            return services;
        }
    }
}
