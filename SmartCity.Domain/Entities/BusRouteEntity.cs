using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartCity.Domain.Entities
{
    public class BusRouteEntity : BaseEntity
    {
        public PointOfInterestEntity() : base() {}

        [BsonElement("Name")]
        [BsonRequired]
        public string Name { get; set; }

        [BsonElement("BusStations")]
        [BsonRequired]
        public ICollection<BusStationEntity> BusStations { get; set; }

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
