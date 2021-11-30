using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json.Converters;
using Retailer.Demo.DynamicProperties.Domain.Entities.Enums;
using System.Text.Json.Serialization;

namespace Retailer.Demo.DynamicProperties.Domain.Entities
{
    public class Type : IEntity
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        /// <value>
        /// The id.
        /// </value>
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [JsonIgnore]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the Name.
        /// </summary>
        /// <value>
        /// The Name.
        /// </value>
        [JsonConverter(typeof(StringEnumConverter))]
        [BsonRepresentation(BsonType.String)]
        public PropertyType Name;

        /// <summary>
        /// Gets or sets the Validation.
        /// </summary>
        /// <value>
        /// The validation rule.
        /// </value>
        public string Validation;
    }
}