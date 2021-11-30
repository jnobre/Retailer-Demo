using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Retailer.Demo.CustomerAccounts.Application;
using Retailer.Demo.CustomerAccounts.Application.Queries;

namespace Retailer.Demo.CustomerAccounts.DependencyResolution
{
    public static class ApplicationDependencies
    {
        public static void ResolveApplicationDependencies(this IServiceCollection services)
        {
            services.AddMediatR(typeof(GetAllUserQuery));
            services.AddAutoMapper(typeof(GetAllUserQuery));
            services.AddValidatorsFromAssembly(typeof(GetAllUserQuery).Assembly);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        }
    }
}
