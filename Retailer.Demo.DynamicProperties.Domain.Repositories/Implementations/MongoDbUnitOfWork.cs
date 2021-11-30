using MongoDB.Driver;
using Retailer.Demo.DynamicProperties.Domain.Repositories.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Retailer.Demo.DynamicProperties.Domain.Repositories.Implementations
{
    public class MongoDbUnitOfWork : IUnitOfWork, IDisposable
    {
        IClientSessionHandle _session;
        readonly IMongoDbContext _mongoDbContext;

        public MongoDbUnitOfWork(IMongoDbContext mongoDbContext)
        {
            _mongoDbContext = mongoDbContext;
        }

        public async Task AbortAsync(CancellationToken cancellationToken = default)
        {
            await _session.AbortTransactionAsync(cancellationToken);
        }

        public async Task BeginTransactionAsync(CancellationToken cancellationToken = default)
        {
            _session = await _mongoDbContext.StartSessionAsync(cancellationToken);
            _session.StartTransaction();
        }

        public async Task CommitAsync(CancellationToken cancellationToken = default)
        {
            await _session.CommitTransactionAsync(cancellationToken);
        }

        public void Dispose()
        {
            var count = 0;
            while (_session is { IsInTransaction: true } && count < 10)
            {
                Thread.Sleep(TimeSpan.FromMilliseconds(100));
                count++;
            }

            _session?.Dispose();

            GC.SuppressFinalize(this);
        }

        public TTransactionSessionType GetCurrentTransactionSession<TTransactionSessionType>() => (TTransactionSessionType)_session;
    }
}
