using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using MK.RequirementsApp.Application.Behaviours;
using System.Reflection;

namespace MK.RequirementsApp.Application.Extensions
{
    public static class Registrator
    {
        public static IServiceCollection RegisterApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            //services.AddAutoMapper(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
