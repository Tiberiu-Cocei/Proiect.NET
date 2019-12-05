using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartCity.Domain.Entities
{
    public class BusStationEntity : BaseEntity
    {
        public PointOfInterestEntity() : base() {}

        [BsonElement("Name")]
        [BsonRequired]
        public string Name { get; set; }

        [BsonElement("Coordinates")]
        [BsonRequired]
        public CoordinatesEntity Coordinates { get; set; }
        
        [BsonElement("BusRoutes")]
        [BsonRequired]
        public ICollection<BusRouteEntity> BusRoutes { get; set; }

        [BsonElement("City")]
        [BsonRequired]
        public CityEntity City { get; set; }

        [BsonElement("CreationDate")]
        [BsonRequired]
        public DateTime CreationDate { get; set; }

        [BsonElement("ModifiedDate")]
        [BsonRequired]
        public DateTime ModifiedDate { get; set; }
    }
}
