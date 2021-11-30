using Retailer.Demo.CustomerAccounts.Domain.Entities;
using Retailer.Demo.CustomerAccounts.Domain.Repositories.Interfaces;

namespace Retailer.Demo.CustomerAccounts.Domain.Repositories.Implementations
{
    public class UserRepository : MongoBaseRepository<User>, IUserRepository
    {
        public UserRepository(IMongoDbContext context) : base(context)
        {
        }
    }
}
