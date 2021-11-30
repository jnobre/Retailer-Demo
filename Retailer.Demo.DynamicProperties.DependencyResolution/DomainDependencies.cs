using Microsoft.Extensions.DependencyInjection;
using Retailer.Demo.DynamicProperties.Domain.Repositories;
using Retailer.Demo.DynamicProperties.Domain.Repositories.Implementations;
using Retailer.Demo.DynamicProperties.Domain.Repositories.Interfaces;

namespace Retailer.Demo.DynamicProperties.DependencyResolution
{
    public static class DomainDependencies
    {
        public static void ResolveDomainDependencies(this IServiceCollection services,
            string mongoUser,
            string mongoPass,
            string mongoServer,
            string mongoPort,
            string mongoAuthSource,
            string mongoDB)
        {
            services.AddScoped<MongoSettings>(MvcXmlMvcBuilderExtensions => new MongoSettings
            {
                Connection = $"mongodb://{mongoUser}:{mongoPass}@{mongoServer}:{mongoPort}/?authSource={mongoAuthSource}",
                Database = mongoDB
            });
            services.AddScoped<IMongoDbContext, MongoDbContext>();
            services.AddScoped<IUnitOfWork, MongoDbUnitOfWork>();
            services.AddScoped<IDynamicPropertyRepository, DynamicPropertyRepository>();
        }
    }
}
