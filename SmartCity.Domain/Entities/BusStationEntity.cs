using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace SmartCity.Domain.Entities
{
    public class BusStationEntity : BaseEntity
    {
        public BusStationEntity() : base() {}

        [BsonElement("Name")]
        [BsonRequired]
        public string Name { get; set; }

        [BsonElement("Coordinates")]
        [BsonRequired]
        public CoordinatesEntity Coordinates { get; set; }

        [BsonElement("Buses")]
        [BsonRequired]
        public ICollection<BusEntity> Buses { get; set; }

        [BsonElement("CreationDate")]
        [BsonRequired]
        public DateTime CreationDate { get; set; }

        [BsonElement("ModifiedDate")]
        [BsonRequired]
        public DateTime ModifiedDate { get; set; }
    }
}
