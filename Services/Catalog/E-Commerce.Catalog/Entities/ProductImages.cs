﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace E_Commerce.Catalog.Entities
{
    public class ProductImages
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ProductImagesID { get; set; }
        public string Image1 { get; set; }
        public string Image2 { get; set; }
        public string Image3 { get; set; }
        public string ProductId { get; set; }
        [BsonIgnore]
        public Product Product { get; set; }

    }
}
