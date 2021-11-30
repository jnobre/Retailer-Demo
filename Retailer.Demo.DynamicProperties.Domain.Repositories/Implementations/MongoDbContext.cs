using MongoDB.Driver;
using Retailer.Demo.DynamicProperties.Domain.Repositories.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Retailer.Demo.DynamicProperties.Domain.Repositories.Implementations
{
    public class MongoDbContext : IMongoDbContext
    {
        private IMongoDatabase _db { get; set; }
        private MongoClient _mongoClient { get; set; }

        public MongoDbContext(MongoSettings settings)
        {
            _mongoClient = new MongoClient(settings.Connection);
            _db = _mongoClient.GetDatabase(settings.Database);
        }

        public IMongoCollection<T> GetCollection<T>(string name)
        {
            return _db.GetCollection<T>(name);
        }

        public async Task<IClientSessionHandle> StartSessionAsync(CancellationToken cancellationToken)
        {
            return await _mongoClient.StartSessionAsync(cancellationToken: cancellationToken);
        }
        
    }
}
