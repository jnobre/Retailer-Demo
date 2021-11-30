using MongoDB.Driver;
using System.Threading;
using System.Threading.Tasks;

namespace Retailer.Demo.DynamicProperties.Domain.Repositories.Interfaces
{
    public interface IMongoDbContext
    {
        IMongoCollection<DynamicProperty> GetCollection<DynamicProperty>(string name);
        Task<IClientSessionHandle> StartSessionAsync(CancellationToken cancellationToken);

    }
}
