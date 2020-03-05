using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace SmartCity.Domain.Entities
{
    public class BusRouteEntity : BaseEntity
    {
        public BusRouteEntity() : base() {}

        [BsonElement("Name")]
        [BsonRequired]
        public string Name { get; set; }

        [BsonElement("BusStations")]
        [BsonRequired]
        public ICollection<BusStationEntity> BusStations { get; set; }

        [BsonElement("CreationDate")]
        [BsonRequired]
        public DateTime CreationDate { get; set; }

        [BsonElement("ModifiedDate")]
        [BsonRequired]
        public DateTime ModifiedDate { get; set; }
    }
}
