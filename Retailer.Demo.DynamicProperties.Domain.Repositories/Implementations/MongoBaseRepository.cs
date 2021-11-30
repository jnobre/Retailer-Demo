using MongoDB.Driver;
using Retailer.Demo.DynamicProperties.Domain.Entities;
using Retailer.Demo.DynamicProperties.Domain.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Retailer.Demo.DynamicProperties.Domain.Repositories.Implementations
{
    public abstract class MongoBaseRepository<T> : IBaseRepository<T> where T : IEntity
    {

        protected readonly IMongoCollection<T> _collection;
        protected readonly FilterDefinitionBuilder<T> _filterBuilder = Builders<T>.Filter;

        public MongoBaseRepository(IMongoDbContext dbContext)
        {
            _collection = dbContext.GetCollection<T>(GetCollectionName(typeof(T)));
        }


        public async Task<T> CreateAsync(T entity)
        {
            if(entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            await _collection.InsertOneAsync(entity);

            return entity;
        }

        public async Task<IReadOnlyCollection<T>> GetAllAsync()
        {
            return await _collection.Find(_filterBuilder.Empty).ToListAsync();
        }

        public async Task<IReadOnlyCollection<T>> GetAllAsync(Expression<Func<T, bool>> filter)
        {
            return await _collection.Find(filter).ToListAsync();
        }

        public async Task<T> GetAsync(string id)
        {
            FilterDefinition<T> filter = _filterBuilder.Eq(e => e.Id, id);
            return await _collection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> filter)
        {
            return await _collection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task RemoveAsync(string id)
        {
            FilterDefinition<T> filter = _filterBuilder.Eq(e => e.Id, id);
            await _collection.DeleteOneAsync(filter);
        }

        public async Task<T> UpdateAsync(T entity)
        {
            if(entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            FilterDefinition<T> filter = _filterBuilder.Eq(e => e.Id, entity.Id);
            await _collection.ReplaceOneAsync(filter, entity);

            return entity;
        }


        private static string GetCollectionName(System.Type documentType)
        {
            var isIEntity = documentType.GetInterfaces().Contains(typeof(IEntity));

            if (!isIEntity)
            {
                throw new AggregateException($"Type {documentType.Name} must be IEntity");
            }

            var bsonCollectionAttribute = Attribute.GetCustomAttribute(documentType, typeof(BsonCollectionAttribute)) as BsonCollectionAttribute;

            if (bsonCollectionAttribute == null)
            {
                throw new InvalidDataException($"Type {documentType.Name} must have BsonCollectionAttribute defined");
            }

            return bsonCollectionAttribute.CollectionName;
        }
    }
}
