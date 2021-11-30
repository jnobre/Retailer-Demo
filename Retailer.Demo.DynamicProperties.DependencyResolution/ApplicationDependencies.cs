using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Retailer.Demo.DynamicProperties.Application;
using Retailer.Demo.DynamicProperties.Application.Commands;

namespace Retailer.Demo.DynamicProperties.DependencyResolution
{
    public static class ApplicationDependencies
    {
        public static void ResolveApplicationDependencies(this IServiceCollection services)
        {
            services.AddMediatR(typeof(CreateDynamicPropertyCommand));
            services.AddAutoMapper(typeof(CreateDynamicPropertyCommand));
            services.AddValidatorsFromAssembly(typeof(CreateDynamicPropertyCommand).Assembly);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        }
    }
}