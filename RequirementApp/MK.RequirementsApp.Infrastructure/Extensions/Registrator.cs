using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MK.RequirementsApp.Application.Interfaces;
using MK.RequirementsApp.Infrastructure.Contexts;
using MK.RequirementsApp.Infrastructure.Repositories;
using MK.RequirementsApp.Infrastructure.UoW;
using System.Diagnostics;

namespace MK.RequirementsApp.Infrastructure.Extensions
{
    public static class Registrator
    {
        public static IServiceCollection RegisterInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.RegisterDbContext(configuration);
            services.RegisterRepositories();
            return services;
        }

        public static IServiceCollection RegisterDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<RequirementsContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("RequirementsPostgresDatabase")));
                //options.UseSqlServer("name=ConnectionStrings:RequirementsSQLDatabase"));
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
