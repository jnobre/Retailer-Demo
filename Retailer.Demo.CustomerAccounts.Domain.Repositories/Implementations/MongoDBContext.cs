using System.Threading;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace Retailer.Demo.CustomerAccounts.Domain.Repositories.Implementations
{
    public interface IMongoDbContext 
    {
        IMongoCollection<User> GetCollection<User>(string name);
        Task<IClientSessionHandle> StartSessionAsync(CancellationToken cancellationToken);
    }

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
