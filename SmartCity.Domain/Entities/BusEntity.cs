using MongoDB.Bson.Serialization.Attributes;
using System;

namespace SmartCity.Domain.Entities
{
    public class BusEntity : BaseEntity
    {
        public BusEntity() : base() {}

        [BsonElement("Coordinates")]
        [BsonRequired]
        public CoordinatesEntity Coordinates { get; set; }

        [BsonElement("GoingToGarage")]
        [BsonRequired]
        public bool GoingToGarage { get; set; }

        [BsonElement("CreationDate")]
        [BsonRequired]
        public DateTime CreationDate { get; set; }

        [BsonElement("ModifiedDate")]
        [BsonRequired]
        public DateTime ModifiedDate { get; set; }
    }
}
