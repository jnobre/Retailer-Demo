using System;
using System.Threading;
using System.Threading.Tasks;
using MongoDB.Driver;
using Retailer.Demo.CustomerAccounts.Domain.Repositories.Interfaces;

namespace Retailer.Demo.CustomerAccounts.Domain.Repositories.Implementations
{
    public class MongoDbUnitOfWork : IUnitOfWork , IDisposable
    {
        IClientSessionHandle _session;
        readonly IMongoDbContext _mongoDbContext;

        public MongoDbUnitOfWork(IMongoDbContext mongoDbContext)
        {
            _mongoDbContext = mongoDbContext;
        }

        public async Task BeginTransactionAsync(CancellationToken cancellationToken)
        {
            _session = await _mongoDbContext.StartSessionAsync(cancellationToken);
            _session.StartTransaction();
        }

        public async Task CommitAsync(CancellationToken cancellationToken)
        {
            await _session.CommitTransactionAsync(cancellationToken);
        }

        public async Task AbortAsync(CancellationToken cancellationToken)
        {
            await _session.AbortTransactionAsync(cancellationToken);
        }

        public TTransactionSessionType GetCurrentTransactionSession<TTransactionSessionType>() => (TTransactionSessionType)_session;

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
    }
}
