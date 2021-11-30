﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json.Converters;
using Retailer.Demo.DynamicProperties.Domain.Entities.Enums;
using System;
using System.Text.Json.Serialization;
using Type = Retailer.Demo.DynamicProperties.Domain.Entities.Type;

namespace Retailer.Demo.DynamicProperties.Application.DTOs
{
    /// <summary>
    /// Dynamic Property Data Transfer Obj.
    /// </summary>
    public class DynamicPropertyDTO
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
        public ScopeName Scope { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
///        [JsonConverter(typeof(StringEnumConverter))]
///        [BsonRepresentation(BsonType.String)]
        public Type Type { get; set; }

        /// <summary>
        /// Gets or sets the locale code.
        /// </summary>
        /// <value>
        /// The locale code.
        /// </value>
        public string LocaleCode { get; set; }

        /// <summary>
        /// Gets or sets the created date.
        /// </summary>
        /// <value>
        /// The created date.
        /// </value>
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        /// Gets or sets the updated date.
        /// </summary>
        /// <value>
        /// The updated date.
        /// </value>
        public DateTime? UpdatedDate { get; set; }
    }
}