using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartCity.Domain.Entities
{
    public class CityEntity : BaseEntity
    {
        public CityEntity() : base()
        {

        }

        [BsonElement("Name")]
        [BsonRequired]
        public string Name { get; set; }

        [BsonElement("Buses")]
        [BsonRequired]
        public List<BusEntity> Buses { get; set; }

        [BsonElement("BusStations")]
        [BsonRequired]
        public List<BusStationEntity> BusStations { get; set; }

        [BsonElement("BusRoutes")]
        [BsonRequired]
        public List<BusRouteEntity> BusRoutes { get; set; }

        [BsonElement("PointOfInterest")]
        [BsonRequired]
        public List<PointOfInterestEntity> PointsOfInterests { get; set; }

        [BsonElement("CreationDate")]
        [BsonRequired]
        public DateTime CreationDate { get; set; }

        [BsonElement("ModifiedDate")]
        [BsonRequired]
        public DateTime ModifiedDate { get; set; }
    }
}
