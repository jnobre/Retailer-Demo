﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json.Converters;
using Retailer.Demo.DynamicProperties.Domain.Entities;
using Retailer.Demo.DynamicProperties.Domain.Entities.Enums;
using System.Text.Json.Serialization;

namespace Retailer.Demo.DynamicProperties.API.Requests
{
    public class CreateDynamicPropertyRequest
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the display name.
        /// </summary>
        /// <value>
        /// The display name.
        /// </value>
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the required.
        /// </summary>
        /// <value>
        /// The required.
        /// </value>
        public bool Required { get; set; }

        /// <summary>
        /// Gets or sets the searchable.
        /// </summary>
        /// <value>
        /// The searchable.
        /// </value>
        public bool Searchable { get; set; }

        /// <summary>
        /// Gets or sets the scope.
        /// </summary>
        /// <value>
        /// The scope.
        /// </value>
     //   [JsonConverter(typeof(StringEnumConverter))]
     //   [BsonRepresentation(BsonType.String)]
        public ScopeName Scope { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        public Type Type { get; set; }

        /// <summary>
        /// Gets or sets the locale code.
        /// </summary>
        /// <value>
        /// The locale code.
        /// </value>
        public string LocaleCode { get; set; }
    }
}
