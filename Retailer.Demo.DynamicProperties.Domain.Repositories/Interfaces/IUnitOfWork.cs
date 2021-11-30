using System.Threading;
using System.Threading.Tasks;

namespace Retailer.Demo.DynamicProperties.Domain.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        Task CommitAsync(CancellationToken cancellationToken = default);
        Task BeginTransactionAsync(CancellationToken cancellationToken = default);
        Task AbortAsync(CancellationToken cancellationToken = default);
        TTransactionSessionType GetCurrentTransactionSession<TTransactionSessionType>();
    }
}
