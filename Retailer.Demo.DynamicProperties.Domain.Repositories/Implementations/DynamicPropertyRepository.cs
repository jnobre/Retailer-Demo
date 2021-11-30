using Retailer.Demo.DynamicProperties.Domain.Repositories.Interfaces;
using Retailer.Demo.DynamicProperties.Domain.Entities;
using MongoDB.Driver;
using System.Threading.Tasks;
using System.Collections.Generic;
using Retailer.Demo.DynamicProperties.Domain.Entities.Enums;
using System;

namespace Retailer.Demo.DynamicProperties.Domain.Repositories.Implementations
{
    public class DynamicPropertyRepository : MongoBaseRepository<DynamicProperty>, IDynamicPropertyRepository
    {
        public DynamicPropertyRepository(IMongoDbContext context) : base(context)
        {
            RegisterIndexes();
        }

        public Task<IEnumerable<DynamicProperty>> GetDynamicPropertyByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<DynamicProperty>> GetDynamicPropertyByRetailer(Guid idRetailer)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<DynamicProperty>> GetDynamicPropertyByRetailerAndName(ScopeName scope, Guid idRetailer)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<DynamicProperty>> GetDynamicPropertyByRetailerAndScope(ScopeName scope, Guid idRetailer)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<DynamicProperty>> GetDynamicPropertyByScope(ScopeName scope)
        {
            throw new NotImplementedException();
        }

        private void RegisterIndexes()
        {
            var indexDynamicProperty = new CreateIndexModel<DynamicProperty>(Builders<DynamicProperty>.IndexKeys.Descending(m => m.IdRetailer), new CreateIndexOptions() { Unique = true });

            this._collection.Indexes.CreateOne(indexDynamicProperty);
        }
    }
}
