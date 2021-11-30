using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Retailer.Demo.DynamicProperties.Domain.Entities.Enums;
using System;

namespace Retailer.Demo.DynamicProperties.Domain.Entities
{
    /// <summary>
    /// Dynamic Property Entity
    /// </summary>
    [BsonCollection("dynamicProperties")]
    public class DynamicProperty : IEntity
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
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [BsonElement("idRetailer")]
        public Guid IdRetailer { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [BsonElement("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the display name.
        /// </summary>
        /// <value>
        /// The display name.
        /// </value>
        [BsonElement("displayName")]
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the required.
        /// </summary>
        /// <value>
        /// The required.
        /// </value>
        [BsonElement("required")]
        public bool Required { get; set; }

        /// <summary>
        /// Gets or sets the searchable.
        /// </summary>
        /// <value>
        /// The searchable.
        /// </value>
        [BsonElement("´searchable")]
        public bool Searchable { get; set; }

        /// <summary>
        /// Gets or sets the scope.
        /// </summary>
        /// <value>
        /// The scope.
        /// </value>
        [BsonElement("scope")]
        public ScopeName Scope { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        [BsonElement("type")]
        public Type Type { get; set; }

        /// <summary>
        /// Gets or sets the locale code.
        /// </summary>
        /// <value>
        /// The locale code.
        /// </value>
        [BsonElement("localCode")]
        public string LocaleCode { get; set; }

        /// <summary>
        /// Gets or sets the created date.
        /// </summary>
        /// <value>
        /// The created date.
        /// </value>
        [BsonElement("createdDate")]
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        /// Gets or sets the updated date.
        /// </summary>
        /// <value>
        /// The updated date.
        /// </value>
        [BsonElement("updateDate")]
        public DateTime? UpdatedDate { get; set; }
    }
}