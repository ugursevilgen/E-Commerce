﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace E_Commerce.Catalog.Entities
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public Decimal ProductPrice { get; set; }
        public string ProductImageUrl{ get; set; }
        public string ProductDescription{ get; set; }
        public string CategoryId{ get; set; }
        [BsonIgnore]
        public Category category { get; set; }

    }
}
