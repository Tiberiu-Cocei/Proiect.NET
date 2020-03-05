using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace SmartCity.Domain.Entities
{
    public class CityEntity : BaseEntity
    {
        public CityEntity() : base() {}

        [BsonElement("Name")]
        [BsonRequired]
        public string Name { get; set; }

        [BsonElement("BusRoutes")]
        [BsonRequired]
        public ICollection<BusRouteEntity> BusRoutes { get; set; }

        [BsonElement("PointOfInterest")]
        [BsonRequired]
        public ICollection<PointOfInterestEntity> PointsOfInterests { get; set; }

        [BsonElement("CreationDate")]
        [BsonRequired]
        public DateTime CreationDate { get; set; }

        [BsonElement("ModifiedDate")]
        [BsonRequired]
        public DateTime ModifiedDate { get; set; }
    }
}
