using MongoDB.Bson.Serialization.Attributes;
using System;

namespace SmartCity.Domain.Entities
{
    public class PointOfInterestEntity : BaseEntity
    {
        public PointOfInterestEntity() : base() {}

        [BsonElement("Coordinates")]
        [BsonRequired]
        public CoordinatesEntity Coordinates { get; set; }

        [BsonElement("Name")]
        [BsonRequired]
        public string Name { get; set; }

        [BsonElement("Description")]
        [BsonRequired]
        public string Description { get; set; }

        [BsonElement("personId")]
        public Guid personId { get; set; }

        [BsonElement("cityName")]
        [BsonRequired]
        public string cityName { get; set; }

        /*[BsonElement("IsPrivate")]
        [BsonRequired]
        public bool IsPrivate { get; set; }*/

        [BsonElement("CreationDate")]
        [BsonRequired]
        public DateTime CreationDate { get; set; }

        [BsonElement("ModifiedDate")]
        [BsonRequired]
        public DateTime ModifiedDate { get; set; }

    }
}
