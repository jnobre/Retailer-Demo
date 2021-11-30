using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Retailer.Demo.CustomerAccounts.Domain.Entities
{
    [BsonCollection("users")]
    public class User : IEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("name")]
        public string UserName { get; set; }

        [BsonElement("age")]
        public int Age { get; set; }
    }
}
